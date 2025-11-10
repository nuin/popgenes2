Imports ZedGraph
Public Class AssortD
    Dim assortmodel, v, gentorun As Integer
    Dim assort_values_d(), assort_values_h() As Double
    Dim ever_run As Boolean
    Dim pointsD As Boolean
    Private Sub Assort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
    End Sub
    Private Sub SetGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim parabola, baseline, side1, side2 As New PointPairList
        Dim i As Double

        canvas.XAxis.IsVisible = False
        canvas.YAxis.IsVisible = False
        canvas.Title.IsVisible = False

        canvas.XAxis.Scale.Max = 1.1
        canvas.XAxis.Scale.Min = -0.1

        canvas.YAxis.Scale.Max = 1.1
        canvas.YAxis.Scale.Min = -0.1

        baseline.Add(0, 0)
        baseline.Add(1, 0)
        Dim base As LineItem = canvas.AddCurve("", baseline, Color.Black, SymbolType.None)

        side1.Add(0.5, 1)
        side1.Add(1, 0)
        Dim s1 As LineItem = canvas.AddCurve("", side1, Color.Black, SymbolType.None)

        side2.Add(0, 0)
        side2.Add(0.5, 1)
        Dim s2 As LineItem = canvas.AddCurve("", side2, Color.Black, SymbolType.None)

        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        For i = 0 To 1 Step 1 / 1000
            parabola.Add(i, 2 * i * (1 - i))
            'frm_panmixia.pct_triangle.PSet (d_parabola, 1 - h_parabola), RGB(100, 100, 100)
        Next

        Dim parab As LineItem = canvas.AddCurve("", parabola, Color.Gray, SymbolType.None)

        zgc.Refresh()
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim d, h, dplot As Double
        Dim result As Integer

        'assortmodel = 12

        If ever_run = False Then ever_run = True

        If chk_points.Checked = True Then pointsD = True

        'initial value o error verif. variable
        result = 0

        'takes the values inside the text boxes
        d = Val(txt_d.Text)
        h = Val(txt_h.Text)
        dplot = d + h / 2

        If txt_d.Text = "" Then txt_d.Text = "0"
        If txt_h.Text = "" Then txt_h.Text = "0"

        'error verification
        Call error_verification_dh(d, h, result)

        'error verification step 2
        If result = 1 Then
            txt_d.Text = ""
            txt_d.Focus()
            ever_run = False
            Exit Sub
        ElseIf result = 2 Then
            txt_h.Text = ""
            txt_h.Focus()
            ever_run = False
            Exit Sub
        ElseIf result = 3 Then
            txt_d.Text = ""
            txt_h.Text = ""
            txt_d.Focus()
            ever_run = False
            Exit Sub
        End If

        gentorun = Val(txt_gentorun.Text)

        If Me.Text = "Assortative matings :: positive with dominance" Or assortype = 1 Then
            Call positiveDominance(d, h, gentorun)
        ElseIf Me.Text = "Assortative matings :: positive without dominance" Or assortype = 2 Then
            Call positiveNoDominance(d, h, gentorun)
        ElseIf Me.Text = "Assortative matings :: negative" Or assortype = 3 Then
            Call disAssortative(d, h, gentorun)
        End If

        cmd_save.Enabled = True

    End Sub
    Private Function error_verification_dh(ByVal d As Double, ByVal h As Double, ByVal result As Integer) As Integer

        'result = 1 when d is out of bounds
        'result = 2 when h is out of bounds
        'result = 3 when d + h is out of bounds

        'verifies value of d
        If d > 1 Or d < 0 Then
            MsgBox("Invalid frequency of homozygotes AA. Please restart.", vbExclamation)
            result = 1

        End If

        'verifies value of h
        If h > 1 Or h < 0 Then
            MsgBox("Invalid frequency of heterozygotes Aa. Please restart.", vbExclamation)
            result = 2

        End If

        'verifies value of d + h
        If d + h > 1 Then
            MsgBox("P(AA) + P(Aa) are over 1. Please restart.", vbExclamation)
            result = 3

        End If

    End Function
    Private Sub positiveDominance(ByVal d As Double, ByVal h As Double, ByVal g As Double)

        Dim i As Integer
        Dim dplot, dn, hn As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1

            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = (2 * d + h) * (2 * d + h) / (4 * (d + h))
                hn = h * (2 * d + h) / (2 * (d + h))
            End If

            dplot = dn + hn / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next

        Call CaptionsAssortative(d, h)
        Call PlotPoints(maingraph)
        fra_values.Visible = True

    End Sub
    Private Sub positiveNoDominance(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        Dim i As Integer
        Dim dplot, dn, hn As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        'verify the value entry
        For i = 1 To g + 1
            dn = d + h / 4
            hn = h / 2

            dplot = d + h / 2
            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
        Call CaptionsAssortative(d, h)
        Call PlotPoints(maingraph)
        fra_values.Visible = True
    End Sub

    Private Sub disAssortative(ByVal d As Double, ByVal h As Double, ByVal g As Integer)

        Dim i As Integer
        Dim dplot, dn, hn As Double
        ReDim assort_values_d(g + 1)
        ReDim assort_values_h(g + 1)

        assort_values_d(0) = d
        assort_values_h(0) = h

        For i = 1 To g + 1
            If d + h = 0 Then
                dn = 0
                hn = 0
            Else
                dn = 0
                hn = (d + h / 2) / (d + h)
            End If

            dplot = d + h / 2

            d = dn
            h = hn

            assort_values_d(i) = dn
            assort_values_h(i) = hn
        Next
        Call CaptionsAssortative(d, h)
        Call PlotPoints(maingraph)
        fra_values.Visible = True

    End Sub

    Private Sub PlotPoints(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim points, line As New PointPairList
        Dim i As Integer

        For i = 0 To gentorun
            points.Add(assort_values_d(i) + assort_values_h(i) / 2, assort_values_h(i))
        Next

        Dim point1 As LineItem = canvas.AddCurve("", points, Color.Red, SymbolType.Circle)
        If chk_points.Checked = True Then
            point1.Line.IsVisible = True
        Else
            point1.Line.IsVisible = False
        End If

        zgc.Refresh()
    End Sub
    Private Sub CaptionsAssortative(ByVal d As Double, ByVal h As Double)

        lbl_value1.Text = Format(d, "0.0000")
        lbl_value2.Text = Format(h, "0.0000")
        lbl_value3.Text = Format(1 - d - h, "0.0000")
        lbl_value4.Text = Format(d + h / 2, "0.0000")
        lbl_value5.Text = Format(1 - (d + h / 2), "0.0000")
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
                objWriter.WriteLine("Assortative matings")
                objWriter.WriteLine("Number of generations : " & gentorun)
                objWriter.WriteLine()
                objWriter.WriteLine()
                objWriter.WriteLine("gen." & vbTab & "p" & vbTab & "d" & vbTab & "h" & vbTab & "r")
                For i = 0 To gentorun
                    objWriter.Write(i & vbTab & Format(assort_values_d(i) + assort_values_h(i) / 2, "0.0000") & _
                    vbTab & Format(assort_values_d(i), "0.0000") & vbTab & _
                    Format(assort_values_h(i), "0.0000") & vbTab & _
                    Format(1 - assort_values_d(i) - assort_values_h(i), "0.0000"))
                    objWriter.WriteLine()
                Next
                objWriter.Close()
            End If
        End With
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/assortative.html")
    End Sub
End Class