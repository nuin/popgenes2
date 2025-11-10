Imports ZedGraph
Public Class FStats
    Dim fgen, nnloci, n, nplot, totalpops As Integer
    Dim m As Single
    Dim genes() As Byte
    Dim inipnuc, f, tpnuc(,,), tHi(,), tHt(,), tHs(,) As Double
    Dim pnucnew(,), sump(), sumporg(), meanfreq() As Double
    Dim nucfreq(,), nucgen1(,), nucgen2(,), nucgen3(,) As Double
    Dim Fis(,), Fit(,), Fst(,) As Double

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim i, j, g As Integer

        nnloci = Val(txt_nloci.Text)
        n = Val(txt_n.Text)
        m = Val(txt_m.Text)
        inipnuc = Val(txt_freq.Text)
        f = Val(txt_f.Text)
        fgen = Val(txt_gen.Text)
        totalpops = Val(txt_pops.Text)
        nplot = Val(txt_nplot.Text)

        ReDim tpnuc(totalpops, nnloci - 1, fgen)
        ReDim pnucnew(totalpops, nnloci - 1)
        ReDim meanfreq(nnloci - 1)

        For i = 0 To nnloci - 1
            For j = 0 To totalpops
                tpnuc(j, i, 0) = inipnuc
            Next
        Next

        ReDim tHi(nnloci - 1, fgen)
        ReDim tHs(nnloci - 1, fgen)
        ReDim tHt(nnloci - 1, fgen)
        ReDim Fis(nnloci - 1, fgen)
        ReDim Fst(nnloci - 1, fgen)
        ReDim Fit(nnloci - 1, fgen)
        ReDim nucgen1(totalpops, nnloci - 1)
        ReDim nucgen2(totalpops, nnloci - 1)
        ReDim nucgen3(totalpops, nnloci - 1)

        For i = 0 To nnloci - 1
            tHi(i, 0) = 2 * inipnuc * (1 - inipnuc)
            tHt(i, 0) = 2 * inipnuc * (1 - inipnuc)
            tHs(i, 0) = 2 * inipnuc * (1 - inipnuc)
        Next

        For i = 1 To fgen

            Call driftF(i)
            Call avgfreq()

            Call dispersal()
            Call genotypefreqs()
            Call computeH(i)

            For g = 0 To nnloci - 1
                For j = 0 To totalpops
                    tpnuc(j, g, i) = nucfreq(j, g)
                Next
            Next

        Next
        Call computeF()
        Call PlotF(auxgraph)
        Call PlotDrift(maingraph)
    End Sub

    Private Sub FStats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
        SetGraph(auxgraph)
    End Sub

    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.Max = 100
        canvas.YAxis.Scale.Max = 1
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Title.IsVisible = False
        canvas.XAxis.Title.Text = "Generations"
        zgc.Refresh()
        zgc.AxisChange()
    End Sub
    Private Sub driftF(ByVal gen As Integer)

        Randomize()
        Dim a As Single
        Dim i, j, k, dominants As Integer
        ReDim genes(n)

        For i = 0 To nnloci - 1
            For j = 0 To totalpops - 1
                For k = 1 To n * 2
                    a = Rnd(1)
                    If a < tpnuc(j, i, gen - 1) Then
                        dominants = dominants + 1
                    End If
                Next
                pnucnew(j, i) = dominants / (n * 2)
                dominants = 0
            Next
        Next

    End Sub

    Private Sub avgfreq()
        Dim j, k As Integer
        ReDim sump(nnloci - 1)
        ReDim sumporg(nnloci - 1)

        For k = 0 To nnloci - 1
            For j = 0 To totalpops - 1
                sump(k) = sump(k) + pnucnew(j, k)
            Next
            meanfreq(k) = sump(k) / totalpops
        Next
    End Sub
    Private Sub dispersal()
        Dim i, j As Integer
        ReDim nucfreq(totalpops, nnloci - 1)
        For i = 0 To nnloci - 1
            For j = 0 To totalpops - 1
                nucfreq(j, i) = pnucnew(j, i) * (1 - m) + (meanfreq(i) * m)
            Next
        Next
    End Sub
    Private Sub computeH(ByVal gen As Integer)
        Dim sum, sum2, sum3 As Double
        Dim i, j As Integer
        For i = 0 To nnloci - 1
            For j = 0 To totalpops
                sum = sum + nucgen2(j, i)
                sum2 = sum2 + (2 * pnucnew(j, i) * (1 - pnucnew(j, i)))
                sum3 = sum3 + pnucnew(j, i)
            Next
            tHi(i, gen) = sum / totalpops
            tHs(i, gen) = sum2 / totalpops
            tHt(i, gen) = sum3 / totalpops
        Next
    End Sub

    Private Sub genotypefreqs()
        Dim i, j As Integer
        For i = 0 To nnloci - 1
            For j = 0 To totalpops
                nucgen1(j, i) = pnucnew(j, i) ^ 2 * (1 - f) + pnucnew(j, i) * f
                nucgen2(j, i) = 2 * pnucnew(j, i) * (1 - pnucnew(j, i)) * (1 - f)
                nucgen3(j, i) = (1 - pnucnew(j, i)) ^ 2 * (1 - f) + (1 - pnucnew(j, i)) * f
            Next
        Next
    End Sub
    Private Sub computeF()
        Dim i, j As Integer

        For i = 1 To fgen
            For j = 0 To nnloci - 1
                If tHs(j, i) = 0 Then
                    Fis(j, i) = 0
                Else
                    Fis(j, i) = (tHs(j, i) - tHi(j, i)) / tHs(j, i)
                End If
                If tHt(j, i) = 0 Then
                    Fst(j, i) = 0
                    Fit(j, i) = 0
                Else
                    Fst(j, i) = (tHt(j, i) - tHs(j, i)) / tHt(j, i)
                    Fit(j, i) = (tHt(j, i) - tHi(j, i)) / tHt(j, i)
                End If
            Next
        Next

    End Sub

    Private Sub PlotF(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim fitpoints, fstpoints, fispoints As New PointPairList

        canvas.CurveList.Clear()

        For i = 0 To fgen
            fitpoints.Add(i, Fit(0, i))
            fstpoints.Add(i, Fst(0, i))
            fispoints.Add(i, Fis(0, i))
        Next
        Dim fitcurve As LineItem = canvas.AddCurve("Fit", fitpoints, Color.Green, SymbolType.None)
        Dim fiscurve As LineItem = canvas.AddCurve("Fis", fispoints, Color.Red, SymbolType.None)
        Dim fstcurve As LineItem = canvas.AddCurve("Fst", fstpoints, Color.Blue, SymbolType.None)

        canvas.XAxis.Scale.Max = fgen
        canvas.YAxis.Scale.Max = 1
        canvas.YAxis.Scale.Min = -1
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 15
        canvas.YAxis.Title.IsVisible = True
        canvas.YAxis.Title.Text = "F"
        zgc.Refresh()
        zgc.AxisChange()

    End Sub

    Private Sub PlotDrift(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i, j, k As Integer
        Dim genarr(fgen), poptoplot(nplot) As Double
        Dim popn As Integer

        canvas.CurveList.Clear()

        For i = 0 To nplot
            popn = Rnd() * (totalpops - 1) + 1
            poptoplot(i) = popn
        Next

        For i = 0 To fgen
            genarr(i) = i
        Next

        For i = 0 To nnloci - 1
            For j = 0 To nplot - 1
                Dim points As New PointPairList
                For k = 0 To fgen
                    points.Add(k, tpnuc(poptoplot(j), i, k))
                Next
                zgc.GraphPane.AddCurve("", points, Color.Black, SymbolType.None)
                zgc.Invalidate()
            Next
        Next
        zgc.GraphPane.XAxis.Scale.Max = fgen
        zgc.GraphPane.XAxis.MajorGrid.IsVisible = True
        zgc.Validate()
        zgc.AxisChange()

    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(maingraph)
        SetGraph(maingraph)
        ClearGraph(auxgraph)

    End Sub
    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/fstats.html")
    End Sub
End Class