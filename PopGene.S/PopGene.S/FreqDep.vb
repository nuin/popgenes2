Imports ZedGraph

Public Class FreqDep
    Dim s1, s2, s3, deltap(), p(), w1(), w2(), w3(), meanfit(), max, min As Double
    Dim gsteps As Integer

    Private Sub FreqDep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(graph1, graph2, graph3)
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        ClearGraph(graph1, graph2, graph3)
        'gsteps = Val(txt_plot.Text)
        gsteps = 100

        ReDim w1(gsteps)
        ReDim w2(gsteps)
        ReDim w3(gsteps)
        ReDim deltap(gsteps)
        ReDim p(gsteps)

        If Val(txt_s1.Text) > 1 Or Val(txt_s1.Text) < 0 Then
            MsgBox("s1 value outside boundaries. Please correct and restart")
            Exit Sub
        Else
            s1 = Val(txt_s1.Text)
        End If

        If Val(txt_s2.Text) > 1 Or Val(txt_s2.Text) < 0 Then
            MsgBox("s2 value outside boundaries. Please correct and restart")
            Exit Sub
        Else
            s2 = Val(txt_s2.Text)
        End If

        If Val(txt_s3.Text) > 1 Or Val(txt_s3.Text) < 0 Then
            MsgBox("s3 value outside boundaries. Please correct and restart")
            Exit Sub
        Else
            s3 = Val(txt_s3.Text)
        End If

        FreqDep()
        PlotPoints(graph1, graph2, graph3)
    End Sub

    Private Sub SetGraph(ByVal zgc1 As ZedGraphControl, ByVal zgc2 As ZedGraphControl, ByVal zgc3 As ZedGraphControl)

        Dim canvas1 As GraphPane = zgc1.GraphPane
        Dim canvas2 As GraphPane = zgc2.GraphPane
        Dim canvas3 As GraphPane = zgc3.GraphPane

        canvas1.XAxis.Scale.Max = 1
        canvas1.XAxis.Scale.Min = 0
        canvas1.XAxis.Title.Text = "p"
        'canvas1.YAxis.Scale.Max = 1
        'canvas1.YAxis.Scale.Min = -1
        canvas1.YAxis.Title.Text = "delta p"
        canvas1.Title.IsVisible = False

        canvas2.YAxis.Scale.Max = 1
        canvas2.YAxis.Scale.Min = 0
        canvas2.YAxis.Title.Text = "w"
        canvas2.XAxis.Title.Text = "p"
        canvas2.XAxis.Scale.Max = 1
        canvas2.XAxis.Scale.Min = 0
        canvas2.XAxis.MinorTic.IsAllTics = False
        canvas2.Title.IsVisible = False

        canvas3.YAxis.Scale.Max = 1
        canvas3.YAxis.Scale.Min = 0
        canvas3.YAxis.Title.Text = "mean fitness"
        canvas3.XAxis.Title.Text = "p"
        canvas3.XAxis.Scale.Max = 1
        canvas3.XAxis.Scale.Min = 0
        canvas3.XAxis.MinorTic.IsAllTics = False
        canvas3.Title.IsVisible = False

        canvas1.XAxis.Scale.FontSpec.Size = 12
        canvas1.YAxis.Scale.FontSpec.Size = 12

        canvas2.XAxis.Scale.FontSpec.Size = 12
        canvas2.YAxis.Scale.FontSpec.Size = 12

        canvas3.XAxis.Scale.FontSpec.Size = 12
        canvas3.YAxis.Scale.FontSpec.Size = 12
    End Sub

    Private Sub FreqDep()
        Dim i As Integer
        Dim wbar, term1, term2, term3 As Double
        ReDim meanfit(gsteps)
        Dim increment As Single

        increment = 1 / gsteps
        For i = 0 To gsteps
            p(i) = i * increment
        Next

        For i = 0 To gsteps
            w1(i) = 1 - s1 * p(i) ^ 2
            w2(i) = 1 - s2 * 2 * p(i) * (1 - p(i))
            w3(i) = 1 - s3 * (1 - p(i)) ^ 2
            wbar = w1(i) * p(i) ^ 2 + w2(i) * 2 * p(i) * (1 - p(i)) + w3(i) * (1 - p(i)) ^ 2
            If wbar > 0 Then
                'deltap(i) = (p(i) * (1 - p(i)) * sAa * ((1 - p(i)) - p(i)) * (p(i) ^ 2 - p(i) * (1 - p(i)) + (1 - p(i)) ^ 2)) / wbar
                term1 = p(i) * (1 - p(i)) * s1
                term2 = (1 - p(i)) - p(i)
                term3 = (p(i) ^ 2) - (p(i) * (1 - p(i))) + (1 - (p(i))) ^ 2
                deltap(i) = (term1 * term2 * term3) / wbar
                'termone = p(1,i)*(1-p(1,i))*sAA;
                'termtwo = (1-p(1,i)) - p(1,i);
                'termthree = p(1,i)^2 - p(1,i)*(1-p(1,i)) + (1-p(1,i))^2;
            Else
                deltap(i) = 0
            End If
            meanfit(i) = wbar
        Next
    End Sub

    Private Sub PlotPoints(ByVal zgc1 As ZedGraphControl, ByVal zgc2 As ZedGraphControl, ByVal zgc3 As ZedGraphControl)

        Dim i As Integer
        Dim canvas1 As GraphPane = zgc1.GraphPane
        Dim canvas2 As GraphPane = zgc2.GraphPane
        Dim canvas3 As GraphPane = zgc3.GraphPane
        Dim meancurve, deltacurve As New PointPairList
        Dim w1curve, w2curve, w3curve As New PointPairList

        max = 0
        min = 0

        For i = 0 To 100
            If deltap(i) <= min Then min = deltap(i)
            If deltap(i) >= max Then max = deltap(i)
        Next

        For i = 0 To gsteps
            meancurve.Add(i / 100, meanfit(i))
            w1curve.Add(i / 100, w1(i))
            w2curve.Add(i / 100, w2(i))
            w3curve.Add(i / 100, w3(i))
            deltacurve.Add(i / 100, deltap(i))

            '    If max < 0.1 Then
            '    pct_graph1.Line (1 / gsteps * (i - 1), 0.5 - (5 * deltap(i - 1)))-(1 / gsteps * i, 0.5 - (5 * deltap(i)))
            '    Else
            '    pct_graph1.Line (1 / gsteps * (i - 1), 0.5 - (10 * max * deltap(i - 1)))-(1 / gsteps * i, 0.5 - (10 * max * deltap(i)))
            '    End If
            '    'pct_graph2.PSet (1 / gsteps * (i - 1), 1 - w1(i - 1))
            '    'pct_graph2.PSet (1 / gsteps * (i - 1), 1 - w2(i - 1))
            '    'pct_graph2.PSet (1 / gsteps * (i - 1), 1 - w3(i - 1))
            '    'pct_graph2.Line (1 / gsteps * (i - 1), 1 - w2(i - 1))-(1 / gsteps * i, w2(i))
            '    'pct_graph2.Line (1 / gsteps * (i - 1), 1 - w3(i - 1))-(1 / gsteps * i, w3(i))
        Next

        Dim deltac As CurveItem = canvas1.AddCurve("", deltacurve, Color.Black, SymbolType.None)
        Dim w1c As CurveItem = canvas2.AddCurve("w1", w1curve, Color.Red, SymbolType.None)
        Dim w2c As CurveItem = canvas2.AddCurve("w2", w2curve, Color.Blue, SymbolType.None)
        Dim w3c As CurveItem = canvas2.AddCurve("w3", w3curve, Color.Green, SymbolType.None)
        Dim mcurve As CurveItem = canvas3.AddCurve("", meancurve, Color.DarkGray, SymbolType.None)
        zgc1.AxisChange()
        zgc1.Refresh()
        zgc2.AxisChange()
        zgc2.Refresh()
        zgc3.AxisChange()
        zgc3.Refresh()

    End Sub

    Private Sub ClearGraph(ByVal zgc1 As ZedGraphControl, ByVal zgc2 As ZedGraphControl, ByVal zgc3 As ZedGraphControl)
        zgc1.GraphPane.CurveList.Clear()
        zgc1.Refresh()
        zgc2.GraphPane.CurveList.Clear()
        zgc2.Refresh()
        zgc3.GraphPane.CurveList.Clear()
        zgc2.Refresh()
    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(graph1, graph2, graph3)
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/freqdep.html")
    End Sub
End Class