Imports System.Linq
Imports DAL
Public Class ViewCodeKnowledgeBlendingSegmenting
    Dim dbContext As New FamilyLiteracyEntityDataModel
    Private Sub ViewCodeKnowledgeBlendingSegmenting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DisplayCodeKnowledge()
    End Sub

    Public Function DisplayCodeKnowledge()
        Label4.Text = CodeKnowledgeBlendingSegemting.Label126.Text
        Label6.Text = CodeKnowledgeBlendingSegemting.Label122.Text
        Dim studentNo As Integer = Convert.ToInt32(Label4.Text)

        Dim queryCodeKnowledge = From p In dbContext.CodeKnowledge_Summations
                    Where p.StudentNo = studentNo
                    Order By p.Date
                    Select p
        Dim queryBlending = From p In dbContext.Blending_Summation
                    Where p.StudentNo = studentNo
                    Order By p.Date
                    Select p

        Dim querySegmenting = From p In dbContext.Segmenting_Summation
                  Where p.StudentNo = studentNo
                  Order By p.Date
                  Select p

        DataGridView1.DataSource = queryCodeKnowledge.ToArray()
        DataGridView2.DataSource = queryBlending.ToArray()
        DataGridView3.DataSource = querySegmenting.ToArray()
        Return Nothing
    End Function

 

    Private Sub DataGridView1_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDoubleClick

        CodeKnowledgeBlendingSegemting.ClearAllFields()
        Dim student As Integer = Convert.ToInt32(Label4.Text)
        Dim selectedIndex As String = DataGridView1.CurrentRow.Cells(2).Value.ToString
        Dim dateKey As DateTime = Convert.ToDateTime(selectedIndex)
        Dim codeKnowledge As New List(Of CodeKnowledge)
        Dim codeSums As New Dictionary(Of String, Int16)
        Dim codeSummation As New CodeKnowledge_Summations
        CodeKnowledgeBlendingSegemting.Label121.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        Dim recordedDate As DateTime = Convert.ToDateTime(DataGridView1.CurrentRow.Cells(2).Value)
        CodeKnowledgeBlendingSegemting.Label128.Text = recordedDate.ToString("M/dd/yyyy, h:mm tt")
        Dim codeKnowledgeSums = From p In dbContext.CodeKnowledge_Summations
        Where (p.Date = dateKey And p.StudentNo = student)
                     Select p

        For Each sum In codeKnowledgeSums
          


            CodeKnowledgeBlendingSegemting.TextBox300.Text = Convert.ToString(sum.sv)
            CodeKnowledgeBlendingSegemting.TextBox308.Text = Convert.ToString(sum.sv)
            CodeKnowledgeBlendingSegemting.TextBox301.Text = Convert.ToString(sum.con)
            CodeKnowledgeBlendingSegemting.TextBox302.Text = Convert.ToString(sum.cdg)
            CodeKnowledgeBlendingSegemting.TextBox303.Text = Convert.ToString(sum.ovdg)
            CodeKnowledgeBlendingSegemting.TextBox126.Text = Convert.ToString(sum.ovdg)
            CodeKnowledgeBlendingSegemting.TextBox304.Text = Convert.ToString(sum.var_vdg)
            CodeKnowledgeBlendingSegemting.TextBox307.Text = Convert.ToString(sum.oneltr_con)

            CodeKnowledgeBlendingSegemting.TextBox306.Text = Convert.ToString(sum.Beginning_Phonics)
            CodeKnowledgeBlendingSegemting.TextBox125.Text = Convert.ToString(sum.Consonant_Digraphs)
            CodeKnowledgeBlendingSegemting.TextBox308.Text = Convert.ToString(sum.Vowel_Digraphs)
            CodeKnowledgeBlendingSegemting.TextBox309.Text = Convert.ToString(sum.Basic_Phonics)
            CodeKnowledgeBlendingSegemting.TextBox310.Text = Convert.ToString(sum.Advanced_Phonics)

       
        Next
    
        Dim codeKnowledgeBeginningPhonics = From p In dbContext.BeginningPhonics
            Where (p.Date = dateKey And p.StudentNo = student)
                        Select p
        For Each value In codeKnowledgeBeginningPhonics
            CodeKnowledgeBlendingSegemting.TextBox1.Text = value.a
            CodeKnowledgeBlendingSegemting.TextBox2.Text = value.e
            CodeKnowledgeBlendingSegemting.TextBox3.Text = value.i
            CodeKnowledgeBlendingSegemting.TextBox4.Text = value.o
            CodeKnowledgeBlendingSegemting.TextBox5.Text = value.u

            CodeKnowledgeBlendingSegemting.TextBox6.Text = value.b
            CodeKnowledgeBlendingSegemting.TextBox7.Text = value.c
            CodeKnowledgeBlendingSegemting.TextBox8.Text = value.d
            CodeKnowledgeBlendingSegemting.TextBox9.Text = value.f
            CodeKnowledgeBlendingSegemting.TextBox10.Text = value.g
            CodeKnowledgeBlendingSegemting.TextBox11.Text = value.h
            CodeKnowledgeBlendingSegemting.TextBox12.Text = value.j
            CodeKnowledgeBlendingSegemting.TextBox13.Text = value.k
            CodeKnowledgeBlendingSegemting.TextBox14.Text = value.l
            CodeKnowledgeBlendingSegemting.TextBox15.Text = value.m
            CodeKnowledgeBlendingSegemting.TextBox16.Text = value.n
            CodeKnowledgeBlendingSegemting.TextBox17.Text = value.p
            CodeKnowledgeBlendingSegemting.TextBox18.Text = value.r
            CodeKnowledgeBlendingSegemting.TextBox19.Text = value.s
            CodeKnowledgeBlendingSegemting.TextBox20.Text = value.t
            CodeKnowledgeBlendingSegemting.TextBox21.Text = value.v
            CodeKnowledgeBlendingSegemting.TextBox22.Text = value.w
            CodeKnowledgeBlendingSegemting.TextBox24.Text = value.y
            CodeKnowledgeBlendingSegemting.TextBox25.Text = value.z

        Next


        Dim codeKnowledgeConsonantDiagraphs = From p In dbContext.ConsonantDigraphs
         Where (p.Date = dateKey And p.StudentNo = student)
                       Select p

        For Each value In codeKnowledgeConsonantDiagraphs
            CodeKnowledgeBlendingSegemting.TextBox26.Text = value.sh
            CodeKnowledgeBlendingSegemting.TextBox27.Text = value.ch
            CodeKnowledgeBlendingSegemting.TextBox28.Text = value.th

            CodeKnowledgeBlendingSegemting.TextBox30.Text = value.qu

        Next


        Dim codeKnowledgeVowelDiagraphs = From p In dbContext.VowelDigraphs
        Where (p.Date = dateKey)
                     Select p

        For Each value In codeKnowledgeVowelDiagraphs
            CodeKnowledgeBlendingSegemting.TextBox32.Text = value.ie
            CodeKnowledgeBlendingSegemting.TextBox33.Text = value.oo
            CodeKnowledgeBlendingSegemting.TextBox34.Text = value.ue

            CodeKnowledgeBlendingSegemting.TextBox35.Text = value.ow

            CodeKnowledgeBlendingSegemting.TextBox36.Text = value.oy
            CodeKnowledgeBlendingSegemting.TextBox37.Text = value.ee
            CodeKnowledgeBlendingSegemting.TextBox38.Text = value.aw

        Next

        Dim codeKnowledgeAdvancedPhonics = From p In dbContext.AdvancedPhonics
     Where (p.Date = dateKey And p.StudentNo = student)
                   Select p

        For Each value In codeKnowledgeAdvancedPhonics
            CodeKnowledgeBlendingSegemting.TextBox39.Text = value.ea
            CodeKnowledgeBlendingSegemting.TextBox40.Text = value.oa
            CodeKnowledgeBlendingSegemting.TextBox41.Text = value.ai

            CodeKnowledgeBlendingSegemting.TextBox42.Text = value.oi

            CodeKnowledgeBlendingSegemting.TextBox43.Text = value.ay
            CodeKnowledgeBlendingSegemting.TextBox44.Text = value.ou
            CodeKnowledgeBlendingSegemting.TextBox45.Text = value.ey
            CodeKnowledgeBlendingSegemting.TextBox46.Text = value.au
            CodeKnowledgeBlendingSegemting.TextBox47.Text = value.ew
            CodeKnowledgeBlendingSegemting.TextBox48.Text = value.igh
            CodeKnowledgeBlendingSegemting.TextBox49.Text = value.ui
            CodeKnowledgeBlendingSegemting.TextBox50.Text = value.eigh

            CodeKnowledgeBlendingSegemting.TextBox23.Text = value.x
            CodeKnowledgeBlendingSegemting.TextBox29.Text = value.ck
            CodeKnowledgeBlendingSegemting.TextBox31.Text = value.ce
        Next

        Dim blendingSummation = From p In dbContext.Blending_Summation
      Where (p.Date = dateKey And p.StudentNo = student)
                 Select p
        For Each value In blendingSummation
            CodeKnowledgeBlendingSegemting.TextBox78.Text = value.Two_Sound
            CodeKnowledgeBlendingSegemting.TextBox79.Text = value.Three_Sound
            CodeKnowledgeBlendingSegemting.TextBox80.Text = value.Four_Sound
            CodeKnowledgeBlendingSegemting.TextBox81.Text = value.Five_Sound
        Next
  
        Dim blendingtwoSounds = From p In dbContext.Blending_2snd_Words
   Where (p.Date = dateKey And p.StudentNo = student)
              Select p
        For Each value In blendingtwoSounds
            CodeKnowledgeBlendingSegemting.TextBox51.Text = value.at
            CodeKnowledgeBlendingSegemting.TextBox52.Text = value.shee
            CodeKnowledgeBlendingSegemting.TextBox53.Text = value.may
            CodeKnowledgeBlendingSegemting.TextBox54.Text = value.saw
            CodeKnowledgeBlendingSegemting.TextBox55.Text = value.it
            CodeKnowledgeBlendingSegemting.TextBox56.Text = value.fur
        Next

        Dim blendingthreeSounds = From p In dbContext.Blending_3snd_Words
  Where (p.Date = dateKey And p.StudentNo = student)
            Select p
        For Each value In blendingthreeSounds
            CodeKnowledgeBlendingSegemting.TextBox57.Text = value.pig
            CodeKnowledgeBlendingSegemting.TextBox58.Text = value.bug
            CodeKnowledgeBlendingSegemting.TextBox59.Text = value.hat
            CodeKnowledgeBlendingSegemting.TextBox60.Text = value.pin
            CodeKnowledgeBlendingSegemting.TextBox61.Text = value.rat
            CodeKnowledgeBlendingSegemting.TextBox62.Text = value.bird
            CodeKnowledgeBlendingSegemting.TextBox63.Text = value.shell
            CodeKnowledgeBlendingSegemting.TextBox64.Text = value.five
            CodeKnowledgeBlendingSegemting.TextBox65.Text = value.boat
        Next

        Dim blendingfourSounds = From p In dbContext.Blending_4snd_Words
  Where (p.Date = dateKey And p.StudentNo = student)
            Select p
        For Each value In blendingfourSounds
            CodeKnowledgeBlendingSegemting.TextBox66.Text = value.frog
            CodeKnowledgeBlendingSegemting.TextBox67.Text = value.grass
            CodeKnowledgeBlendingSegemting.TextBox68.Text = value.stick
            CodeKnowledgeBlendingSegemting.TextBox69.Text = value.jump
            CodeKnowledgeBlendingSegemting.TextBox70.Text = value.under
            CodeKnowledgeBlendingSegemting.TextBox71.Text = value.mist
        Next

        Dim blendingFiveSounds = From p In dbContext.Blending_5snd_Words
  Where (p.Date = dateKey And p.StudentNo = student)
          Select p
        For Each value In blendingFiveSounds
            CodeKnowledgeBlendingSegemting.TextBox72.Text = value.print
            CodeKnowledgeBlendingSegemting.TextBox73.Text = value.crunch
            CodeKnowledgeBlendingSegemting.TextBox74.Text = value.plant
            CodeKnowledgeBlendingSegemting.TextBox75.Text = value.stamp
            CodeKnowledgeBlendingSegemting.TextBox76.Text = value.street
            CodeKnowledgeBlendingSegemting.TextBox77.Text = value.blast
        Next

        Dim segmentingSummation = From p In dbContext.Segmenting_Summation
    Where (p.Date = dateKey And p.StudentNo = student)
               Select p
        For Each value In segmentingSummation
            CodeKnowledgeBlendingSegemting.TextBox106.Text = value.Two_Sound
            CodeKnowledgeBlendingSegemting.TextBox107.Text = value.Three_Sound
            CodeKnowledgeBlendingSegemting.TextBox108.Text = value.Four_Sound
            CodeKnowledgeBlendingSegemting.TextBox109.Text = value.Five_Sound

        Next
      
        Dim segmentingTwoSounds = From p In dbContext.Segment_2snd_Words
