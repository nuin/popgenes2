Imports ZedGraph
Imports System.Math
Public Class Muller
    Dim meanfamilysize, maxfamilysize, cats(), popsize As Integer
    Dim mutovergens(,) As Integer
    Dim factresult(200) As Double
    Dim probfamsize(100) As Double
    Dim sumholder As Double
    Dim gen As Integer

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        Randomize()
        Dim i, j, k, c1, c2, m, t As Integer
        'Dim generations As Integer = 200
        'Dim N As Integer = 20
        'Dim loci As Integer = 10
        'Dim s As Double = 0.01
        'Dim mu As Double = 0.06

        Dim generations As Integer
        Dim N As Integer
        Dim loci As Integer
        Dim s As Double
        Dim mu As Double

        N = Val(txt_haploid.Text)
        generations = Val(txt_generation.Text)
        loci = Val(txt_loci.Text)
        s = Val(txt_s.Text)
        mu = Val(txt_m.Text)

        popsize = N
        Dim population(N, loci, generations) As Integer
        Dim mutcount(N) As Integer

        Dim fitness(N) As Integer
        Dim progeny2(N, loci) As Integer
        Dim progenylist(N) As Integer
        ReDim mutovergens(N, generations)
        Dim totalmuts As Integer
        Dim nummuts As Integer
        Dim randindivid As Integer
        Dim randlocus As Integer
        Dim pparent As Integer
        Dim prob As Double
        Dim famsize As Integer
        Dim start As Integer


        meanfamilysize = 1
        maxfamilysize = 10
        Dim cumprob(maxfamilysize) As Double

        factresult(0) = 1
        factresult(1) = 1
        For i = 2 To maxfamilysize
            factresult(i) = factresult(i - 1) * i
        Next
        For i = 0 To maxfamilysize
            probfamsize(i) = ((meanfamilysize ^ (i)) * (2.71828183 ^ (-meanfamilysize))) / factresult(i)
        Next

        Dim sumholder As Double
        For i = 0 To maxfamilysize
            sumholder = sumholder + probfamsize(i)
            cumprob(i) = sumholder
        Next

        'main loop
        For i = 1 To generations - 1
            If (N * mu >= 1.0) Then
                nummuts = Round(N * mu)
            ElseIf N * mu >= Rnd() Then
                nummuts = 1
            Else
                nummuts = 0
            End If

            For j = 1 To nummuts

                randindivid = Round(Rnd() * (N - 1) + 1)
                randlocus = Round(Rnd() * (loci - 1) + 1)

                If population(randindivid, randlocus, i) = 0 Then
                    population(randindivid, randlocus, i) = 1
                Else
                    j = j - 1
                End If
                For m = 0 To N
                    For t = 0 To loci
                        mutcount(m) = mutcount(m) + population(m, t, i)
                    Next
                Next

                For m = 0 To N
                    totalmuts = totalmuts + mutcount(m)
                Next

                If totalmuts = N * loci Then
                    'MsgBox("all loci have a mutation, exiting loop")
                    Exit For
                End If
            Next

            For m = 0 To N
                mutovergens(m, i) = mutovergens(m, i) + mutcount(m)
            Next

            For m = 0 To N
                fitness(m) = (1 - s) ^ mutcount(m)
            Next

            Dim progeny As Integer
            progeny = 1
            pparent = 1
            While progeny <= N

                If Rnd() <= fitness(pparent) Then
                    prob = Rnd()
                    For k = 1 To maxfamilysize
                        If prob <= cumprob(k) Then
                            famsize = k - 1
                            Exit For
                        End If
                    Next
                End If
                start = progeny
                For k = start To (start + famsize - 1)
                    If (k <= N) Then
                        progenylist(k) = pparent
                        progeny = progeny + 1
                    Else
                        Exit For
                    End If
                Next
                If pparent < N Then
                    pparent = pparent + 1
                Else
                    pparent = 1
                End If
            End While

            For j = 1 To N
                pparent = progenylist(j)
                For k = 1 To loci
                    progeny2(j, k) = population(pparent, k, i)
                Next
            Next
            For c1 = 0 To N
                For c2 = 0 To loci
                    population(c1, c2, i + 1) = progeny2(c1, c2)
                Next
            Next
            totalmuts = 0
            For m = 0 To N
                mutcount(m) = 0
            Next

        Next

        PlotGraphs(graph1, 0)
        PlotGraphs(graph2, generations / 3)
        PlotGraphs(graph3, (generations * 2) / 3)
        PlotGraphs(graph4, generations - 1)

    End Sub
    Private Sub OLD()

        Randomize()
        Dim s As Double
        Dim mu As Double
        Dim loci As Integer
        Dim nummuts As Integer
        Dim randind As Integer
        Dim randloci As Integer
        Dim totalmuts As Double
        Dim parent As Integer
        Dim i, j, k, m As Integer
        Dim nmut As Integer

        gen = Val(txt_generation.Text)
        s = Val(txt_s.Text)
        mu = Val(txt_m.Text)
        popsize = Val(txt_haploid.Text)
        loci = Val(txt_loci.Text)
        meanfamilysize = 1
        maxfamilysize = 10

        Dim mutovergens(popsize, gen) As Integer
        Dim mutcount(popsize) As Integer
        Dim mutcountFoo(popsize) As Integer
        Dim fitness(popsize) As Double
        Dim cumprob(maxfamilysize) As Double
        Dim progenylist(popsize) As Integer
        Dim pop(popsize, loci, gen + 1) As Integer
        Dim progenyCounter As Integer
        Dim parentCounter As Integer
        Dim prob As Double
        Dim start As Integer
        Dim famsize As Integer
        'pgb_muller.max = gen
        'pgb_muller.Value = 0

        For i = 0 To popsize
            fitness(i) = 1
        Next

        factresult(0) = 1
        factresult(1) = 1
        For i = 2 To maxfamilysize
            factresult(i) = factresult(i - 1) * i
        Next

        For i = 0 To maxfamilysize
            probfamsize(i) = ((meanfamilysize ^ (i)) * (2.71828183 ^ (-meanfamilysize))) / factresult(i)
        Next

        sumholder = 0
        For i = 0 To maxfamilysize
            sumholder = sumholder + probfamsize(i)
            cumprob(i) = sumholder
        Next

        For i = 1 To gen + 1
            If popsize * mu >= 1 Then
                nummuts = Round(popsize * mu)
            ElseIf popsize * mu >= Rnd() Then
                nummuts = 1
            Else
                nummuts = 0
            End If

            While nmut < nummuts
                randind = Round(Rnd() * (popsize - 1) + 1)
                randloci = Round(Rnd() * (loci - 1) + 1)

                If pop(randind, randloci, i) = 0 Then
                    pop(randind, randloci, i) = 1
                    nmut = nmut + 1
                End If
                For k = 0 To popsize
                    mutcount(k) = 0
                Next
                For k = 0 To popsize
                    For m = 0 To loci
                        mutcount(k) = mutcount(k) + pop(k, m, i)
                    Next
                Next
                For k = 0 To popsize
                    totalmuts = totalmuts + mutcount(k)
                Next

                If totalmuts = popsize * loci Then
                    nmut = nummuts
                End If
            End While
            nmut = 0
            For k = 0 To popsize
                mutovergens(k, i - 1) = mutcount(k)
                fitness(k) = (1 - s) ^ mutcount(k)
            Next

            progenyCounter = 1
            parentCounter = 1

            While progenyCounter < popsize
                If Rnd() <= fitness(parent) Then
                    prob = Rnd()
                    For k = 1 To maxfamilysize + 1
                        If prob <= cumprob(k) Then
                            famsize = k - 1
                            Exit For
                        End If
                    Next
                    start = progenyCounter
                    For k = start To start + famsize - 1
                        If k <= popsize Then
                            'progenylist(k) = parentCounter
                            progenyCounter = progenyCounter + 1
                        Else
                            Exit For
                        End If
                    Next
                End If

                If parent < popsize Then
                    parent = parent + 1
                Else
                    parent = 1
                End If
            End While

            For j = 1 To popsize
                'parent = progenylist(j)
                For k = 1 To loci
                    'progenylist(j, k) = pop(parent, k, i)
                Next
            Next
            If i <= gen Then
                For k = 0 To popsize
                    For m = 0 To loci
                        'pop(k, m, i + 1) = progenylist(k, m)
                    Next
                Next
                'pgb_muller.Value = pgb_muller.Value + 1
            End If
        Next

        PlotGraphs(graph1, 6)
        'Call plot(popsize, gen)
        'Call fillpick(gen)
        'lbl_pick.Visible = True0
        'cmb_pick.Visible = True

    End Sub

    Private Sub PlotGraphs(ByVal zgc As ZedGraphControl, ByVal gen As Integer)

        Dim i, j As Integer
        ReDim cats(10)
        Dim canvas As GraphPane = zgc.GraphPane
        Dim plist1 As New PointPairList
        Dim category As Integer

        canvas.CurveList.Clear()

        For j = 0 To popsize
            category = (mutovergens(j, gen) / popsize) * 10
            Select Case category
                Case 0
                    cats(0) = cats(0) + 1
                Case 1
                    cats(1) = cats(1) + 1
                Case 2
                    cats(2) = cats(2) + 1
                Case 3
                    cats(3) = cats(3) + 1
                Case 4
                    cats(4) = cats(4) + 1
                Case 5
                    cats(5) = cats(5) + 1
                Case 6
                    cats(6) = cats(6) + 1
                Case 7
                    cats(7) = cats(7) + 1
                Case 8
                    cats(8) = cats(8) + 1
                Case 9
                    cats(9) = cats(9) + 1
                Case 10
                    cats(10) = cats(10) + 1
            End Select
            If mutovergens(j, gen) > popsize Then
                cats(10) = cats(10) + 1
            End If
        Next
        If cats(0) = 1 Then
            cats(0) = 0
        End If

        For i = 0 To 10
            plist1.Add(i, cats(i))
        Next
        canvas.Title.IsVisible = False

        canvas.YAxis.Title.IsVisible = False
        'canvas.Chart.Fill = New Fill(Color.White, Color.SteelBlue, 45.0F)
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.Legend.FontSpec.Size = 14
        canvas.Legend.Border.IsVisible = False

        canvas.Title.IsVisible = True
        canvas.Title.Text = "Generation " + gen.ToString

        Dim myCurve1 As BarItem = canvas.AddBar("Number of haploid individuals", plist1, Color.Black)

        canvas.XAxis.MajorTic.IsBetweenLabels = True
        canvas.XAxis.Type = AxisType.Text
        canvas.XAxis.Title.Text = "Number of mutations per genome"

        zgc.AxisChange()
        zgc.Refresh()

    End Sub
    Private Sub Muller_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetGraphs(graph1)
        SetGraphs(graph2)
        SetGraphs(graph3)
        SetGraphs(graph4)

    End Sub
    Private Sub SetGraphs(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.XAxis.Title.Text = ""
        canvas.YAxis.Title.Text = ""
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/muller.html")
    End Sub
End Class