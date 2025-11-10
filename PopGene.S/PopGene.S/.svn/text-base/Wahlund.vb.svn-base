Public Class Wahlund
    Dim p1, p2, p3, p4, p5 As Double
    Dim f, p1f, q1f, p2f, q2f, p3f, q3f As Double
    Dim p4f, q4f, p5f, q5f, obsp2, obsq2, obs2pq, vfis, vfst As Double

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        If Val(txt_p1.Text) < 0 Or Val(txt_p1.Text) > 1 Then
            MsgBox("Population 1 p value is invalid. Please restart.")
            txt_p1.Focus()
            Exit Sub
        Else
            p1 = Val(txt_p1.Text)
        End If
        If Val(txt_p2.Text) < 0 Or Val(txt_p2.Text) > 1 Then
            MsgBox("Population 2 p value is invalid. Please restart.")
            txt_p2.Focus()
            Exit Sub
        Else
            p2 = Val(txt_p2.Text)
        End If
        If Val(txt_p3.Text) < 0 Or Val(txt_p3.Text) > 1 Then
            MsgBox("Population 3 p value is invalid. Please restart.")
            txt_p3.Focus()
            Exit Sub
        Else
            p3 = Val(txt_p3.Text)
        End If

        If Val(txt_p4.Text) < 0 Or Val(txt_p4.Text) > 1 Then
            MsgBox("Population 4 p value is invalid. Please restart.")
            txt_p4.Focus()
            Exit Sub
        Else
            p4 = Val(txt_p4.Text)
        End If

        If Val(txt_p5.Text) < 0 Or Val(txt_p5.Text) > 1 Then
            MsgBox("Population 5 p value is invalid. Please restart.")
            txt_p5.Focus()
            Exit Sub
        Else
            p5 = Val(txt_p5.Text)
        End If

        If Val(txt_f.Text) < 0 Or Val(txt_f.Text) > 1 Then
            MsgBox("Inbreeding coefficient f is invalid. Please restart.")
            txt_f.Focus()
            Exit Sub
        Else
            f = Val(txt_f.Text)
        End If

        Call calculus()

    End Sub

    Private Sub calculus()

        Dim avgp, varsum, varp As Double

        avgp = (p1 + p2 + p3 + p4 + p5) / 5
        lbl_avgp.Text = (Format(avgp, "0.000"))

        varsum = (p1 - avgp) ^ 2
        varsum = varsum + ((p2 - avgp) ^ 2)
        varsum = varsum + ((p3 - avgp) ^ 2)
        varsum = varsum + ((p4 - avgp) ^ 2)
        varsum = varsum + ((p5 - avgp) ^ 2)

        varp = varsum / 5
        lbl_varp.Text = Format(varp, "0.000")

        'freq(aa) = p2(1 - f) + pf
        'freq(Aa)=2p(1-p)(1-f)
        'freq(aa)=(1-p)2(1-f) + (1-p)f

        'p1
        p1f = (p1 ^ 2) * (1 - f) + p1 * f
        q1f = (1 - p1) * (1 - p1) * (1 - f) + (1 - p1) * f
        lbl_a1.Text = Format((p1 ^ 2) * (1 - f) + p1 * f, "0.0000")
        lbl_b1.Text = Format(2 * p1 * (1 - p1) * (1 - f), "0.0000")
        lbl_c1.Text = Format((1 - p1) * (1 - p1) * (1 - f) + (1 - p1) * f, "0.0000")

        'p2
        p2f = (p2 ^ 2) * (1 - f) + p2 * f
        q2f = (1 - p2) * (1 - p2) * (1 - f) + (1 - p2) * f
        lbl_a2.Text = Format((p2 ^ 2) * (1 - f) + p2 * f, "0.0000")
        lbl_b2.Text = Format(2 * p2 * (1 - p2) * (1 - f), "0.0000")
        lbl_c2.Text = Format((1 - p2) * (1 - p2) * (1 - f) + (1 - p2) * f, "0.0000")

        'p3
        p3f = (p3 ^ 2) * (1 - f) + p3 * f
        q3f = (1 - p3) * (1 - p3) * (1 - f) + (1 - p3) * f
        lbl_a3.Text = Format((p3 ^ 2) * (1 - f) + p3 * f, "0.0000")
        lbl_b3.Text = Format(2 * p3 * (1 - p3) * (1 - f), "0.0000")
        lbl_c3.Text = Format((1 - p3) * (1 - p3) * (1 - f) + (1 - p3) * f, "0.0000")

        'p4
        p4f = (p4 ^ 2) * (1 - f) + p4 * f
        q4f = (1 - p4) * (1 - p4) * (1 - f) + (1 - p4) * f
        lbl_a4.Text = Format((p4 ^ 2) * (1 - f) + p4 * f, "0.0000")
        lbl_b4.Text = Format(2 * p4 * (1 - p4) * (1 - f), "0.0000")
        lbl_c4.Text = Format((1 - p4) * (1 - p4) * (1 - f) + (1 - p4) * f, "0.0000")

        'p5
        p5f = (p5 ^ 2) * (1 - f) + p5 * f
        q5f = (1 - p5) * (1 - p5) * (1 - f) + (1 - p5) * f
        lbl_a5.Text = Format((p5 ^ 2) * (1 - f) + p5 * f, "0.0000")
        lbl_b5.Text = Format(2 * p5 * (1 - p5) * (1 - f), "0.0000")
        lbl_c5.Text = Format((1 - p5) * (1 - p5) * (1 - f) + (1 - p5) * f, "0.0000")

        'expected
        lbl_e1.Text = Format(avgp ^ 2, "0.0000")
        lbl_e2.Text = Format(2 * avgp * (1 - avgp), "0.0000")
        lbl_e3.Text = Format((1 - avgp) * (1 - avgp), "0.0000")

        'observed
        obsp2 = (p1f + p2f + p3f + p4f + p5f) / 5
        lbl_o1.Text = Format(obsp2, "0.0000")
        obsq2 = (q1f + q2f + q3f + q4f + q5f) / 5
        lbl_o3.Text = Format(obsq2, "0.0000")
        obs2pq = 1 - obsp2 - obsq2
        lbl_o2.Text = Format(obs2pq, "0.0000")

        vfis = f
        vfst = varp / (avgp * (1 - avgp))
        lbl_fst.Text = Format(varp / (avgp * (1 - avgp)), "0.000")
        lbl_fit.Text = Format(1 - ((1 - vfst) * (1 - vfis)), "0.000")
        lbl_fis.Text = Format(f, "0.000")
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/wahlund.html")
    End Sub
End Class