Where (p.Date = dateKey And p.StudentNo = student)
        Select p
        For Each value In segmentingTwoSounds
            CodeKnowledgeBlendingSegemting.TextBox82.Text = value.in
            CodeKnowledgeBlendingSegemting.TextBox83.Text = value.it
            CodeKnowledgeBlendingSegemting.TextBox84.Text = value.pie
            CodeKnowledgeBlendingSegemting.TextBox85.Text = value.eat
            CodeKnowledgeBlendingSegemting.TextBox86.Text = value.no
            CodeKnowledgeBlendingSegemting.TextBox87.Text = value.lie
        Next

        Dim segmentingThreeSounds = From p In dbContext.Segment_3snd_Words
Where (p.Date = dateKey And p.StudentNo = student)
       Select p
        For Each value In segmentingThreeSounds
            CodeKnowledgeBlendingSegemting.TextBox88.Text = value.dog
            CodeKnowledgeBlendingSegemting.TextBox89.Text = value.hat
            CodeKnowledgeBlendingSegemting.TextBox90.Text = value.pin
            CodeKnowledgeBlendingSegemting.TextBox91.Text = value.pot
            CodeKnowledgeBlendingSegemting.TextBox92.Text = value.rat
            CodeKnowledgeBlendingSegemting.TextBox93.Text = value.nut
        Next


        Dim segmentingFourSounds = From p In dbContext.Segment_4snd_Words
