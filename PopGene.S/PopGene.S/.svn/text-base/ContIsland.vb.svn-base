Imports ZedGraph
Public Class ContIsland
    Dim islandfreq, contfreq, mcont, pisland(), pcontinent() As Double
    Dim gentorun_contisland As Integer

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        If Val(txt_continent.Text) >= 0 And Val(txt_continent.Text) <= 1 Then
            contfreq = Val(txt_continent.Text)
        Else
            MsgBox("Value of continent allele frequency is invalid. Please restart")
            txt_continent.Focus()
            txt_continent.Text = ""
            Exit Sub
        End If

        If Val(txt_island.Text) >= 0 And Val(txt_island.Text) <= 1 Then
            islandfreq = Val(txt_island.Text)
        Else
            MsgBox("Value of island allele frequency is invalid. Please restart")
            txt_island.Focus()
            txt_island.Text = ""
            Exit Sub
        End If

        If Val(txt_m.Text) >= 0 And Val(txt_m.Text) <= 1 Then
            mcont = Val(txt_m.Text)
        Else
            MsgBox("Value of migration rate is invalid. Please restart")
            txt_m.Focus()
            txt_m.Text = ""
            Exit Sub
        End If

        gentorun_contisland = Val(txt_gen.Text)

        Call constisland(contfreq, islandfreq, mcont)
        Call captions_contisland()
        Call PlotGraph(maingraph)
        fra_values.Visible = True
        cmd_save.Enabled = True
    End Sub

    Private Sub constisland(ByVal contfreq As Double, ByVal islandfreq As Double, ByVal mcont As Double)

        ReDim pisland(gentorun_contisland)
        ReDim pcontinent(gentorun_contisland)
        Dim i As Integer

        For i = 0 To gentorun_contisland
            pcontinent(i) = contfreq
        Next

        pisland(0) = islandfreq

        ' freqsovert(:,1).*(1-m)^i + pc.*(1-(1-m)^i);

        For i = 1 To gentorun_contisland
            pisland(i) = pisland(0) * (1 - mcont) ^ i + pcontinent(i) * (1 - (1 - mcont) ^ i)
        Next
    End Sub
    Private Sub captions_contisland()

        lbl_cp.Text = Format(pcontinent(gentorun_contisland), "0.0000")
        lbl_cp2.Text = Format(pcontinent(gentorun_contisland) ^ 2, "0.0000")
        lbl_c2pq.Text = Format(pcontinent(gentorun_contisland) * 2 * (1 - pcontinent(gentorun_contisland)), "0.0000")
        lbl_cq2.Text = Format((1 - pcontinent(gentorun_contisland)) * (1 - pcontinent(gentorun_contisland)), "0.0000")

        lbl_ip.Text = Format(pisland(gentorun_contisland), "0.0000")
        lbl_ip2.Text = Format(pisland(gentorun_contisland) ^ 2, "0.0000")
        lbl_i2pq.Text = Format(pisland(gentorun_contisland) * 2 * (1 - pisland(gentorun_contisland)), "0.0000")
        lbl_iq2.Text = Format((1 - pisland(gentorun_contisland)) * (1 - pisland(gentorun_contisland)), "0.0000")

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
        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False
        'canvas.Legend.Position = LegendPos.BottomFlushLeft
        zgc.Refresh()
        zgc.AxisChange()
    End Sub

    Private Sub PlotGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim continentpop, islandpop As New PointPairList

        For i = 0 To gentorun_contisland
            continentpop.Add(i, pcontinent(i))
            islandpop.Add(i, pisland(i))
        Next
        Dim cont As LineItem = canvas.AddCurve("Continent", continentpop, Color.Red, SymbolType.None)
        Dim isle As LineItem = canvas.AddCurve("Island", islandpop, Color.Blue, SymbolType.None)
        canvas.XAxis.Scale.Max = gentorun_contisland
        zgc.Refresh()
        zgc.AxisChange()
    End Sub

    Private Sub ContIsland_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
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
                objWriter.WriteLine("Continent-island model of migration")
                objWriter.WriteLine("Initial continent allele frequency p : " & Format(contfreq, "0.0000"))
                objWriter.WriteLine("Initial island allele frequency p : " & Format(islandfreq, "0.0000"))
                objWriter.WriteLine("Migration rate : " & Format(mcont, "0.0000"))
                objWriter.WriteLine("Number of generations : " & gentorun_contisland)
                objWriter.WriteLine()
                objWriter.WriteLine("gen." & vbTab & "p Cont." & vbTab & "p Island")
                objWriter.WriteLine()
                For i = 0 To gentorun_contisland
                    objWriter.WriteLine(i & vbTab & Format(pcontinent(i), "0.0000") & vbTab & _
                    Format(pisland(i), "0.0000") & vbTab)
                    objWriter.WriteLine()
                Next
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/contisland.html")
    End Sub
End Class