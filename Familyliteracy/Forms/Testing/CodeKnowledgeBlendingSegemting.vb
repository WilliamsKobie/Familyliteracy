Imports DAL
Imports System.Drawing.Imaging
Imports System.Printing.PrintQueue
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Public Class CodeKnowledgeBlendingSegemting
    Private codeKnowledge As New List(Of CodeKnowledge)

    Private dbContext As New FamilyLiteracyEntityDataModel



    Public Function TotalSummation(summation As Dictionary(Of String, Int16), ByVal student As Int32, ByVal dateKey As DateTime, ByVal index As Integer)
        'Sums up all the values for the entire CodeKnowledge
        Dim sumTotals As New CodeKnowledge_Summations
        If TextBox306.Text = String.Empty Then
            TextBox306.Text = "99"
        End If
        If TextBox126.Text = String.Empty Then
            TextBox126.Text = "99"
        End If
        If TextBox125.Text = String.Empty Then
            TextBox125.Text = "99"
        End If
        If TextBox309.Text = String.Empty Then
            TextBox309.Text = "99"
        End If
        If TextBox308.Text = String.Empty Then
            TextBox308.Text = "99"
        End If
        If TextBox307.Text = String.Empty Then
            TextBox307.Text = "99"
        End If
        If TextBox301.Text = String.Empty Then
            TextBox301.Text = "99"
        End If
        If TextBox302.Text = String.Empty Then
            TextBox302.Text = "99"
        End If
        If TextBox303.Text = String.Empty Then
            TextBox303.Text = "99"
        End If
        If TextBox304.Text = String.Empty Then
            TextBox304.Text = "99"
        End If
        If TextBox310.Text = String.Empty Then
            TextBox310.Text = "99"
        End If
        If TextBox300.Text = String.Empty Then
            TextBox300.Text = "99"
        End If
      

        
        sumTotals.StudentNo = student
        sumTotals.ClinicianName = HomeDisplay.Label4.Text
        sumTotals.Date = dateKey
        sumTotals.Count = index
      
        sumTotals.Beginning_Phonics = Convert.ToInt16(TextBox306.Text)
        sumTotals.ovdg = Convert.ToInt16(TextBox126.Text)      
        sumTotals.Consonant_Digraphs = Convert.ToInt16(TextBox125.Text)
        sumTotals.Basic_Phonics = Convert.ToInt16(TextBox309.Text)
        sumTotals.sv = Convert.ToInt16(TextBox300.Text)
        sumTotals.Vowel_Digraphs = Convert.ToInt16(TextBox308.Text)
        sumTotals.oneltr_con = Convert.ToInt16(TextBox307.Text)
        sumTotals.Advanced_Phonics = Convert.ToInt16(TextBox310.Text)
        sumTotals.con = Convert.ToInt16(TextBox301.Text)
        sumTotals.cdg = Convert.ToInt16(TextBox302.Text)
        sumTotals.ovdg = Convert.ToInt16(TextBox303.Text)
        sumTotals.var_vdg = Convert.ToInt16(TextBox304.Text)
        dbContext.CodeKnowledge_Summations.Add(sumTotals)
        dbContext.SaveChanges()

    
     
        Return Nothing
    End Function
    Public Function BeginningPhonics(ByVal student As String, ByVal dateKey As DateTime, ByVal index As Integer) As Dictionary(Of String, Int16)

        Dim basicphonics As New BeginningPhonic

        basicphonics.Count = index
        Dim summation As New Dictionary(Of String, Int16)

        Dim entry As String = String.Empty

        basicphonics.StudentNo = Convert.ToInt32(student)
        basicphonics.Date = dateKey
        entry = TextBox1.Text
        If TextBox1.Text = "a" Then 'a

            codeKnowledge.Add(New CodeKnowledge("a", 1, 1, "Beginning_Phonics", entry.Trim(), "Basic"))

            basicphonics.a = "a"
        Else

            codeKnowledge.Add(New CodeKnowledge("a", 1, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.a = entry
        End If
        entry = TextBox2.Text
        If TextBox2.Text = "e" Then 'e

            codeKnowledge.Add(New CodeKnowledge("e", 2, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.e = "e"
        Else

            codeKnowledge.Add(New CodeKnowledge("e", 2, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.e = entry
        End If
        entry = TextBox3.Text
        If TextBox3.Text = "i" Then 'i

            codeKnowledge.Add(New CodeKnowledge("i", 3, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.i = "i"
        Else

            codeKnowledge.Add(New CodeKnowledge("i", 3, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.i = entry
        End If
        entry = TextBox4.Text
        If TextBox4.Text = "o" Then  'o

            codeKnowledge.Add(New CodeKnowledge("o", 4, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.o = "o"
        Else

            codeKnowledge.Add(New CodeKnowledge("o", 4, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.o = entry
        End If
        entry = TextBox5.Text
        If TextBox5.Text = "u" Then   'u

            codeKnowledge.Add(New CodeKnowledge("u", 5, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.u = "u"
        Else

            codeKnowledge.Add(New CodeKnowledge("u", 5, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.u = entry
        End If
      

       
        entry = TextBox6.Text
        If TextBox6.Text = "b" Then   'b

            codeKnowledge.Add(New CodeKnowledge("b", 6, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.b = TextBox6.Text
        Else

            codeKnowledge.Add(New CodeKnowledge("b", 6, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.b = TextBox6.Text
        End If
        entry = TextBox7.Text
        If TextBox7.Text = "k" Or TextBox7.Text = "s" Then   'c

            codeKnowledge.Add(New CodeKnowledge("c", 7, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.c = entry
        Else

            codeKnowledge.Add(New CodeKnowledge("c", 7, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.c = entry
        End If

        entry = TextBox8.Text
        If TextBox8.Text = "d" Then  'd

            codeKnowledge.Add(New CodeKnowledge("d", 8, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.d = entry
        Else

            codeKnowledge.Add(New CodeKnowledge("d", 8, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.d = entry
        End If
        entry = TextBox9.Text
        If TextBox9.Text = "f" Then   'f

            codeKnowledge.Add(New CodeKnowledge("f", 9, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.f = entry
        Else

            codeKnowledge.Add(New CodeKnowledge("f", 9, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.f = entry
        End If

        entry = TextBox10.Text
        If TextBox10.Text = "g" Or TextBox10.Text = "j" Then  'g

            codeKnowledge.Add(New CodeKnowledge("g", 10, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.g = entry
        Else

            codeKnowledge.Add(New CodeKnowledge("g", 10, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.g = entry
        End If
        entry = TextBox11.Text
        If TextBox11.Text = "h" Then  'h

            codeKnowledge.Add(New CodeKnowledge("h", 11, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.h = entry

        Else

            codeKnowledge.Add(New CodeKnowledge("h", 11, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.h = entry
        End If

        entry = TextBox12.Text
        If TextBox12.Text = "j" Then  'j

            codeKnowledge.Add(New CodeKnowledge("j", 12, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.j = entry
        Else

            codeKnowledge.Add(New CodeKnowledge("j", 12, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.j = entry
        End If
        entry = TextBox13.Text
        If TextBox13.Text = "k" Then  'k

            codeKnowledge.Add(New CodeKnowledge("k", 13, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.k = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("k", 13, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.k = entry
        End If
        entry = TextBox14.Text
        If TextBox14.Text = "l" Then  'l

            codeKnowledge.Add(New CodeKnowledge("l", 14, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.l = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("l", 14, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.l = entry
        End If
        entry = TextBox15.Text
        If TextBox15.Text = "m" Then  'm

            codeKnowledge.Add(New CodeKnowledge("m", 15, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.m = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("m", 15, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.m = entry
        End If
        entry = TextBox16.Text
        If TextBox16.Text = "n" Then  'n

            codeKnowledge.Add(New CodeKnowledge("n", 16, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.n = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("n", 16, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.n = entry
        End If
        entry = TextBox17.Text
        If TextBox17.Text = "p" Then   'p

            codeKnowledge.Add(New CodeKnowledge("p", 17, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.p = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("p", 17, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.p = entry
        End If
        entry = TextBox18.Text
        If TextBox18.Text = "r" Or TextBox2.Text = "er" Then  'r

            codeKnowledge.Add(New CodeKnowledge("r", 18, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.r = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("r", 18, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.r = entry
        End If
        entry = TextBox19.Text
        If TextBox19.Text = "s" Then  's

            codeKnowledge.Add(New CodeKnowledge("s", 19, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.s = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("s", 19, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.s = entry
        End If
        entry = TextBox20.Text
        If TextBox20.Text = "t" Then  't

            codeKnowledge.Add(New CodeKnowledge("t", 20, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.t = entry

        Else
            codeKnowledge.Add(New CodeKnowledge("t", 20, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.t = entry
        End If
        entry = TextBox21.Text
        If TextBox21.Text = "v" Then   'v

            codeKnowledge.Add(New CodeKnowledge("v", 21, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.v = entry

        Else
            codeKnowledge.Add(New CodeKnowledge("v", 21, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.v = entry

        End If
        entry = TextBox22.Text
        If TextBox22.Text = "w" Then   'w

            codeKnowledge.Add(New CodeKnowledge("w", 22, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.w = entry

        Else
            codeKnowledge.Add(New CodeKnowledge("w", 22, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.w = entry

        End If
        If TextBox23.Text = "ks" Or TextBox23.Text = "gz" Then   'x

            onetlettercon = 1
        Else


        End If
        entry = TextBox24.Text
        If TextBox24.Text = "y" Or TextBox24.Text = "ie" Or TextBox24.Text = "ee" Or TextBox24.Text = "i" Then  'y

            codeKnowledge.Add(New CodeKnowledge("y", 24, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.y = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("y", 24, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.y = entry
        End If
        entry = TextBox25.Text
        If TextBox25.Text = "z" Then  'z

            codeKnowledge.Add(New CodeKnowledge("z", 25, 1, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.z = entry
        Else
            codeKnowledge.Add(New CodeKnowledge("z", 25, 0, "Beginning_Phonics", entry.Trim(), "Basic"))
            basicphonics.z = entry
        End If

        dbContext.BeginningPhonics.Add(basicphonics)
        dbContext.SaveChanges()
      
        ConsonantDigraphs(summation, dateKey, student, index)
        Return Nothing
     

    End Function

    Public Function ConsonantDigraphs(summation As Dictionary(Of String, Int16), ByVal dateKey As DateTime, ByVal student As Int32, ByVal index As Integer) As Dictionary(Of String, Int16)

        Dim consonants As New ConsonantDigraph

        Dim cdg As Integer = 0
        consonants.Count = index
        consonants.StudentNo = student
        consonants.Date = dateKey
        If TextBox29.Text = "k" Then 'ck

        End If
        entry = TextBox26.Text
        If TextBox26.Text = "sh" Then 'sh

            codeKnowledge.Add(New CodeKnowledge("sh", 26, 1, "Consonant_Digraphs", entry.Trim(), "Basic"))

        Else
            codeKnowledge.Add(New CodeKnowledge("sh", 26, 0, "Consonant_Digraphs", entry.Trim(), "Basic"))
        End If
        consonants.sh = entry
        entry = TextBox27.Text
        If TextBox27.Text = "ch" Then 'ch

            codeKnowledge.Add(New CodeKnowledge("ch", 27, 1, "Consonant_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ch", 27, 0, "Consonant_Digraphs", entry.Trim(), "Basic"))
        End If
        consonants.ch = entry
        entry = TextBox28.Text
        If TextBox28.Text = "th" Then 'th


            codeKnowledge.Add(New CodeKnowledge("th", 28, 1, "Consonant_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("th", 28, 0, "Consonant_Digraphs", entry.Trim(), "Basic"))
        End If
        consonants.th = entry
        entry = TextBox30.Text
        If TextBox30.Text = "kw" Then 'qu

            codeKnowledge.Add(New CodeKnowledge("qu", 30, 1, "Consonant_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("qu", 30, 0, "Consonant_Digraphs", entry.Trim(), "Basic"))
        End If
        consonants.qu = entry

        If TextBox31.Text = "s" Then 'ce


        End If
        dbContext.ConsonantDigraphs.Add(consonants)
        dbContext.SaveChanges()


 
        VowelDigraphs(summation, dateKey, student, index)
        Return Nothing
    End Function
    Public Function VowelDigraphs(summation As Dictionary(Of String, Int16), ByVal dateKey As DateTime, ByVal student As Int32, ByVal index As Integer) As Dictionary(Of String, Int16)
        Dim vowels As New VowelDigraph


        Dim entry As String = String.Empty
        vowels.Count = index
        vowels.StudentNo = student
        vowels.Date = dateKey
        entry = TextBox32.Text
        If TextBox32.Text = "ie" Or TextBox32.Text = "ee" Then 'ie

            codeKnowledge.Add(New CodeKnowledge("ie", 32, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))

        Else
            codeKnowledge.Add(New CodeKnowledge("ie", 32, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.ie = entry
        entry = TextBox33.Text
        If TextBox33.Text = "oo" Then 'oo

            codeKnowledge.Add(New CodeKnowledge("oo", 33, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("oo", 33, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.oo = entry
        entry = TextBox34.Text
        If TextBox34.Text = "ue" Then  'ue


            codeKnowledge.Add(New CodeKnowledge("ue", 34, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ue", 34, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.ue = entry
        entry = TextBox35.Text
        If TextBox35.Text = "ow" Or TextBox35.Text = "oe" Then  'ow

            codeKnowledge.Add(New CodeKnowledge("ow", 35, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ow", 35, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.ow = entry
        entry = TextBox36.Text
        If TextBox36.Text = "oy" Then  'oy

            codeKnowledge.Add(New CodeKnowledge("oy", 36, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("oy", 36, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.oy = entry
        entry = TextBox37.Text
        If TextBox37.Text = "ee" Then  'ee

            codeKnowledge.Add(New CodeKnowledge("ee", 37, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ee", 37, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.ee = entry
        entry = TextBox38.Text
        If TextBox38.Text = "aw" Then  'aw

            codeKnowledge.Add(New CodeKnowledge("aw", 38, 1, "Vowel_Digraphs", entry.Trim(), "Basic"))
        Else
            codeKnowledge.Add(New CodeKnowledge("aw", 38, 0, "Vowel_Digraphs", entry.Trim(), "Basic"))
        End If
        vowels.aw = entry


        dbContext.VowelDigraphs.Add(vowels)
        dbContext.SaveChanges()


       
      
        summation = AdvancedPhonics(summation, dateKey, student, index)
        Return summation
    End Function
    Public Function AdvancedPhonics(summation As Dictionary(Of String, Int16), ByVal dateKey As DateTime, ByVal student As Int32, ByVal index As Integer) As Dictionary(Of String, Int16)
        Dim advPhonics As New AdvancedPhonic
        Dim var_vdg As Integer
        Dim entry As String = String.Empty

        advPhonics.Count = index
        advPhonics.StudentNo = student
        advPhonics.Date = dateKey
        entry = TextBox23.Text
        If TextBox23.Text = "ks" Or TextBox23.Text = "gz" Then   'x

            codeKnowledge.Add(New CodeKnowledge("x", 23, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))

        Else
            codeKnowledge.Add(New CodeKnowledge("x", 23, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.x = entry
        entry = TextBox29.Text
        If TextBox29.Text = "k" Then 'ck

            codeKnowledge.Add(New CodeKnowledge("ck", 29, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ck", 29, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ck = entry
        entry = TextBox39.Text
        If TextBox39.Text = "ee" Or TextBox39.Text = "e" Or TextBox39.Text = "ae" Then  'ea

            codeKnowledge.Add(New CodeKnowledge("ea", 39, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ea", 39, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ea = entry
        entry = TextBox40.Text
        If TextBox40.Text = "oe" Then 'oa

            codeKnowledge.Add(New CodeKnowledge("oa", 40, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("oa", 40, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.oa = entry
        entry = TextBox41.Text
        If TextBox41.Text = "ae" Then  'ai
            var_vdg = var_vdg + 1
            codeKnowledge.Add(New CodeKnowledge("ai", 41, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ai", 41, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ai = entry
        entry = TextBox42.Text
        If TextBox42.Text = "oy" Then   'oi

            codeKnowledge.Add(New CodeKnowledge("oi", 42, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("oi", 42, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.oi = entry
        entry = TextBox43.Text
        If TextBox43.Text = "ae" Then   'ay


            codeKnowledge.Add(New CodeKnowledge("ay", 43, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ay", 43, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ay = entry
        entry = TextBox44.Text
        If TextBox44.Text = "ow" Or TextBox44.Text = "oo" Or TextBox44.Text = "u" Then   'ou

            codeKnowledge.Add(New CodeKnowledge("ou", 44, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ou", 44, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ou = entry
        entry = TextBox45.Text
        If TextBox45.Text = "ee" Or TextBox45.Text = "ae" Then   'ey

            codeKnowledge.Add(New CodeKnowledge("ey", 45, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ey", 45, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ey = entry
        entry = TextBox46.Text
        If TextBox46.Text = "aw" Then  'au
            var_vdg = var_vdg + 1
            codeKnowledge.Add(New CodeKnowledge("au", 46, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("au", 46, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.au = entry
        entry = TextBox47.Text
        If TextBox47.Text = "oo" Or TextBox47.Text = "ue" Then  'ew

            codeKnowledge.Add(New CodeKnowledge("ew", 47, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ew", 47, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ew = entry
        entry = TextBox48.Text
        If TextBox48.Text = "ie" Then  'igh

            codeKnowledge.Add(New CodeKnowledge("igh", 48, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("igh", 48, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.igh = entry
        entry = TextBox49.Text
        If TextBox49.Text = "oo" Then  'ui
            var_vdg = var_vdg + 1
            codeKnowledge.Add(New CodeKnowledge("ui", 49, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ui", 49, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ui = entry
        entry = TextBox50.Text
        If TextBox50.Text = "ae" Or TextBox50.Text = "ie" Then  'eigh

            codeKnowledge.Add(New CodeKnowledge("eigh", 50, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("eigh", 50, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.eigh = entry
        entry = TextBox31.Text
        If TextBox31.Text = "s" Then 'ce

            codeKnowledge.Add(New CodeKnowledge("ce", 31, 1, "Advanced_Phonics", entry.Trim(), "Advanced"))
        Else
            codeKnowledge.Add(New CodeKnowledge("ce", 31, 0, "Advanced_Phonics", entry.Trim(), "Advanced"))
        End If
        advPhonics.ce = entry

        dbContext.AdvancedPhonics.Add(advPhonics)
        dbContext.SaveChanges()

     



        Return summation
    End Function
    Private Sub TriTesting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim convertName As INameConversion = New StudentNameConversion

        Dim studentName As String = String.Empty
        Label130.Text = HomeDisplay.Label4.Text
        studentName = TestingAssessments.ComboBox5.SelectedValue
        studentId = convertName.ConvertToId(studentName.Trim())
        Label126.Text = studentId
        Label122.Text = studentName
        ClearAllFields()
    End Sub



    Public Sub BlendingSum(ByVal studentNo As Integer, ByVal dateStamp As DateTime, ByVal index As Integer)
        Dim blendingSums As New Dictionary(Of String, Integer)
        BlendingTwoSoundWords(studentNo, dateStamp, blendingSums, index)
        BlendingThreeSndWords(studentNo, dateStamp, blendingSums, index)
        BlendingFourSndWords(studentNo, dateStamp, blendingSums, index)
        BlendingFiveSndWords(studentNo, dateStamp, blendingSums, index)

        Dim storeBlendingSummations As New Blending_Summation

        storeBlendingSummations.Count = index
        storeBlendingSummations.StudentNo = studentNo
        storeBlendingSummations.Date = dateStamp
        storeBlendingSummations.Two_Sound = Convert.ToInt16(TextBox78.Text)
        storeBlendingSummations.Three_Sound = Convert.ToInt16(TextBox79.Text)
        storeBlendingSummations.Four_Sound = Convert.ToInt16(TextBox80.Text)
        storeBlendingSummations.Five_Sound = Convert.ToInt16(TextBox81.Text)
        storeBlendingSummations.ClinicianName = HomeDisplay.Label4.Text
        dbContext.Blending_Summation.Add(storeBlendingSummations)
        dbContext.SaveChanges()

    
    End Sub

    Public Sub SegmentedSum(ByVal studentNo As Integer, ByVal dateStamp As DateTime, ByVal index As Integer)
        Dim segmentSums As New Dictionary(Of String, Integer)
        Segment2SndWords(studentNo, dateStamp, segmentSums, index)
        Segment3SndWords(studentNo, dateStamp, segmentSums, index)
        Segment4SndWords(studentNo, dateStamp, segmentSums, index)
        Segment5SndWords(studentNo, dateStamp, segmentSums, index)
        Segment2SndnonWords(studentNo, dateStamp, segmentSums, index)
        Segment3SndnonWords(studentNo, dateStamp, segmentSums, index)
        Segment4SndnonWords(studentNo, dateStamp, segmentSums, index)

        Dim storeSegmentingSummations As New Segmenting_Summation

        storeSegmentingSummations.Count = index
        storeSegmentingSummations.StudentNo = studentNo
        storeSegmentingSummations.Date = dateStamp
        storeSegmentingSummations.Two_Sound = Convert.ToInt16(TextBox106.Text)
        storeSegmentingSummations.Three_Sound = Convert.ToInt16(TextBox107.Text)
        storeSegmentingSummations.Four_Sound = Convert.ToInt16(TextBox108.Text)
        storeSegmentingSummations.Five_Sound = Convert.ToInt16(TextBox109.Text)
        storeSegmentingSummations.Two_snd_NonWord = Convert.ToInt16(TextBox110.Text)
        storeSegmentingSummations.Three_snd_NonWord = Convert.ToInt16(TextBox111.Text)
        storeSegmentingSummations.Four_snd_NonWord = Convert.ToInt16(TextBox112.Text)
        storeSegmentingSummations.ClinicianName = HomeDisplay.Label4.Text
        dbContext.Segmenting_Summation.Add(storeSegmentingSummations)
        dbContext.SaveChanges()

        Label121.Text = index.ToString()

     
    End Sub

    Public Function GenreateIndex() As Integer

        Dim value As Integer
        Dim lastIndex = (From p In dbContext.CodeKnowledge_Summations
                         Order By p.Count Descending
                         Select p).First()

        value = lastIndex.Count


        value = value + 1
        Return value
    End Function


    Public Function BlendingTwoSoundWords(ByVal student As Int16, ByVal dateKey As DateTime, ByVal blendingSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim twoSnd As New Blending_2snd_Words

        twoSnd.Count = index
        Dim entry As String = String.Empty
        twoSnd.StudentNo = student
        twoSnd.Date = dateKey
        entry = TextBox51.Text
      
        twoSnd.at = entry
        entry = TextBox52.Text
    
        twoSnd.shee = entry
        entry = TextBox53.Text
  
        twoSnd.may = entry
        entry = TextBox54.Text

        twoSnd.saw = entry
        entry = TextBox55.Text

        twoSnd.it = entry
        entry = TextBox56.Text
      
        twoSnd.fur = entry
        If TextBox78.Text = String.Empty Then
            TextBox78.Text = "99"
        End If
        twoSnd.Sum = Convert.ToInt16(TextBox78.Text)
        dbContext.Blending_2snd_Words.Add(twoSnd)
        dbContext.SaveChanges()

        Return blendingSums
    End Function

  
    Public Function BlendingThreeSndWords(ByVal student As Int16, ByVal dateKey As DateTime, ByVal blendingSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim threeSnd As New Blending_3snd_Words
        threeSnd.Count = index
        Dim entry As String = String.Empty
        threeSnd.StudentNo = student
        threeSnd.Date = dateKey
        entry = TextBox57.Text
   
        threeSnd.pig = entry
        entry = TextBox58.Text
     
        threeSnd.bug = entry
        entry = TextBox59.Text

        threeSnd.hat = entry
        entry = TextBox60.Text
      
        threeSnd.pin = entry
        entry = TextBox61.Text
     
        threeSnd.rat = entry
        entry = TextBox62.Text
       
        threeSnd.bird = entry
        entry = TextBox63.Text
      
        threeSnd.shell = entry
        entry = TextBox64.Text
       
        threeSnd.five = entry
        entry = TextBox65.Text
      
        threeSnd.boat = entry
        If TextBox79.Text = String.Empty Then
            TextBox79.Text = "99"
        End If
   
        threeSnd.Sum = Convert.ToInt16(TextBox79.Text)
        dbContext.Blending_3snd_Words.Add(threeSnd)
        dbContext.SaveChanges()

        Return blendingSums
    End Function

    Public Function BlendingFourSndWords(ByVal student As Int16, ByVal dateKey As DateTime, ByVal blendingSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim fourSnd As New Blending_4snd_Words

        fourSnd.Count = index
        Dim entry As String = String.Empty
        fourSnd.StudentNo = student
        fourSnd.Date = dateKey
        entry = TextBox66.Text
      
        fourSnd.frog = entry
        entry = TextBox67.Text
      
        fourSnd.grass = entry
        entry = TextBox68.Text
       
        fourSnd.stick = entry
        entry = TextBox69.Text
      
        fourSnd.jump = entry
        entry = TextBox70.Text
    
        fourSnd.under = entry
        entry = TextBox71.Text
       
        fourSnd.mist = entry
        If TextBox80.Text = String.Empty Then
            TextBox80.Text = "99"
        End If
     
        fourSnd.Sum = Convert.ToInt16(TextBox80.Text)
        dbContext.Blending_4snd_Words.Add(fourSnd)
        dbContext.SaveChanges()




        Return blendingSums
    End Function

  
    Public Function BlendingFiveSndWords(ByVal student As Int16, ByVal dateKey As DateTime, ByVal blendingSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)


        Dim value As Integer = 0
        Dim fiveSnd As New Blending_5snd_Words

        fiveSnd.Count = index
        Dim entry As String = String.Empty
        fiveSnd.StudentNo = student
        fiveSnd.Date = dateKey
        entry = TextBox72.Text
       
        fiveSnd.print = entry
        entry = TextBox73.Text
    
        fiveSnd.crunch = entry
        entry = TextBox74.Text
        
        fiveSnd.plant = entry
        entry = TextBox75.Text
        
        fiveSnd.stamp = entry
        entry = TextBox76.Text
    
        fiveSnd.street = entry
        entry = TextBox77.Text
       
        fiveSnd.blast = entry
        If TextBox81.Text = String.Empty Then
            TextBox81.Text = "99"
        End If
      
        fiveSnd.Sum = Convert.ToInt16(TextBox81.Text)
        dbContext.Blending_5snd_Words.Add(fiveSnd)
        dbContext.SaveChanges()


        Return blendingSums
    End Function

   


    Public Function Segment2SndWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim twoSnd As New Segment_2snd_Words

        twoSnd.Count = index
        Dim entry As String = String.Empty
        twoSnd.StudentNo = student
        twoSnd.Date = dateKey
        entry = TextBox82.Text
       
        twoSnd.in = entry
        entry = TextBox83.Text
      
        twoSnd.it = entry
        entry = TextBox84.Text
       
        twoSnd.pie = entry
        entry = TextBox85.Text
    
        twoSnd.eat = entry
        entry = TextBox86.Text
    
        twoSnd.no = entry
        entry = TextBox87.Text
  
        twoSnd.lie = entry
       
        If TextBox106.Text = String.Empty Then
            TextBox106.Text = "99"
        End If
        segemntedSums("2snd") = TextBox106.Text
        dbContext.Segment_2snd_Words.Add(twoSnd)
        dbContext.SaveChanges()

        Return segemntedSums
    End Function

    Public Function Segment3SndWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim threeSnd As New Segment_3snd_Words

        threeSnd.Count = index
        Dim entry As String = String.Empty
        threeSnd.StudentNo = student
        threeSnd.Date = dateKey
        entry = TextBox88.Text
       
        threeSnd.dog = entry
        entry = TextBox89.Text

        threeSnd.hat = entry
        entry = TextBox90.Text

        threeSnd.pin = entry
        entry = TextBox91.Text

        threeSnd.pot = entry
        entry = TextBox92.Text
    
        threeSnd.rat = entry
        entry = TextBox93.Text
       
        threeSnd.nut = entry

        If TextBox107.Text = String.Empty Then
            TextBox107.Text = "99"
        End If
        segemntedSums("3snd") = Convert.ToInt16(TextBox107.Text)
        dbContext.Segment_3snd_Words.Add(threeSnd)
        dbContext.SaveChanges()
       
        Return segemntedSums
    End Function

    Public Function Segment4SndWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim fourSnd As New Segment_4snd_Words

        fourSnd.Count = index
        Dim entry As String = String.Empty
        fourSnd.StudentNo = student
        fourSnd.Date = dateKey
        entry = TextBox94.Text
       
        fourSnd.frog = entry
        entry = TextBox95.Text
      
        fourSnd.black = entry
        entry = TextBox96.Text
       
        fourSnd.nest = entry
        entry = TextBox97.Text
       
        fourSnd.trip = entry
        entry = TextBox98.Text
       
        fourSnd.hand = entry
        entry = TextBox99.Text
     
        fourSnd.drum = entry
        If TextBox108.Text = String.Empty Then
            TextBox108.Text = "99"
        End If
        segemntedSums("4snd") = Convert.ToInt16(TextBox108.Text)

        dbContext.Segment_4snd_Words.Add(fourSnd)
        dbContext.SaveChanges()
        Return segemntedSums
    End Function

    Public Function Segment5SndWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim fiveSnd As New Segment_5snd_Words

        fiveSnd.Count = index
        Dim entry As String = String.Empty
        fiveSnd.StudentNo = student
        fiveSnd.Date = dateKey
        entry = TextBox100.Text
       
        fiveSnd.clasp = entry
        entry = TextBox101.Text
    
        fiveSnd.stand = entry
        entry = TextBox102.Text
      
        fiveSnd.thunder = entry
        entry = TextBox103.Text
     
        fiveSnd.ground = entry
        entry = TextBox104.Text
      
        fiveSnd.blest = entry
        entry = TextBox105.Text
    
        fiveSnd.strive = entry

        If TextBox109.Text = String.Empty Then
            TextBox109.Text = "99"
        End If
        segemntedSums("5snd") = Convert.ToInt16(TextBox109.Text)
        dbContext.Segment_5snd_Words.Add(fiveSnd)
        dbContext.SaveChanges()
        Return segemntedSums
    End Function
    Public Function Segment2SndnonWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim twoSndnonWrd As New Segment_2snd_NonWords
        twoSndnonWrd.Count = index
        Dim entry As String = String.Empty
        twoSndnonWrd.StudentNo = student
        twoSndnonWrd.Date = dateKey
        entry = TextBox113.Text
        
        twoSndnonWrd.ees = entry
        entry = TextBox114.Text
       
        twoSndnonWrd.ta = entry
        entry = TextBox115.Text
       
        twoSndnonWrd.koe = entry
        entry = TextBox116.Text
       
        twoSndnonWrd.ip = entry
        entry = TextBox117.Text
     
        twoSndnonWrd.ak = entry
        entry = TextBox118.Text
        
        twoSndnonWrd.aen = entry
        If TextBox110.Text = String.Empty Then
            TextBox110.Text = "99"
        End If
        segemntedSums("2snd_NonWord") = Convert.ToInt16(TextBox110.Text)

        dbContext.Segment_2snd_NonWords.Add(twoSndnonWrd)
        dbContext.SaveChanges()
        Return segemntedSums
    End Function

    Public Function Segment3SndnonWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim threeSndnonWrd As New Segment_3snd_NonWords

        threeSndnonWrd.Count = index
        Dim entry As String = String.Empty
        threeSndnonWrd.StudentNo = student
        threeSndnonWrd.date = dateKey
        entry = TextBox119.Text
     
        threeSndnonWrd.pim = entry
        entry = TextBox120.Text

        threeSndnonWrd.mif = entry
        entry = TextBox121.Text
      
        threeSndnonWrd.sep = entry

        If TextBox111.Text = String.Empty Then
            TextBox111.Text = "99"
        End If
        segemntedSums("3snd_NonWord") = Convert.ToInt16(TextBox111.Text)


        dbContext.Segment_3snd_NonWords.Add(threeSndnonWrd)
        dbContext.SaveChanges()
        Return segemntedSums
    End Function

    Public Function Segment4SndnonWords(ByVal student As Int32, ByVal dateKey As DateTime, ByVal segemntedSums As Dictionary(Of String, Integer), ByVal index As Integer) As Dictionary(Of String, Integer)
        Dim value As Integer = 0
        Dim fourSndnonWrd As New Segment_4snd_NonWords

        fourSndnonWrd.Count = index
        Dim entry As String = String.Empty
        fourSndnonWrd.StudentNo = student
        fourSndnonWrd.Date = dateKey
        entry = TextBox122.Text
      
        fourSndnonWrd.flob = entry
        entry = TextBox123.Text
    
        fourSndnonWrd.prif = entry
        entry = TextBox124.Text
       
        fourSndnonWrd.sept = entry

        If TextBox112.Text = String.Empty Then
            TextBox112.Text = "99"
        End If
        segemntedSums("4snd_NonWord") = Convert.ToInt16(TextBox112.Text)


        dbContext.Segment_4snd_NonWords.Add(fourSndnonWrd)
        dbContext.SaveChanges()




        Return segemntedSums
    End Function
    Public Sub ClearAllFields()
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        TextBox8.Text = String.Empty
        TextBox9.Text = String.Empty
        TextBox10.Text = String.Empty
        TextBox11.Text = String.Empty
        TextBox12.Text = String.Empty
        TextBox13.Text = String.Empty
        TextBox14.Text = String.Empty
        TextBox15.Text = String.Empty
        TextBox16.Text = String.Empty
        TextBox17.Text = String.Empty
        TextBox18.Text = String.Empty
        TextBox19.Text = String.Empty
        TextBox20.Text = String.Empty
        TextBox21.Text = String.Empty
        TextBox22.Text = String.Empty
        TextBox23.Text = String.Empty
        TextBox24.Text = String.Empty
        TextBox25.Text = String.Empty
        TextBox26.Text = String.Empty
        TextBox27.Text = String.Empty
        TextBox28.Text = String.Empty
        TextBox29.Text = String.Empty
        TextBox30.Text = String.Empty
        TextBox31.Text = String.Empty
        TextBox32.Text = String.Empty
        TextBox33.Text = String.Empty
        TextBox34.Text = String.Empty
        TextBox35.Text = String.Empty
        TextBox36.Text = String.Empty
        TextBox37.Text = String.Empty
        TextBox38.Text = String.Empty
        TextBox39.Text = String.Empty
        TextBox40.Text = String.Empty
        TextBox41.Text = String.Empty
        TextBox42.Text = String.Empty
        TextBox43.Text = String.Empty
        TextBox44.Text = String.Empty
        TextBox45.Text = String.Empty
        TextBox46.Text = String.Empty
        TextBox47.Text = String.Empty
        TextBox48.Text = String.Empty
        TextBox49.Text = String.Empty
        TextBox50.Text = String.Empty
        TextBox51.Text = String.Empty
        TextBox52.Text = String.Empty
        TextBox53.Text = String.Empty
        TextBox54.Text = String.Empty
        TextBox55.Text = String.Empty
        TextBox56.Text = String.Empty
        TextBox57.Text = String.Empty
        TextBox58.Text = String.Empty
        TextBox59.Text = String.Empty
        TextBox60.Text = String.Empty
        TextBox61.Text = String.Empty
        TextBox62.Text = String.Empty
        TextBox63.Text = String.Empty
        TextBox64.Text = String.Empty
        TextBox65.Text = String.Empty
        TextBox66.Text = String.Empty
        TextBox67.Text = String.Empty
        TextBox68.Text = String.Empty
        TextBox69.Text = String.Empty
        TextBox70.Text = String.Empty
        TextBox71.Text = String.Empty
        TextBox72.Text = String.Empty
        TextBox73.Text = String.Empty
        TextBox74.Text = String.Empty
        TextBox75.Text = String.Empty
        TextBox76.Text = String.Empty
        TextBox77.Text = String.Empty
        TextBox78.Text = String.Empty
        TextBox79.Text = String.Empty
        TextBox80.Text = String.Empty
        TextBox81.Text = String.Empty
        TextBox82.Text = String.Empty
        TextBox83.Text = String.Empty
        TextBox84.Text = String.Empty
        TextBox85.Text = String.Empty
        TextBox86.Text = String.Empty
        TextBox87.Text = String.Empty
        TextBox88.Text = String.Empty
        TextBox89.Text = String.Empty
        TextBox90.Text = String.Empty
        TextBox91.Text = String.Empty
        TextBox92.Text = String.Empty
        TextBox93.Text = String.Empty
        TextBox94.Text = String.Empty
        TextBox95.Text = String.Empty
        TextBox96.Text = String.Empty
        TextBox97.Text = String.Empty
        TextBox98.Text = String.Empty
        TextBox99.Text = String.Empty
        TextBox100.Text = String.Empty
        TextBox101.Text = String.Empty
        TextBox102.Text = String.Empty
        TextBox103.Text = String.Empty
        TextBox104.Text = String.Empty
        TextBox105.Text = String.Empty
        TextBox106.Text = String.Empty
        TextBox107.Text = String.Empty
        TextBox108.Text = String.Empty
        TextBox109.Text = String.Empty
        TextBox110.Text = String.Empty
        TextBox111.Text = String.Empty
        TextBox112.Text = String.Empty
        TextBox113.Text = String.Empty
        TextBox114.Text = String.Empty
        TextBox115.Text = String.Empty
        TextBox116.Text = String.Empty
        TextBox117.Text = String.Empty
        TextBox118.Text = String.Empty
        TextBox119.Text = String.Empty
        TextBox120.Text = String.Empty
        TextBox121.Text = String.Empty
        TextBox122.Text = String.Empty
        TextBox123.Text = String.Empty
        TextBox124.Text = String.Empty
        TextBox300.Text = String.Empty
        TextBox301.Text = String.Empty
        TextBox302.Text = String.Empty
        TextBox303.Text = String.Empty
        TextBox304.Text = String.Empty
        TextBox306.Text = String.Empty
        TextBox307.Text = String.Empty
        TextBox308.Text = String.Empty
        TextBox309.Text = String.Empty
        TextBox310.Text = String.Empty
        TextBox125.Text = String.Empty
        TextBox126.Text = String.Empty

        TextBox106.Text = String.Empty
        TextBox107.Text = String.Empty
        TextBox108.Text = String.Empty
        TextBox109.Text = String.Empty
        TextBox110.Text = String.Empty
        TextBox111.Text = String.Empty
        TextBox306.Text = String.Empty
        TextBox126.Text = String.Empty
        TextBox125.Text = String.Empty
        TextBox309.Text = String.Empty
        TextBox308.Text = String.Empty
        TextBox307.Text = String.Empty
        TextBox301.Text = String.Empty
        TextBox302.Text = String.Empty
        TextBox303.Text = String.Empty
        TextBox304.Text = String.Empty
        TextBox310.Text = String.Empty








    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        SaveMeasurments()
        MsgBox("A new Record of testing results has been added.")
    End Sub

    Public Function SaveMeasurments()
        Try
            Dim studentNo As String = Label126.Text
            Dim dateStamp As DateTime
            If Label128.Text = String.Empty Then

                dateStamp = DateTimePicker1.Value
                Label128.Text = dateStamp
            Else
                dateStamp = Convert.ToDateTime(Label128.Text)
            End If

            Dim summation As New Dictionary(Of String, Int16)
            Dim index As Integer = 0
            If Label126.Text <> String.Empty Then

                index = GenreateIndex()
                DeleteRecord(studentNo.Trim())

                summation = BeginningPhonics(studentNo.Trim(), dateStamp, index)
                TotalSummation(summation, studentNo, dateStamp, index)
                BlendingSum(studentNo, dateStamp, index)
                SegmentedSum(studentNo, dateStamp, index)
                Label128.Text = dateStamp.ToString("M/dd/yyyy, h:mm tt")
                codeKnowledge.Clear()


            Else
                MsgBox("You must go back and select a student.")
            End If

        Catch ex As Exception
            Cleanup()


        End Try
        Return Nothing
    End Function
    Public Function Cleanup()


        Dim lastIndex = (From p In dbContext.CodeKnowledge_Summations
                         Order By p.Count Descending
                         Select p).FirstOrDefault

        Dim lastIndex_BegPhonics = (From p In dbContext.BeginningPhonics
                      Order By p.Count Descending
                      Select p).First

        If lastIndex.Count <> lastIndex_BegPhonics.Count Then

            dbContext.BeginningPhonics.Remove(lastIndex_BegPhonics)
            dbContext.SaveChanges()
            MsgBox("Please Resubmit the data")

        End If

        Return Nothing

    End Function
    Public Sub DeleteRecord(ByVal student As String)
        Dim studentNo As Integer = Convert.ToInt32(student)

        If Label121.Text <> String.Empty Then
            Dim recordNo As Integer = Convert.ToInt32(Label121.Text)



            Dim removeCodeKnowledge As BeginningPhonic = (From p In dbContext.BeginningPhonics
                                              Where p.Count = recordNo And p.StudentNo = studentNo
                                                Select p).FirstOrDefault
            dbContext.BeginningPhonics.Remove(removeCodeKnowledge)
            dbContext.SaveChanges()


            Dim removeBlending As Blending_2snd_Words = (From p In dbContext.Blending_2snd_Words
                                              Where p.Count = recordNo And p.StudentNo = studentNo
                                                Select p).FirstOrDefault
            dbContext.Blending_2snd_Words.Remove(removeBlending)
            dbContext.SaveChanges()
  
            Dim removeSegmenting As Segment_2snd_Words = (From p In dbContext.Segment_2snd_Words
                                             Where p.Count = recordNo And p.StudentNo = studentNo
                                               Select p).FirstOrDefault
            dbContext.Segment_2snd_Words.Remove(removeSegmenting)
            dbContext.SaveChanges()


        End If
    End Sub
    Private Sub Button2_Click_3(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        ViewCodeKnowledgeBlendingSegmenting.Show()
        ViewCodeKnowledgeBlendingSegmenting.Focus()
        Me.Show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click



        PrintDialog1.ShowDialog()
    

        Printfunction()
      

    End Sub
    'Display Print Dialog Control
    'Wait for selection and begin timers, Hide the DateTimePicker, and buttons
    'controls at the bottom of the form

    Public Sub Printfunction()
        Try

        
        Dim screenGrab As New Bitmap(Me.Bounds.Width, Me.Bounds.Height, PixelFormat.Format32bppArgb)
        Dim g As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(screenGrab)

        g.CopyFromScreen(Me.Bounds.X, Me.Bounds.Y, 0, 0, Me.Bounds.Size, CopyPixelOperation.SourceCopy)







        For Each PSource As System.Drawing.Printing.PaperSource In PrintForm1.PrinterSettings.PaperSources
            If PSource.Kind = Drawing.Printing.PaperSourceKind.Custom Then
                PrintForm1.PrinterSettings.DefaultPageSettings.PaperSource = PSource
                Exit For
            End If
        Next
        'Print to selected printer
        Dim ps As System.Drawing.Printing.PaperSize
        For ix As Integer = 0 To PrintDialog1.PrinterSettings.PaperSizes.Count - 1
            If PrintDialog1.PrinterSettings.PaperSizes(ix).Kind = Drawing.Printing.PaperKind.Legal Then
                ps = PrintForm1.PrinterSettings.PaperSizes(ix)
                PrintForm1.PrinterSettings.DefaultPageSettings.PaperSize = ps
                Exit For
            End If
        Next

           
            'Printer settings from the print dialog box

        PrintForm1.PrinterSettings.PrinterName = PrintDialog1.PrinterSettings.PrinterName

            PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
            'Color or Black and White
            If PrintDialog1.PrinterSettings.DefaultPageSettings.Color = True Then
                PrintForm1.PrinterSettings.DefaultPageSettings.Color = True
            Else
                PrintForm1.PrinterSettings.DefaultPageSettings.Color = False
            End If
        PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(5, 5, 5, 5)



        PrintForm1.PrintAction = Drawing.Printing.PrintAction.PrintToPrinter
        PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)

        Catch ex As Exception
            MsgBox("There was a RPC error with the printer")
        End Try


    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'StudentSelector.Show()
        'StudentSelector.Focus()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Label128.Text = String.Empty
        Label121.Text = String.Empty
        ClearAllFields()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        BeginningPhonicsNotDoneValues()
    End Sub
    Public Sub BeginningPhonicsNotDoneValues()

        'Beginning Phonics Not-Done Values
        TextBox300.Text = "99"
        TextBox301.Text = "99"
        TextBox1.Text = "99"
        TextBox2.Text = "99"
        TextBox3.Text = "99"
        TextBox4.Text = "99"
        TextBox5.Text = "99"
        TextBox6.Text = "99"
        TextBox7.Text = "99"
        TextBox8.Text = "99"
        TextBox9.Text = "99"
        TextBox10.Text = "99"
        TextBox11.Text = "99"
        TextBox12.Text = "99"
        TextBox13.Text = "99"
        TextBox14.Text = "99"
        TextBox15.Text = "99"
        TextBox16.Text = "99"
        TextBox17.Text = "99"
        TextBox18.Text = "99"
        TextBox19.Text = "99"
        TextBox20.Text = "99"
        TextBox21.Text = "99"
        TextBox22.Text = "99"
        TextBox23.Text = "99"
        TextBox24.Text = "99"
        TextBox25.Text = "99"
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        ConsonantDigraphNotDoneValues()
    End Sub
    Public Sub ConsonantDigraphNotDoneValues()

        'Consonant Digraphs Not-Done Values
        TextBox302.Text = "99"
        TextBox26.Text = "99"
        TextBox27.Text = "99"
        TextBox28.Text = "99"
        TextBox29.Text = "99"
        TextBox30.Text = "99"
        TextBox31.Text = "99"
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        VowelDigraphsNotDoneValues()
    End Sub
    Public Sub VowelDigraphsNotDoneValues()
        'Vowel Digraphs Not-Done Values
        TextBox303.Text = "99"
        TextBox32.Text = "99"
        TextBox33.Text = "99"
        TextBox34.Text = "99"
        TextBox35.Text = "99"
        TextBox36.Text = "99"
        TextBox37.Text = "99"
        TextBox38.Text = "99"

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        AdvancedPhonicsDefaultValues()
    End Sub
    Public Sub AdvancedPhonicsDefaultValues()
        'Beginning Phonics Default Values
        TextBox300.Text = "5"
        TextBox301.Text = "20"
        TextBox1.Text = "a"
        TextBox2.Text = "e"
        TextBox3.Text = "i"
        TextBox4.Text = "o"
        TextBox5.Text = "u"
        TextBox6.Text = "b"
        TextBox7.Text = "k"
        TextBox8.Text = "d"
        TextBox9.Text = "f"
        TextBox10.Text = "g"
        TextBox11.Text = "h"
        TextBox12.Text = "j"
        TextBox13.Text = "k"
        TextBox14.Text = "l"
        TextBox15.Text = "m"
        TextBox16.Text = "n"
        TextBox17.Text = "p"
        TextBox18.Text = "r"
        TextBox19.Text = "s"
        TextBox20.Text = "t"
        TextBox21.Text = "v"
        TextBox22.Text = "w"
        TextBox23.Text = "ks"
        TextBox24.Text = "y"
        TextBox25.Text = "z"
        'Consonant Digraphs Default Values
        TextBox302.Text = "6"
        TextBox26.Text = "sh"
        TextBox27.Text = "ch"
        TextBox28.Text = "th"
        TextBox29.Text = "k"
        TextBox30.Text = "kw"
        TextBox31.Text = "s"
        'Vowel Digraphs Default Values
        TextBox303.Text = "7"
        TextBox32.Text = ""
        TextBox33.Text = "oo"
        TextBox34.Text = "ue"
        TextBox35.Text = ""
        TextBox36.Text = "oy"
        TextBox37.Text = "ee"
        TextBox38.Text = "aw"
        'Advanced Phonics Default Values
        TextBox304.Text = "12"
        TextBox39.Text = ""
        TextBox40.Text = "oe"
        TextBox41.Text = "ae"
        TextBox42.Text = "oy"
        TextBox43.Text = "ae"
        TextBox44.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = "aw"
        TextBox47.Text = ""
        TextBox48.Text = "ie"
        TextBox49.Text = "oo"
        TextBox50.Text = ""

    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        BlendingDefaultValues()
    End Sub

    Public Sub BlendingDefaultValues()
        TextBox78.Text = "6"
        TextBox79.Text = "9"
        TextBox80.Text = "6"
        TextBox81.Text = "6"
        TextBox51.Text = "at"
        TextBox52.Text = "she"
        TextBox53.Text = "may"
        TextBox54.Text = "saw"
        TextBox55.Text = "it"
        TextBox56.Text = "fur"
        TextBox57.Text = "pig"
        TextBox58.Text = "bug"
        TextBox59.Text = "hat"
        TextBox60.Text = "pin"
        TextBox61.Text = "rat"
        TextBox62.Text = "bird"
        TextBox63.Text = "shell"
        TextBox64.Text = "five"
        TextBox65.Text = "boat"
        TextBox66.Text = "frog"
        TextBox67.Text = "grass"
        TextBox68.Text = "stik"
        TextBox69.Text = "jump"
        TextBox70.Text = "under"
        TextBox71.Text = "mist"
        TextBox72.Text = "print"
        TextBox73.Text = "crunch"
        TextBox74.Text = "plant"
        TextBox75.Text = "stamp"
        TextBox76.Text = "street"
        TextBox77.Text = "blast"

     

    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        SegementingDefaultValues()
    End Sub
    Public Sub SegementingDefaultValues()

        TextBox106.Text = "12"
        TextBox107.Text = "18"
        TextBox108.Text = "24"
        TextBox109.Text = "30"
        TextBox110.Text = "12"
        TextBox111.Text = "9"
        TextBox112.Text = "12"

        TextBox82.Text = "i n"
        TextBox83.Text = "i t"
        TextBox84.Text = "p ie"
        TextBox85.Text = "ee t"
        TextBox86.Text = "n oe"
        TextBox87.Text = "l ie"
        TextBox88.Text = "d aw g"
        TextBox89.Text = "h a t"
        TextBox90.Text = "p i n"
        TextBox91.Text = "p o t"
        TextBox92.Text = "r a t"
        TextBox93.Text = "n u t"
        TextBox94.Text = "f r aw g"
        TextBox95.Text = "b l a k"
        TextBox96.Text = "n e s t"
        TextBox97.Text = "t r i p"
        TextBox98.Text = "h a n d"
        TextBox99.Text = "d r u m"


        TextBox100.Text = "c l a s p"
        TextBox101.Text = "s t a n d"
        TextBox102.Text = "th u n d er"
        TextBox103.Text = "g r ow n d"
        TextBox104.Text = "b l e s t"
        TextBox105.Text = "s t r ie v"

        TextBox113.Text = "ee s"
        TextBox114.Text = "t a"
        TextBox115.Text = "k oe"
        TextBox116.Text = "i p"
        TextBox117.Text = "a k"
        TextBox118.Text = "ae n"
        TextBox119.Text = "p i m"
        TextBox120.Text = "m i f"
        TextBox121.Text = "s e p"
        TextBox122.Text = "f l o b"
        TextBox123.Text = "p r i f"
        TextBox124.Text = "s e p t"


     

    End Sub

    Private Sub TextBox300_LostFocus(sender As Object, e As System.EventArgs)
        TextBox308.Text = TextBox300.Text
    End Sub


    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        If Label128.Text <> String.Empty Then
            SaveValues.Show()

            SaveValues.Focus()

            Timer1.Enabled = True
            Timer1.Start()
            SaveMeasurments()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick




        If Timer1.Interval >= 4000 Then

            Timer1.Stop()
            Timer1.Enabled = False
            SaveValues.Close()

            Me.Close()

        Else





        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Label128.Text = DateTimePicker1.Value
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        'Advanced Phonics Not-Done Values
        TextBox304.Text = "99"
        TextBox39.Text = "99"
        TextBox40.Text = "99"
        TextBox41.Text = "99"
        TextBox42.Text = "99"
        TextBox43.Text = "99"
        TextBox44.Text = "99"
        TextBox45.Text = "99"
        TextBox46.Text = "99"
        TextBox47.Text = "99"
        TextBox48.Text = "99"
        TextBox49.Text = "99"
        TextBox50.Text = "99"
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Blending2SetNotDoneValues()
    End Sub
    Public Sub Blending2SetNotDoneValues()

      
        TextBox78.Text = "99"

        TextBox51.Text = "99"
        TextBox52.Text = "99"
        TextBox53.Text = "99"
        TextBox54.Text = "99"
        TextBox55.Text = "99"
        TextBox56.Text = "99"

    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Blending3NotDoneValues()
    End Sub
    Public Sub Blending3NotDoneValues()
        TextBox79.Text = "99"

        TextBox57.Text = "99"
        TextBox58.Text = "99"
        TextBox59.Text = "99"
        TextBox60.Text = "99"
        TextBox61.Text = "99"
        TextBox62.Text = "99"
        TextBox63.Text = "99"
        TextBox64.Text = "99"
        TextBox65.Text = "99"

    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Blending4NotDoneValues()
    End Sub
    Public Sub Blending4NotDoneValues()
        TextBox80.Text = "99"
        TextBox66.Text = "99"
        TextBox67.Text = "99"
        TextBox68.Text = "99"
        TextBox69.Text = "99"
        TextBox70.Text = "99"
        TextBox71.Text = "99"
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Blending5NotDoneValues()
    End Sub
    Public Sub Blending5NotDoneValues()
        TextBox81.Text = "99"
        TextBox72.Text = "99"
        TextBox73.Text = "99"
        TextBox74.Text = "99"
        TextBox75.Text = "99"
        TextBox76.Text = "99"
        TextBox77.Text = "99"

    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        TextBox106.Text = "99"
       
        TextBox82.Text = "99"
        TextBox83.Text = "99"
        TextBox84.Text = "99"
        TextBox85.Text = "99"
        TextBox86.Text = "99"
        TextBox87.Text = "99"

    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        TextBox107.Text = "99"
      
        TextBox88.Text = "99"
        TextBox89.Text = "99"
        TextBox90.Text = "99"
        TextBox91.Text = "99"
        TextBox92.Text = "99"
        TextBox93.Text = "99"
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        TextBox108.Text = "99"
      
        TextBox94.Text = "99"
        TextBox95.Text = "99"
        TextBox96.Text = "99"
        TextBox97.Text = "99"
        TextBox98.Text = "99"
        TextBox99.Text = "99"
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        TextBox109.Text = "99"
      
        TextBox100.Text = "99"
        TextBox101.Text = "99"
        TextBox102.Text = "99"
        TextBox103.Text = "99"
        TextBox104.Text = "99"
        TextBox105.Text = "99"
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        TextBox110.Text = "99"
       
        TextBox113.Text = "99"
        TextBox114.Text = "99"
        TextBox115.Text = "99"
        TextBox116.Text = "99"
        TextBox117.Text = "99"
        TextBox118.Text = "99"
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        TextBox111.Text = "99"

        TextBox119.Text = "99"
        TextBox120.Text = "99"
        TextBox121.Text = "99"
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        TextBox112.Text = "99"
        TextBox122.Text = "99"
        TextBox123.Text = "99"
        TextBox124.Text = "99"
    End Sub

    Private Sub TextBox78_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox78.TextChanged
        BlendingTotal()
    End Sub

    Public Sub BlendingTotal()
        Dim bln1 As Integer = 0
        Dim bln2 As Integer = 0
        Dim bln3 As Integer = 0
        Dim bln4 As Integer = 0
        Dim blnTotal As Integer = 0
        If TextBox78.Text <> String.Empty And TextBox78.Text <> "99" Then
            bln1 = Convert.ToInt16(TextBox78.Text)
        End If
        If TextBox79.Text <> String.Empty And TextBox79.Text <> "99" Then
            bln2 = Convert.ToInt16(TextBox79.Text)
        End If
        If TextBox80.Text <> String.Empty And TextBox80.Text <> "99" Then
            bln3 = Convert.ToInt16(TextBox80.Text)
        End If
        If TextBox81.Text <> String.Empty And TextBox81.Text <> "99" Then
            bln4 = Convert.ToInt16(TextBox81.Text)
        End If
        blnTotal = bln1 + bln2 + bln3 + bln4
        TextBox127.Text = blnTotal
    End Sub

    Public Sub SegmentingTotal()
        Dim seg1 As Integer = 0
        Dim seg2 As Integer = 0
        Dim seg3 As Integer = 0
        Dim seg4 As Integer = 0
        Dim seg5 As Integer = 0
        Dim seg6 As Integer = 0
        Dim seg7 As Integer = 0
        Dim segTotal As Integer = 0
        If TextBox106.Text <> String.Empty And TextBox106.Text <> "99" Then
            seg1 = Convert.ToInt16(TextBox106.Text)
        End If
        If TextBox107.Text <> String.Empty And TextBox107.Text <> "99" Then
            seg2 = Convert.ToInt16(TextBox107.Text)
        End If
        If TextBox108.Text <> String.Empty And TextBox108.Text <> "99" Then
            seg3 = Convert.ToInt16(TextBox108.Text)
        End If
        If TextBox109.Text <> String.Empty And TextBox109.Text <> "99" Then
            seg4 = Convert.ToInt16(TextBox109.Text)
        End If

        If TextBox110.Text <> String.Empty And TextBox110.Text <> "99" Then
            seg5 = Convert.ToInt16(TextBox110.Text)
        End If
        If TextBox111.Text <> String.Empty And TextBox111.Text <> "99" Then
            seg6 = Convert.ToInt16(TextBox111.Text)
        End If
        If TextBox112.Text <> String.Empty And TextBox112.Text <> "99" Then
            seg7 = Convert.ToInt16(TextBox112.Text)
        End If
        segTotal = seg1 + seg2 + seg3 + seg4 + seg5 + seg6 + seg7
        TextBox128.Text = segTotal
    End Sub

    Private Sub TextBox79_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox79.TextChanged
        BlendingTotal()
    End Sub

    Private Sub TextBox80_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox80.TextChanged
        BlendingTotal()
    End Sub

    Private Sub TextBox81_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox81.TextChanged
        BlendingTotal()
    End Sub

    Private Sub TextBox106_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox106.TextChanged
        SegmentingTotal()
    End Sub

   
    Private Sub TextBox107_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox107.TextChanged
        SegmentingTotal()
    End Sub

    Private Sub TextBox108_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox108.TextChanged
        SegmentingTotal()
    End Sub

    Private Sub TextBox109_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox109.TextChanged
        SegmentingTotal()
    End Sub

    Private Sub TextBox110_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox110.TextChanged
        SegmentingTotal()
    End Sub

    Private Sub TextBox111_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox111.TextChanged
        SegmentingTotal()
    End Sub

    Private Sub TextBox112_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox112.TextChanged
        SegmentingTotal()
    End Sub
End Class

Public Class CodeKnowledge

    Private _code As String = String.Empty
    Private _score As Int16 = 0
    Private _index As Int16 = 0
    Private _codeCatagory As String = String.Empty
    Private _codeEntry As String = String.Empty
    Private _PhonicsType As String = String.Empty

    Public Sub New(codeValue As String, index As Int16, codeScore As Int16, codeType As String, codeEntry As String, phonicsType As String)
        Me._code = codeValue
        Me._index = index
        Me._score = codeScore
        Me._codeCatagory = codeType
        Me._codeEntry = codeEntry
        Me._PhonicsType = phonicsType
    End Sub

    Public Property Phonics_Catagory As String
        Get
            Return _PhonicsType
        End Get
        Set(value As String)
            _PhonicsType = value
        End Set
    End Property

    Public Property Code_Type
        Get
            Return _codeCatagory
        End Get
        Set(value)
            _codeCatagory = value
        End Set
    End Property

    Public Property Code_Label() As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set

    End Property

    Public Property Index_Value As Int16
        Get
            Return _index
        End Get
        Set(value As Int16)
            _index = value
        End Set
    End Property

    Public Property Code_Score As String
        Get
            Return _score
        End Get
        Set(value As String)
            _score = value
        End Set
    End Property
    Public Property Code_Catagory As String
        Get
            Return _codeCatagory
        End Get
        Set(value As String)
            _codeCatagory = value
        End Set
    End Property


    Public Property Code_Entry As String
        Get
            Return _codeEntry
        End Get
        Set(value As String)
            _codeEntry = value
        End Set
    End Property

End Class