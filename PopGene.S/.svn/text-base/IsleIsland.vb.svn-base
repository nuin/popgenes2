Imports ZedGraph

Public Class IsleIsland
    Dim m1, m2, p1, p2, q1, q2 As Single
    Dim pisland1(), pisland2() As Double
    Dim twogen As Integer
    Private Sub IsleIsland_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
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

    Private Sub PlotGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim island1pop, island2pop As New PointPairList

        For i = 0 To twogen
            island1pop.Add(i, pisland1(i))
            island2pop.Add(i, pisland2(i))
        Next
        Dim cont As LineItem = canvas.AddCurve("Island1", island1pop, Color.Red, SymbolType.None)
        Dim isle As LineItem = canvas.AddCurve("Island2", island2pop, Color.Blue, SymbolType.None)
        canvas.XAxis.Scale.Max = twogen
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub

    Private Sub IslandIsland()

        Dim pbar As Double
        Dim i As Integer
        ReDim pisland1(twogen)
        ReDim pisland2(twogen)

        pisland1(0) = p1
        pisland2(0) = p2

        pbar = (p1 * m2 + p2 * m1) / (m1 + m2)

        'for i=2:time+1
        '  p1overt(1,i) = pbar + ((1-m1)^i)*(p1zero - pbar);
        '   p2overt(1,i) = pbar + ((1-m2)^i)*(p2zero - pbar);

        For i = 1 To twogen
            pisland1(i) = pbar + ((1 - m1) ^ i) * (p1 - pbar)
            pisland2(i) = pbar + ((1 - m2) ^ i) * (p2 - pbar)
        Next

    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        If Val(txt_island1.Text) >= 0 And Val(txt_island1.Text) <= 1 Then
            p1 = Val(txt_island1.Text)
        Else
            MsgBox("p1 should be between 0 and 1. Please restart")
            txt_island1.Focus()
            txt_island1.Text = ""
            Exit Sub
        End If

        If Val(txt_island2.Text) >= 0 And Val(txt_island2.Text) <= 1 Then
            p2 = Val(txt_island2.Text)
        Else
            MsgBox("p2 should be between 0 and 1. Please restart")
            txt_island2.Focus()
            txt_island2.Text = ""
            Exit Sub
        End If

        If Val(txt_m1.Text) >= 0 And Val(txt_m1.Text) <= 1 Then
            m1 = Val(txt_m1.Text)
        Else
            MsgBox("m1 should be between 0 and 1. Please restart")
            txt_m1.Focus()
            txt_m1.Text = ""
            Exit Sub
        End If

        If Val(txt_m2.Text) >= 0 And Val(txt_m2.Text) <= 1 Then
            m2 = Val(txt_m2.Text)
        Else
            MsgBox("m2 should be between 0 and 1. Please restart")
            txt_m2.Focus()
            txt_m2.Text = ""
            Exit Sub
        End If

        twogen = Val(txt_gen.Text)
        Call IslandIsland()
        Call captions_twoisland()
        Call PlotGraph(maingraph)
        fra_values.Visible = True
        cmd_save.Enabled = True
    End Sub
    Private Sub captions_twoisland()

        lbl_i1p.Text = Format(pisland1(twogen), "0.0000")
        lbl_i1p2.Text = Format(pisland1(twogen) ^ 2, "0.0000")
        lbl_i12pq.Text = Format(pisland1(twogen) * 2 * (1 - pisland1(twogen)), "0.0000")
        lbl_i1q2.Text = Format((1 - pisland1(twogen)) * (1 - pisland1(twogen)), "0.0000")

        lbl_i2p.Text = Format(pisland2(twogen), "0.0000")
        lbl_i2p2.Text = Format(pisland2(twogen) ^ 2, "0.0000")
        lbl_i22pq.Text = Format(pisland2(twogen) * 2 * (1 - pisland2(twogen)), "0.0000")
        lbl_i2q2.Text = Format((1 - pisland2(twogen)) * (1 - pisland2(twogen)), "0.0000")

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
                objWriter.WriteLine("Island-island model of migration")
                objWriter.WriteLine("Initial island 1 allele frequency p : " & Format(p1, "0.0000"))
                objWriter.WriteLine("Initial island 2 allele frequency p : " & Format(p2, "0.0000"))
                objWriter.WriteLine("Migration rate island 1 -> island 2: " & Format(m1, "0.0000"))
                objWriter.WriteLine("Migration rate island 2 -> island 1: " & Format(m2, "0.0000"))
                objWriter.WriteLine("Number of generations : " & twogen)
                objWriter.WriteLine()
                objWriter.WriteLine("gen." & vbTab & "p island 1." & vbTab & "p island 2")
                objWriter.WriteLine()
                For i = 0 To twogen
                    objWriter.WriteLine(i & vbTab & Format(pisland1(i), "0.0000") & vbTab & _
                    Format(pisland2(i), "0.0000") & vbTab)
                    objWriter.WriteLine()
                Next
                objWriter.Close()
            End If
        End With
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/islandisland.html")
    End Sub
End Class