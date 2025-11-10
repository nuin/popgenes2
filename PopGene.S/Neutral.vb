Imports ZedGraph
Public Class Neutral
    Dim mutgen, ne, sawmuts, inter, nmuts, oldgen As Integer
    Dim values(,) As Double

    Private Sub Neutral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call SetGraph(maingraph)
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        If Val(txt_ne.Text) > 0 Then
            ne = Val(txt_ne.Text)
        End If
        If Val(txt_int.Text) > 0 Then
            inter = Val(txt_int.Text)
        End If

        mutgen = Val(txt_gen.Text)

        nmuts = Int(mutgen / inter)
        ReDim values(nmuts, mutgen + 1)
        Call mutPoints()
        Call driftMut()

        Call PlotGraph(maingraph)

    End Sub
    Private Sub driftMut()

        Randomize()
        Dim a As Single
        Dim i, j, k, dominants As Integer
        
        values(0, 0) = 1 / (2 * ne)
        For i = 0 To nmuts
            For j = i * inter + 1 To mutgen
                For k = 1 To ne
                    a = Rnd(1)
                    If a < values(i, j - 1) Then
                        dominants = dominants + 1
                    End If
                Next
                values(i, j) = dominants / ne
                dominants = 0
            Next
        Next

    End Sub

    Private Sub mutPoints()
        Dim i As Integer
        sawmuts = 0

        For i = 1 To mutgen
            If i Mod inter = 0 Then
                sawmuts = sawmuts + 1
                values(sawmuts, i) = 1 / (2 * ne)
            End If
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

    Private Sub PlotGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        Dim i, j As Integer
        Dim mutcurve As New PointPairList

        For i = 0 To nmuts
            Dim points As New PointPairList
            Dim rcolor As Integer = Rnd() * 255
            Dim rcolor2 As Integer = Rnd() * 255
            Dim rcolor3 As Integer = Rnd() * 255
            For j = 1 To mutgen
                points.Add(j, values(i, j))
            Next
            zgc.GraphPane.AddCurve("", points, Color.FromArgb(rcolor, rcolor2, rcolor3), SymbolType.None)
            zgc.Invalidate()
        Next

        zgc.GraphPane.XAxis.Scale.Max = mutgen
        zgc.GraphPane.XAxis.MajorGrid.IsVisible = True
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

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/neutral.html")
    End Sub
End Class