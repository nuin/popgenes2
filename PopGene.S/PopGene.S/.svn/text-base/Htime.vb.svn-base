Imports ZedGraph
Public Class Htime
    Dim hgens(), drift_values(,), h_drift(,), multidrift(,) As Double
    Dim gen, ne, ndrift As Integer
    Dim p, h As Single

    Private Sub Htime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGraph(maingraph)
    End Sub

    Private Sub chk_drift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_drift.CheckedChanged
        If chk_drift.Checked = True Then
            l8.Enabled = True
            txt_drift.Enabled = True
            txt_drift.Focus()
        Else
            l8.Enabled = False
            txt_drift.Enabled = False
        End If
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim i, j As Integer

        ndrift = 0
        gen = Val(txt_gen.Text)

        p = Val(txt_p.Text)
        If p > 0.5 Then
            MsgBox("P(A) must be between 0 and 0.5")
            Exit Sub
        ElseIf p < 0 Then
            MsgBox("P(A) must be greater than 0")
            Exit Sub
        End If

        ne = Val(txt_size.Text)
        If txt_drift.Enabled = True Then
            ndrift = Val(txt_drift.Text)
        End If

        If ndrift > 0 Then
            ReDim multidrift(ndrift - 1, gen)
        ElseIf ndrift > 16 Then
            MsgBox("Maximum number of populations is 16")
            ndrift = 16
        End If

        ReDim hgens(gen)

        hgens(0) = 2 * p * (1 - p)
        For i = 0 To ndrift - 1
            multidrift(i, 0) = hgens(0)
        Next

        For i = 1 To gen
            hgens(i) = hgens(i - 1) * (1 - (1 / (2 * ne)))
        Next

        If ndrift > 0 Then
            For i = 0 To ndrift - 1
                Call driftCurve()
                For j = 1 To gen
                    multidrift(i, j) = h_drift(i, j)
                Next
            Next
            Call PlotDrift(maingraph)
        End If

        Call PlotH(maingraph)
        cmd_save.Enabled = True
    End Sub
    Private Sub driftCurve()
        Randomize()

        ReDim drift_values(ndrift, gen)
        ReDim h_drift(ndrift, gen)
        Dim a As Single
        Dim drift_d, drift_r As Integer
        Dim dominants As Integer
        Dim i, j, k As Integer
        
        For i = 0 To ndrift - 1
            drift_values(i, 0) = p
            h_drift(i, 0) = 2 * drift_values(i, 0) * (1 - drift_values(i, 0))
        Next

        For j = 0 To ndrift - 1
            For i = 1 To gen
                For k = 1 To ne
                    a = Rnd(1)
                    If a < drift_values(j, i - 1) Then
                        dominants = dominants + 1
                    End If
                Next
                drift_values(j, i) = dominants / ne
                h_drift(j, i) = 2 * drift_values(j, i) * (1 - drift_values(j, i))
                dominants = 0
                drift_r = 0
                drift_d = 0
            Next
        Next
        'pct_h.DrawWidth = 1
    End Sub

    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.YAxis.Scale.Max = 1
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.Scale.Max = 100
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Title.Text = "H"
        canvas.XAxis.Title.Text = "Generations"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub

    Private Sub PlotH(ByVal zgc As ZedGraphControl)

        Dim i As Integer
        Dim hpoints As New PointPairList
        Dim canvas As GraphPane = zgc.GraphPane

        For i = 1 To gen
            hpoints.Add(i, hgens(i))
        Next
        canvas.XAxis.Scale.Max = gen
        Dim hcurve As LineItem = canvas.AddCurve("Ht = Ht - 1(1-1/(2Ne))", hpoints, Color.Black, SymbolType.Square)

        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False
        hcurve.Symbol.Size = 2

        zgc.Refresh()
        zgc.AxisChange()

    End Sub
    Private Sub PlotDrift(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i, j As Integer
        Dim genarr(gen) As Double

        For i = 0 To gen
            genarr(i) = i
        Next

        For i = 0 To ndrift - 1
            Dim points As New PointPairList
            Dim rcolor As Integer = Rnd() * 255
            Dim rcolor2 As Integer = Rnd() * 255
            Dim rcolor3 As Integer = Rnd() * 255
            For j = 0 To gen
                points.Add(j, h_drift(i, j))
            Next
            zgc.GraphPane.AddCurve("", points, Color.FromArgb(rcolor, rcolor2, rcolor3), SymbolType.None)
            zgc.Invalidate()
        Next
        zgc.GraphPane.XAxis.Scale.Max = gen

        zgc.Validate()
        zgc.AxisChange()

    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(maingraph)
        SetGraph(maingraph)
    End Sub
    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub

    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        Dim i, j As Integer

        With dlg_save
            .DefaultExt = ".txt"
            .OverwritePrompt = True
            .Filter = "All files|*.*|Text files (*.txt)|*.txt"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objWriter As New System.IO.StreamWriter(.FileName)
                objWriter.WriteLine("H decay over time")
                objWriter.WriteLine("Effective population size : " & ne)
                objWriter.WriteLine("Number of generations : " & gen)

                objWriter.WriteLine()
                objWriter.WriteLine()

                objWriter.Write("gen." & vbTab & "H" & vbTab)
                For i = 1 To ndrift
                    objWriter.Write("Drift " & i & vbTab)
                Next
                objWriter.WriteLine()
                For i = 0 To gen
                    objWriter.Write(i & vbTab & Format(hgens(i), "0.0000") & vbTab)
                    For j = 0 To ndrift - 1
                        objWriter.Write(Format(multidrift(j, i), "0.0000") & vbTab)
                    Next

                    objWriter.WriteLine()
                Next
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/hdecline.html")
    End Sub
End Class