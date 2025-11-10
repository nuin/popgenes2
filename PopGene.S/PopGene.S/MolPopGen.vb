Imports System.IO
Imports System
Imports System.Diagnostics
Public Class MolPopGen
    Dim sequences(), filecontents, names(), frequencies(), totals() As String
    Dim nseqs As Integer
    Dim big As Integer = 0
    Dim dash As Integer
    Dim aligned As Boolean = False
    'Dim seqlen(200) As Integer
    Dim openedFile As String
    Dim openedPath As String
    Dim mgaps As Integer
    Dim k As Integer
    Dim pi(,) As Double
    Dim bpi As Double
    Dim alignresult As String
    Dim alignmentrun As Boolean = False

    Private Sub MolPopGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = 255
        Me.Width = 255
    End Sub

    Private Sub cmd_open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_open.Click

        Dim i As Integer
        If System.IO.File.Exists(Application.StartupPath & "\temp.aln") = True Then
            System.IO.File.Delete(Application.StartupPath & "\temp.aln")
            'MsgBox("File Deleted")
        End If

        lst_poly.Clear()
        lst_div.Clear()


        With dlg_open
            .CheckFileExists = True
            .ShowReadOnly = True
            .Filter = "All files|*.*|FASTA files (*.fas, *.fasta)|*.fas;*.fasta"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lst_freqs.Items.Clear()
                rtx_seqs.Clear()
                Dim objReader As New System.IO.StreamReader(.FileName)
                filecontents = objReader.ReadToEnd
                Call CountSequences()
                Call ReadSeqs()
                If aligned = True Then
                    Call CalcFreqs()
                    Call NuclPoly()
                    Call CalcDiv()
                    fra_info.Visible = True
                    lbl_nseqs.Text = nseqs
                    lbl_sites.Text = big - mgaps
                    lbl_k.Text = k
                    lbl_gaps.Text = mgaps
                    lbl_muts.Text = k + mgaps
                    lbl_div.Text = bpi
                End If
                For i = 250 To 750 Step 100
                    Me.Width = i
                    If i <= 600 Then
                        Me.Height = i
                    End If
                    Me.Height = 600
                Next
                openedFile = .FileName
            End If
        End With
        Me.AutoScroll = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

    End Sub

    Private Sub CountSequences()
        Dim buffer() As String
        Dim i As Integer
        nseqs = 0
        buffer = filecontents.Split(">")

        For i = 0 To buffer.Length() - 1
            If buffer(i) <> Nothing And buffer(i).Length >= 2 Then
                nseqs = nseqs + 1
            End If
        Next

    End Sub

    Private Sub ReadSeqs()

        Dim i, j As Integer
        Dim t() As String
        Dim buffer() As String
        Dim b2 As String
        Dim counter As Integer = 0

        ReDim names(nseqs)
        ReDim sequences(nseqs)

        buffer = filecontents.Split(">")
        rtx_seqs.Clear()

        For i = 1 To buffer.Length - 1
            If buffer(i) <> Nothing Then
                t = buffer(i).Split(Environment.NewLine)
                names(counter) = t(0)
                For j = 1 To t.Length() - 1
                    b2 = t(j).Trim()
                    sequences(counter) = sequences(counter) + b2
                Next
                counter = counter + 1
            End If
        Next

        For i = 0 To sequences.Length - 1
            rtx_seqs.Text = rtx_seqs.Text + names(i) + Environment.NewLine
            rtx_seqs.Text = rtx_seqs.Text + sequences(i) + Environment.NewLine
            If sequences(i) <> Nothing Then
                If sequences(i).Length > big Then
                    big = sequences(i).Length
                End If
            End If
            If names(i) <> Nothing Then
                lst_freqs.Items.Add(names(i))
            End If
        Next

        For i = 0 To nseqs - 1
            If InStr("-", sequences(i)) > 0 Then
                aligned = True
                lbl_align.Text = "Yes"
            End If
        Next

        If aligned = False Then
            lbl_align.Text = "No"
            cmd_align.Enabled = True
            cmd_poly.Enabled = False
            cmd_dist.Enabled = False
            alignmentrun = False
        Else
            alignmentrun = True
        End If

        lbl_large.Text = big.ToString

    End Sub
    Private Sub CalcFreqs()

        Dim a, c, g, t, i, j, gap As Integer
        Dim nucl As String

        ReDim frequencies(nseqs)
        ReDim totals(nseqs)

        For i = 0 To sequences.Length - 1
            If sequences(i) <> Nothing Then
                sequences(i).ToUpper()
                For j = 0 To sequences(i).Length - 1
                    nucl = Mid(sequences(i), j + 1, 1)
                    If nucl = "-" Then gap = gap + 1
                    If nucl = "A" Then a = a + 1
                    If nucl = "G" Then g = g + 1
                    If nucl = "T" Then t = t + 1
                    If nucl = "C" Then c = c + 1
                Next
                frequencies(i) = (a / sequences(i).Length).ToString + "|" + (c / sequences(i).Length).ToString + "|" + _
                (g / sequences(i).Length).ToString + "|" + (t / sequences(i).Length).ToString + "|" + _
                (gap / sequences(i).Length).ToString
                totals(i) = a.ToString + "|" + c.ToString + "|" + g.ToString + "|" + t.ToString + "|" + gap.ToString
                a = 0
                c = 0
                g = 0
                t = 0
                gap = 0
            End If
        Next

    End Sub

    Private Sub lst_freqs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_freqs.SelectedIndexChanged

        Dim sel As Integer
        Dim buffer, temp() As String

        If alignmentrun = True Then
            sel = lst_freqs.SelectedIndex
            fra_box.Visible = True

            buffer = frequencies(sel)
            temp = buffer.Split("|")

            txt_size.Text = sequences(sel).Length.ToString

            txt_freqa.Text = temp(0)
            txt_freqc.Text = temp(1)
            txt_freqg.Text = temp(2)
            txt_freqt.Text = temp(3)
            txt_gaps.Text = temp(4)

            buffer = totals(sel)
            temp = buffer.Split("|")

            txt_na.Text = temp(0)
            txt_nc.Text = temp(1)
            txt_ng.Text = temp(2)
            txt_nt.Text = temp(3)
            txt_ngaps.Text = temp(4)
        End If

    End Sub

    Private Sub NuclPoly()

        Dim i, j, sites, gaps As Integer

        sites = 0
        k = big
        mgaps = 0
        gaps = 0
        While j < big
            For i = 0 To nseqs - 1 Step 1
                If Mid(sequences(i), j + 1, 1) = "-" Or Mid(sequences(i + 1), j + 1, 1) = "-" Then
                    gaps = gaps + 1
                ElseIf Mid(sequences(i), j + 1, 1) = Mid(sequences(i + 1), j + 1, 1) Then
                    sites = sites + 1
                End If
            Next
            If sites = nseqs - 1 Then k = k - 1
            If gaps >= 1 Then mgaps = mgaps + 1
            gaps = 0
            j = j + 1
            sites = 0
        End While

        k = k - mgaps
    End Sub
    Private Sub CalcDiv()

        Dim totalpairs, i, j, m, ga, diff As Integer
        Dim temp As String

        ReDim pi(nseqs, nseqs)
        bpi = 0
        totalpairs = nseqs * (nseqs - 1) / 2

        For i = 0 To nseqs - 2
            For j = i + 1 To nseqs - 1
                temp = names(i)
                temp = names(j)
                For m = 0 To big
                    If Mid(sequences(i), m + 1, 1) = "-" Or Mid(sequences(j), m + 1, 1) = "-" Then
                        ga = ga + 1
                    ElseIf Mid(sequences(i), m + 1, 1) <> Mid(sequences(j), m + 1, 1) Then
                        diff = diff + 1
                    End If
                Next
                pi(i, j) = diff / (big - ga)
                diff = 0
                ga = 0
                bpi = bpi + pi(i, j)
            Next
        Next

        bpi = bpi / totalpairs
    End Sub

    Private Sub cmd_poly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_poly.Click

        Dim i, j As Integer

        lbl_poly.Visible = True
        lst_poly.Visible = True

        Me.Width = 1090
        For i = 0 To nseqs - 2
            For j = i + 1 To nseqs - 1
                Dim item As New ListViewItem(names(i))
                lst_poly.Items.Add(item)
                item.SubItems.Add(names(j))
                item.SubItems.Add(Format(pi(i, j), "0.0000"))
            Next
        Next

    End Sub


    Private Sub cmd_dist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_dist.Click
        'Dim site As String

        Dim i, j, fA, fC, fG, fT, fGaps As Integer
        Dim position As String

        Me.Width = 1090
        lst_div.Visible = True
        lbl_diversity.Visible = True

        For i = 1 To big
            Dim item As New ListViewItem(i.ToString)
            lst_div.Items.Add(item)
            For j = 0 To nseqs - 1
                position = Mid(sequences(j), i + 1, 1)
                If position = "A" Then
                    fA = fA + 1
                ElseIf position = "C" Then
                    fC = fC + 1
                ElseIf position = "G" Then
                    fG = fG + 1
                ElseIf position = "T" Then
                    fT = fT + 1
                ElseIf position = "-" Then
                    fGaps = fGaps + 1
                End If
            Next
            If fA = 0 Then
                item.SubItems.Add("0.0000")
            Else
                item.SubItems.Add(Format(fA / nseqs, "0.0000"))
            End If
            If fC = 0 Then
                item.SubItems.Add("0.0000")
            Else
                item.SubItems.Add(Format(fC / nseqs, "0.0000"))
            End If
            If fG = 0 Then
                item.SubItems.Add("0.0000")
            Else
                item.SubItems.Add(Format(fG / nseqs, "0.0000"))
            End If
            If fT = 0 Then
                item.SubItems.Add("0.0000")
            Else
                item.SubItems.Add(Format(fT / nseqs, "0.0000"))
            End If
            If fGaps = 0 Then
                item.SubItems.Add("0.0000")
            Else
                item.SubItems.Add(Format(fGaps / nseqs, "0.0000"))
            End If
            fA = 0
            fC = 0
            fG = 0
            fT = 0
            fGaps = 0
        Next
    End Sub

    Private Sub cmd_align_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_align.Click

        Dim arguments As String
        Dim clustalw As Process = New Process
        Dim s As String
        Dim appbase As String = System.AppDomain.CurrentDomain.BaseDirectory

        If System.IO.File.Exists(Application.StartupPath & "\temp.aln") = True Then

            System.IO.File.Delete(Application.StartupPath & "\temp.aln")
            MsgBox("File Deleted")

        End If


        arguments = "/infile=""" + openedFile + """ /output=fasta /outfile=""" + appbase + "temp.aln""" + " /case=upper"
        ' MsgBox(arguments)
        clustalw.StartInfo.UseShellExecute = False
        clustalw.StartInfo.FileName = "clustalw.exe"
        clustalw.StartInfo.Arguments = arguments
        clustalw.Start()
        clustalw.WaitForExit()

        clustalw.StartInfo.RedirectStandardOutput = True
        clustalw.StartInfo.RedirectStandardError = True
        clustalw.Start()

        Dim sOut As StreamReader = clustalw.StandardOutput
        Dim sErr As StreamReader = clustalw.StandardError

        Dim objReader As New System.IO.StreamReader(appbase + "temp.aln")
        filecontents = objReader.ReadToEnd

        lst_freqs.Items.Clear()
        Call CountSequences()
        Call ReadSeqs()
        Call CalcFreqs()
        Call NuclPoly()
        Call CalcDiv()
        fra_info.Visible = True
        lbl_nseqs.Text = nseqs
        lbl_sites.Text = big - mgaps
        lbl_k.Text = k
        lbl_gaps.Text = mgaps
        lbl_muts.Text = k + mgaps
        lbl_div.Text = bpi

        cmd_poly.Enabled = True
        cmd_dist.Enabled = True

        s = sOut.ReadToEnd()
        sOut.Close()
        sErr.Close()
        clustalw.Close()
        alignmentrun = True
        lbl_align.Text = "Yes"
        objReader.Close()
        'MessageBox.Show(s, "Alignment Log")

    End Sub


    Private Sub mnu_ex1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ex1.Click

        Dim i As Integer

        lst_freqs.Items.Clear()
        rtx_seqs.Clear()
        Dim objReader As New System.IO.StreamReader("europe_runt.fas")
        filecontents = objReader.ReadToEnd
        Call CountSequences()
        Call ReadSeqs()
        If aligned = True Then
            Call CalcFreqs()
            Call NuclPoly()
            Call CalcDiv()
            fra_info.Visible = True
            lbl_nseqs.Text = nseqs
            lbl_sites.Text = big - mgaps
            lbl_k.Text = k
            lbl_gaps.Text = mgaps
            lbl_muts.Text = k + mgaps
            lbl_div.Text = bpi
        End If

        For i = 250 To 750 Step 100
            Me.Width = i
            If i <= 600 Then
                Me.Height = i
            End If
            Me.Height = 600
        Next
        openedFile = "europe_runt.fas"
 
    End Sub

    Private Sub mnu_ex2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ex2.Click

        Dim i As Integer

        lst_freqs.Items.Clear()
        rtx_seqs.Clear()
        Dim objReader As New System.IO.StreamReader("europe_sevenless.fas")
        filecontents = objReader.ReadToEnd
        Call CountSequences()
        Call ReadSeqs()
        If aligned = True Then
            Call CalcFreqs()
            Call NuclPoly()
            Call CalcDiv()
            fra_info.Visible = True
            lbl_nseqs.Text = nseqs
            lbl_sites.Text = big - mgaps
            lbl_k.Text = k
            lbl_gaps.Text = mgaps
            lbl_muts.Text = k + mgaps
            lbl_div.Text = bpi
        End If

        For i = 250 To 750 Step 100
            Me.Width = i
            If i <= 600 Then
                Me.Height = i
            End If
            Me.Height = 600
        Next
        openedFile = "europe_sevenless.fas"
    End Sub

    Private Sub mnu_ex3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ex3.Click

        Dim i As Integer

        lst_freqs.Items.Clear()
        rtx_seqs.Clear()
        Dim objReader As New System.IO.StreamReader("europe_runt.fas")
        filecontents = objReader.ReadToEnd
        Call CountSequences()
        Call ReadSeqs()
        If aligned = True Then
            Call CalcFreqs()
            Call NuclPoly()
            Call CalcDiv()
            fra_info.Visible = True
            lbl_nseqs.Text = nseqs
            lbl_sites.Text = big - mgaps
            lbl_k.Text = k
            lbl_gaps.Text = mgaps
            lbl_muts.Text = k + mgaps
            lbl_div.Text = bpi
        End If

        For i = 250 To 750 Step 100
            Me.Width = i
            If i <= 600 Then
                Me.Height = i
            End If
            Me.Height = 600
        Next
        openedFile = "mayotte_runt.fas"
    End Sub

    Private Sub mnu_ex4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_ex4.Click

        Dim i As Integer

        lst_freqs.Items.Clear()
        rtx_seqs.Clear()
        Dim objReader As New System.IO.StreamReader("europe_runt.fas")
        filecontents = objReader.ReadToEnd
        Call CountSequences()
        Call ReadSeqs()
        If aligned = True Then
            Call CalcFreqs()
            Call NuclPoly()
            Call CalcDiv()
            fra_info.Visible = True
            lbl_nseqs.Text = nseqs
            lbl_sites.Text = big - mgaps
            lbl_k.Text = k
            lbl_gaps.Text = mgaps
            lbl_muts.Text = k + mgaps
            lbl_div.Text = bpi
        End If

        For i = 250 To 750 Step 100
            Me.Width = i
            If i <= 600 Then
                Me.Height = i
            End If
            Me.Height = 600
        Next
        openedFile = "mayotte_sevenless.fas"
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/molpopgen.html")
    End Sub
End Class