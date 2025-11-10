Imports ZedGraph
Public Class IrMut
    Dim rate_m, rate_v, freqs_mut() As Double
    Dim gen As Integer

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        gen = Val(txt_gen.Text)

        If Val(txt_p.Text) < 0 Or Val(txt_p.Text) > 1 Then
            MsgBox("Frequency value incorrect", 64, "Mutation")
            txt_p.Text = ""
            txt_p.Focus()
            Exit Sub
        End If
        If Val(txt_rate_m.Text) < 0 Or Val(txt_rate_m.Text) > 1 Then
            MsgBox("Mutation rate incorrect", 64, "Mutation")
            txt_rate_m.Text = ""
            txt_rate_m.Focus()
            Exit Sub
        End If

        ReDim freqs_mut(gen)

        freqs_mut(0) = Val(txt_p.Text)
        rate_m = Val(txt_rate_m.Text)

        Call mutation_calc()
        Call PlotGraph(maingraph)
        fra_values.Visible = True

        lbl_p.Text = Format(freqs_mut(gen), "0.00000000")
        lbl_q.Text = Format(1 - freqs_mut(gen), "0.00000000")
        'Call captions_mutation()
        cmd_save.Enabled = True
    End Sub

    Private Sub mutation_calc()
        Dim i As Integer
        For i = 1 To gen
            freqs_mut(i) = (rate_v / (rate_v + rate_m)) + (freqs_mut(i - 1) - (rate_v / (rate_v + rate_m))) * (1 - rate_m - rate_v)
        Next
    End Sub
    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.Max = 100
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Scale.Min = 0
        canvas.YAxis.Scale.Max = 1
        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "p"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()

    End Sub

    Private Sub IrMut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
    End Sub

    Private Sub PlotGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim pfreq As New PointPairList

        For i = 0 To gen
            pfreq.Add(i, freqs_mut(i))
        Next
        Dim cont As LineItem = canvas.AddCurve("", pfreq, Color.Red, SymbolType.None)

        canvas.XAxis.Scale.Max = gen
        zgc.Refresh()
        zgc.AxisChange()

    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(maingraph)
        SetGraph(maingraph)
        fra_values.Visible = False
    End Sub
    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub

    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        Dim i As Integer

        With dlg_save
            .DefaultExt = ".txt"
            .OverwritePrompt = True
            .Filter = "All files|*.*|Text files (*.txt)|*.txt"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objWriter As New System.IO.StreamWriter(.FileName)
                objWriter.WriteLine("Irreversible Mutation")
                objWriter.WriteLine("Number of generations : " & gen)
                objWriter.WriteLine("Mutation rate (A -> a) = " & rate_m)

                objWriter.WriteLine()
                objWriter.WriteLine()

                objWriter.WriteLine("gen." & vbTab & "p")
                For i = 0 To gen
                    objWriter.WriteLine(i & vbTab & freqs_mut(i), "0.00000000")
                Next
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/irreversible.html")
    End Sub
End Class