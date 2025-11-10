Imports ZedGraph
Imports System.Math
Imports System.Collections.Generic
Imports System.IO

Public Class QTL
    Dim nMajorLoci As Integer
    Dim major_locus_value As Single
    Dim nLociGraph As Integer
    Dim N As Integer
    Dim nqtl As Integer
    Dim mu As Double
    Dim gens As Integer
    Dim p As Double
    Dim ve As Double
    Dim maxGenotypicValue As Double
    Dim selxn As Double
    Dim effect_set As Byte
    Dim alphas() As Double
    Dim genotypes(,) As Double
    Dim freqA(,) As Double
    Dim ipvalue(,) As Double
    Dim igvalue(,) As Double
    Dim pmean() As Double
    Dim gmean() As Double
    Dim VP() As Double
    Dim VG() As Double
    Dim sortedgenotypes(,) As Double
    Dim newgenotypes(,) As Double
    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim qtl As Process = New Process


        N = Val(txt_n.Text)
        nqtl = Val(txt_nqtl.Text)
        mu = Val(txt_mu.Text)
        gens = Val(txt_gen.Text)
        p = Val(txt_p.Text)
        ve = Val(txt_ve.Text)
        maxGenotypicValue = Val(txt_maxgen.Text)
        selxn = Val(txt_selxn.Text)

        Dim oFile As System.IO.File
        Dim oWrite As System.IO.StreamWriter
        oWrite = oFile.CreateText(System.Environment.CurrentDirectory & "\test.txt")

        oWrite.WriteLine(N & ", " & nqtl & ", " & mu & ", " & gens & ", " & p & ", " & ve & ", " & maxGenotypicValue & ", " & selxn)
        oWrite.Close()
        'MessageBox.Show(System.Environment.CurrentDirectory)

        qtl.StartInfo.UseShellExecute = False
        qtl.StartInfo.FileName = "qtl\qtl.exe"
        qtl.Start()
        qtl.WaitForExit()
        qtl.StartInfo.RedirectStandardOutput = False
        qtl.StartInfo.RedirectStandardError = False
        qtl.Close()

        ClearGraph(graph1)
        ClearGraph(graph2)
        ClearGraph(graph3)
        ClearGraph(graph4)

        PlotGraph1(graph1)
        PlotGraph2(graph2)
        PlotGraph3(graph3)
        PlotGraph4(graph4)

    End Sub
    Private Sub PlotGraph1(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i, j As Integer
        Dim freq As New PointPairList
        Dim temp(10, gens) As Double
        Dim ioFile As New StreamReader(System.Environment.CurrentDirectory & "\figure1.txt")
        Dim FileToDelete As String
        Dim ioLine As String ' Going to hold one line at a time
        Dim ioLines As String ' Going to hold whole file

        j = 0
        While j <= gens - 1
            ioLine = ioFile.ReadLine
            Dim values As String() = ioLine.Split(",")
            For i = 0 To 9
                temp(i, j) = values(i)
            Next
            j = j + 1
            ioLines = ioLines & vbCrLf & ioLine
        End While

        ioFile.Close()

        For j = 0 To 9
            For i = 0 To gens - 2
                freq.Add(i, temp(j, i))
                'temp(i) = freqA(i, j)
            Next
            zgc.GraphPane.AddCurve("", freq, Color.Red, SymbolType.None)
            'zgc.Invalidate()
        Next

        canvas.XAxis.Scale.Max = gens
        canvas.YAxis.Scale.Max = 1.0
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 12
        zgc.Validate()
        zgc.AxisChange()
        zgc.Refresh()

        FileToDelete = System.Environment.CurrentDirectory & "\figure1.txt"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If

    End Sub

    Private Sub PlotGraph2(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim meanp, meang As New PointPairList

        Dim ioFile As New StreamReader(System.Environment.CurrentDirectory & "\figure2_P.txt")
        Dim ioFile2 As New StreamReader(System.Environment.CurrentDirectory & "\figure2_G.txt")

        Dim FileToDelete, FileToDelete2 As String
        Dim ioLine As String ' Going to hold one line at a time
        Dim ioLines As String ' Going to hold whole file

        i = 0
        While i <= gens - 1
            ioLine = ioFile.ReadLine
            meanp.Add(i, Convert.ToDouble(ioLine))
            i = i + 1
        End While
        ioFile.Close()

        i = 0
        While i <= gens - 1
            ioLine = ioFile2.ReadLine
            meang.Add(i, Convert.ToDouble(ioLine))
            i = i + 1
        End While
        ioFile2.Close()

        Dim cont As LineItem = canvas.AddCurve("", meanp, Color.Red, SymbolType.None)
        Dim cont2 As LineItem = canvas.AddCurve("", meang, Color.Blue, SymbolType.None)
        canvas.XAxis.Scale.Max = gens
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 12
        zgc.Validate()
        zgc.AxisChange()
        zgc.Refresh()

        FileToDelete = System.Environment.CurrentDirectory & "\figure2_P.txt"
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If

        FileToDelete2 = System.Environment.CurrentDirectory & "\figure2_P.txt"
        If System.IO.File.Exists(FileToDelete2) = True Then
            System.IO.File.Delete(FileToDelete2)
        End If

    End Sub
    Private Sub PlotGraph3(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim VPc, VGc As New PointPairList
        Dim ioFile As New StreamReader(System.Environment.CurrentDirectory & "\figure3_P.txt")
        Dim ioFile2 As New StreamReader(System.Environment.CurrentDirectory & "\figure3_G.txt")

        Dim FileToDelete, FileToDelete2 As String
        Dim ioLine As String ' Going to hold one line at a time
        Dim ioLines As String ' Going to hold whole file

        i = 0
        While i <= gens - 1
            ioLine = ioFile.ReadLine
            VPc.Add(i, Convert.ToDouble(ioLine))
            i = i + 1
        End While
        ioFile.Close()

        i = 0
        While i <= gens - 1
            ioLine = ioFile2.ReadLine
            VGc.Add(i, Convert.ToDouble(ioLine))
            i = i + 1
        End While
        ioFile2.Close()


        Dim cont As LineItem = canvas.AddCurve("", VPc, Color.Red, SymbolType.None)
        Dim cont2 As LineItem = canvas.AddCurve("", VGc, Color.Blue, SymbolType.None)
        canvas.XAxis.Scale.Max = gens
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 12
        zgc.Validate()
        zgc.AxisChange()
        zgc.Refresh()

    End Sub

    Sub PlotGraph4(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer
        Dim herit As New PointPairList
        Dim ioFile As New StreamReader(System.Environment.CurrentDirectory & "\figure4.txt")

        Dim FileToDelete As String
        Dim ioLine As String ' Going to hold one line at a time

        i = 0
        While i <= gens - 1
            ioLine = ioFile.ReadLine
            herit.Add(i, Convert.ToDouble(ioLine))
            i = i + 1
        End While
        ioFile.Close()


        Dim cont As LineItem = canvas.AddCurve("", herit, Color.Red, SymbolType.None)
        canvas.XAxis.Scale.Max = gens
        canvas.Legend.Border.IsVisible = False
        canvas.Legend.FontSpec.Size = 12
        zgc.Validate()
        zgc.AxisChange()
        zgc.Refresh()
    End Sub


    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Scale.Min = 0
        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "+ allele frequency at each QTL"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub
    Private Sub SetGraph2(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Scale.Min = 0
        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "mean phenotypic value"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub
    Private Sub SetGraph3(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Scale.Min = 0
        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "Variance in phenotypic value"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub
    Private Sub SetGraph4(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.Max = 50
        canvas.XAxis.Scale.MinorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.YAxis.Scale.Min = 0
        canvas.YAxis.Scale.Max = 1
        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "Heritability (VG/VP)"
        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        zgc.Refresh()
        zgc.AxisChange()
    End Sub
    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub
    Private Sub QTL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(graph1)
        SetGraph2(graph2)
        SetGraph3(graph3)
        SetGraph4(graph4)
    End Sub
End Class