Where (p.Date = dateKey And p.StudentNo = student)
      Select p
        For Each value In segmentingFourSounds
            CodeKnowledgeBlendingSegemting.TextBox94.Text = value.frog
            CodeKnowledgeBlendingSegemting.TextBox95.Text = value.black
            CodeKnowledgeBlendingSegemting.TextBox96.Text = value.nest
            CodeKnowledgeBlendingSegemting.TextBox97.Text = value.trip
            CodeKnowledgeBlendingSegemting.TextBox98.Text = value.hand
            CodeKnowledgeBlendingSegemting.TextBox99.Text = value.drum
        Next


        Dim segmentingFiveSounds = From p In dbContext.Segment_5snd_Words
Where (p.Date = dateKey And p.StudentNo = student)
     Select p
        For Each value In segmentingFiveSounds
            CodeKnowledgeBlendingSegemting.TextBox100.Text = value.clasp
            CodeKnowledgeBlendingSegemting.TextBox101.Text = value.stand
            CodeKnowledgeBlendingSegemting.TextBox102.Text = value.thunder
            CodeKnowledgeBlendingSegemting.TextBox103.Text = value.ground
            CodeKnowledgeBlendingSegemting.TextBox104.Text = value.blest
            CodeKnowledgeBlendingSegemting.TextBox105.Text = value.strive
        Next



        Dim segmentingSummationNonWords = From p In dbContext.Segmenting_Summation
    Where (p.Date = dateKey And p.StudentNo = student)
               Select p
        For Each value In segmentingSummationNonWords
            CodeKnowledgeBlendingSegemting.TextBox110.Text = value.Two_snd_NonWord
            CodeKnowledgeBlendingSegemting.TextBox111.Text = value.Three_snd_NonWord
            CodeKnowledgeBlendingSegemting.TextBox112.Text = value.Four_snd_NonWord


        Next
 
      
        Dim segmentingTwoSoundsNonWords = From p In dbContext.Segment_2snd_NonWords
