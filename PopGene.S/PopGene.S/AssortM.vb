Imports ZedGraph
Public Class AssortM

    Dim assortmodel As Integer
    Dim DD, DH, DR, HH, HR, RR As Boolean
    Dim ever_run As Boolean
    Dim pointsD As Boolean
    Dim dont_run As Boolean

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
    Sub checkMatrix()

        If assortcircle1.FillColor = Color.Black Then
            DD = True
        Else : DD = False
        End If

        If assortcircle2.FillColor = Color.Black Or _
            assortcircle4.FillColor = Color.Black Then
            DH = True
        Else : DH = False
        End If

        If assortcircle3.FillColor = Color.Black Or _
            assortcircle7.FillColor = Color.Black Then
            DR = True
        Else : DR = False
        End If

        If assortcircle5.FillColor = Color.Black Then
            HH = True
        Else : HH = False
        End If

        If assortcircle6.FillColor = Color.Black Or _
            assortcircle8.FillColor = Color.Black Then
            HR = True
        Else : HR = False
        End If

        If assortcircle9.FillColor = Color.Black Then
            RR = True
        Else : RR = False
        End If

    End Sub
    Sub modelAssign()

        If DD = True And DH = True And DR = False And HH = True And HR = False And RR = True Then
            assortmodel = 1
            dont_run = True
        ElseIf DD = True And DH = False And DR = False And HH = True And HR = False And RR = True Then
            assortmodel = 2
            dont_run = True
        ElseIf DD = False And DH = True And DR = True And HH = False And HR = True And RR = False Then
            assortmodel = 3
            dont_run = True
        ElseIf DD = False And DH = True And DR = True And HH = True And HR = True And RR = False Then
            assortmodel = 4
            dont_run = True
        ElseIf DD = False And DH = True And DR = True And HH = False And HR = True And RR = True Then
            assortmodel = 5
            dont_run = True
        ElseIf DD = False And DH = False And DR = True And HH = False And HR = True And RR = True Then
            assortmodel = 6
            dont_run = True
        ElseIf DD = True And DH = True And DR = True And HH = False And HR = True And RR = True Then
            assortmodel = 7
            dont_run = True
        ElseIf DD = False And DH = True And DR = True And HH = True And HR = True And RR = True Then
            assortmodel = 8
            dont_run = True
        ElseIf DD = True And DH = False And DR = True And HH = True And HR = False And RR = True Then
            assortmodel = 9
            dont_run = True
        ElseIf DD = False And DH = False And DR = True And HH = True And HR = False And RR = False Then
            assortmodel = 10
            dont_run = True
        ElseIf DD = True And DH = True And DR = False And HH = False And HR = True And RR = True Then
            assortmodel = 11
            dont_run = True
        ElseIf DD = False And DH = False And DR = True And HH = False And HR = True And RR = False Then
            assortmodel = 12
            dont_run = True
        ElseIf DD = False And DH = True And DR = False And HH = False And HR = True And RR = False Then
            assortmodel = 13
            dont_run = True
        ElseIf DD = True And DH = True And DR = True And HH = True And HR = False And RR = False Then
            assortmodel = 14
            dont_run = True
        Else
            MsgBox("The selected group of crossings does not represent a assortative matings model. Check Help file for more information", vbExclamation)
            dont_run = True
        End If

    End Sub
    Sub assort_model_call(ByVal d, ByVal h)

        Select Case mating_type
            Case False
                Select Case assortmodel
                    Case 1
                        Call ass01(d, h, gentorun)
                    Case 2
                        Call ass03(d, h, gentorun)
                    Case 3
                        Call ass05(d, h, gentorun)
                    Case 4
                        Call ass07(d, h, gentorun)
                    Case 5
                        Call ass09(d, h, gentorun)
                    Case 6
                        Call ass11(d, h, gentorun)
                    Case 7
                        Call ass13(d, h, gentorun)
                    Case 8
                        Call ass15(d, h, gentorun)
                    Case 9
                        Call ass17(d, h, gentorun)
                    Case 10
                        Call ass19(d, h, gentorun)
                    Case 11
                        Call ass21(d, h, gentorun)
                    Case 12
                        Call ass23(d, h, gentorun)
                    Case 13
                        Call ass25(d, h, gentorun)
                    Case 14
                        Call ass27(d, h, gentorun)
                End Select
            Case True
                Select Case assortmodel
                    Case 1
                        Call ass02(d, h, gentorun)
                    Case 2
                        Call ass04(d, h, gentorun)
                    Case 3
                        Call ass06(d, h, gentorun)
                    Case 4
                        Call ass08(d, h, gentorun)
                    Case 5
                        Call ass10(d, h, gentorun)
                    Case 6
                        Call ass12(d, h, gentorun)
                    Case 7
                        Call ass14(d, h, gentorun)
                    Case 8
                        Call ass16(d, h, gentorun)
                    Case 9
                        Call ass18(d, h, gentorun)
                    Case 10
                        Call ass20(d, h, gentorun)
                    Case 11
                        Call ass22(d, h, gentorun)
                    Case 12
                        Call ass24(d, h, gentorun)
                    Case 13
                        Call ass26(d, h, gentorun)
                    Case 14
                        Call ass28(d, h, gentorun)
                End Select
        End Select

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
    Private Sub assortcircle1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle1.Click
        If assortcircle1.FillColor = Color.Black Then
            assortcircle1.FillColor = Color.White
        Else
            assortcircle1.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle4.Click
        If assortcircle4.FillColor = Color.Black Then
            assortcircle4.FillColor = Color.White
        Else
            assortcircle4.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle7.Click
        If assortcircle7.FillColor = Color.Black Then
            assortcircle7.FillColor = Color.White
        Else
            assortcircle7.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle2.Click
        If assortcircle2.FillColor = Color.Black Then
            assortcircle2.FillColor = Color.White
        Else
            assortcircle2.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle5.Click
        If assortcircle5.FillColor = Color.Black Then
            assortcircle5.FillColor = Color.White
        Else
            assortcircle5.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle8.Click
        If assortcircle8.FillColor = Color.Black Then
            assortcircle8.FillColor = Color.White
        Else
            assortcircle8.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle3.Click
        If assortcircle3.FillColor = Color.Black Then
            assortcircle3.FillColor = Color.White
        Else
            assortcircle3.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle6.Click
        If assortcircle6.FillColor = Color.Black Then
            assortcircle6.FillColor = Color.White
        Else
            assortcircle6.FillColor = Color.Black
        End If
    End Sub

    Private Sub assortcircle9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assortcircle9.Click
        If assortcircle9.FillColor = Color.Black Then
            assortcircle9.FillColor = Color.White
        Else
            assortcircle9.FillColor = Color.Black
        End If
    End Sub

    Private Sub CaptionsAssortative(ByVal d As Double, ByVal h As Double)

        lbl_value1.Text = Format(d, "0.0000")
        lbl_value2.Text = Format(h, "0.0000")
        lbl_value3.Text = Format(1 - d - h, "0.0000")
        lbl_value4.Text = Format(d + h / 2, "0.0000")
        lbl_value5.Text = Format(1 - (d + h / 2), "0.0000")
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

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim d, h, dplot As Double
        Dim result As Integer

        checkMatrix()
        modelAssign()

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
        cmd_save.Enabled = True

        If dont_run = True Then

            Call assort_model_call(d, h)
            Call CaptionsAssortative(d, h)
            Call PlotPoints(maingraph)
            fra_values.Visible = True
        End If

    End Sub

    Private Sub AssortM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
        dont_run = False
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/assortative.html")
    End Sub
End Class