Where (p.Date = dateKey And p.StudentNo = student)
  Select p
        For Each value In segmentingTwoSoundsNonWords
            CodeKnowledgeBlendingSegemting.TextBox113.Text = value.ees
            CodeKnowledgeBlendingSegemting.TextBox114.Text = value.ta
            CodeKnowledgeBlendingSegemting.TextBox115.Text = value.koe
            CodeKnowledgeBlendingSegemting.TextBox116.Text = value.ip
            CodeKnowledgeBlendingSegemting.TextBox117.Text = value.ak
            CodeKnowledgeBlendingSegemting.TextBox118.Text = value.aen
        Next

        Dim segmentingThreeSoundsNonWords = From p In dbContext.Segment_3snd_NonWords
Where (p.date = dateKey And p.StudentNo = student)
Select p
        For Each value In segmentingThreeSoundsNonWords
            CodeKnowledgeBlendingSegemting.TextBox119.Text = value.pim
            CodeKnowledgeBlendingSegemting.TextBox120.Text = value.mif
            CodeKnowledgeBlendingSegemting.TextBox121.Text = value.sep

        Next

        Dim segmentingFourSoundsNonWords = From p In dbContext.Segment_4snd_NonWords
Where (p.Date = dateKey And p.StudentNo = student)
Select p
        For Each value In segmentingFourSoundsNonWords
            CodeKnowledgeBlendingSegemting.TextBox122.Text = value.flob
            CodeKnowledgeBlendingSegemting.TextBox123.Text = value.prif
            CodeKnowledgeBlendingSegemting.TextBox124.Text = value.sept

        Next

        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim selectedIndex As String = DataGridView1.CurrentRow.Cells(2).Value.ToString
        Dim dateKey As DateTime = Convert.ToDateTime(selectedIndex)

        Dim studentNo = Label4.Text.Trim()
        Dim index = DataGridView1.Columns(0).Index
        If (e.ColumnIndex = DataGridView1.Columns(0).Index And e.RowIndex >= 0) Then

            Dim dbContext As New FamilyLiteracyEntityDataModel
            Dim removeCodeKnowledge As BeginningPhonic = (From p In dbContext.BeginningPhonics
                                              Where p.Date = dateKey And p.StudentNo = studentNo
                                                Select p).First
            dbContext.BeginningPhonics.Remove(removeCodeKnowledge)
            dbContext.SaveChanges()
           
            Dim removeBlending As Blending_2snd_Words = (From p In dbContext.Blending_2snd_Words
                                              Where p.Date = dateKey And p.StudentNo = studentNo
                                                Select p).First
            dbContext.Blending_2snd_Words.Remove(removeBlending)
            dbContext.SaveChanges()
          
            Dim removeSegmenting As Segment_2snd_Words = (From p In dbContext.Segment_2snd_Words
                                             Where p.Date = dateKey And p.StudentNo = studentNo
                                               Select p).First
            dbContext.Segment_2snd_Words.Remove(removeSegmenting)
            dbContext.SaveChanges()

        End If
        CodeKnowledgeBlendingSegemting.Label121.Text = String.Empty
        CodeKnowledgeBlendingSegemting.Label128.Text = String.Empty
        DisplayCodeKnowledge()
    End Sub


End Class