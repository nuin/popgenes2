Imports ZedGraph
Public Class MagD
    Inherits System.Windows.Forms.Form
    Dim rrecomb, drecomb As Double
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Dim dgen As Integer
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Dim mD() As Double

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_r As System.Windows.Forms.TextBox
    Friend WithEvents txt_d As System.Windows.Forms.TextBox
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents txt_gentorun As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MagD))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_gentorun = New System.Windows.Forms.NumericUpDown
        Me.txt_d = New System.Windows.Forms.TextBox
        Me.txt_r = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.cmd_save = New System.Windows.Forms.Button
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_gentorun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_gentorun)
        Me.GroupBox1.Controls.Add(Me.txt_d)
        Me.GroupBox1.Controls.Add(Me.txt_r)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Disequilibrium coefficient"
        '
        'txt_gentorun
        '
        Me.txt_gentorun.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gentorun.Location = New System.Drawing.Point(80, 160)
        Me.txt_gentorun.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_gentorun.Name = "txt_gentorun"
        Me.txt_gentorun.Size = New System.Drawing.Size(64, 22)
        Me.txt_gentorun.TabIndex = 2
        Me.txt_gentorun.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(80, 104)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 22)
        Me.txt_d.TabIndex = 1
        Me.txt_d.Text = "0.15"
        '
        'txt_r
        '
        Me.txt_r.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_r.Location = New System.Drawing.Point(80, 48)
        Me.txt_r.Name = "txt_r"
        Me.txt_r.Size = New System.Drawing.Size(64, 22)
        Me.txt_r.TabIndex = 0
        Me.txt_r.Text = "0.1"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(80, 200)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Generations to run:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Enter value of D0:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 21)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Enter value of r:"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(184, 16)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(568, 432)
        Me.maingraph.TabIndex = 3
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(114, 376)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(64, 72)
        Me.cmd_clear.TabIndex = 4
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmd_save
        '
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(12, 376)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(64, 72)
        Me.cmd_save.TabIndex = 7
        Me.cmd_save.Text = "Save values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(677, 454)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'MagD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(765, 483)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MagD"
        Me.Text = "Magnitude of D"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_gentorun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        rrecomb = Val(txt_r.Text)

        If Val(txt_d.Text) <= 0.25 And Val(txt_d.Text) >= -0.25 Then
            drecomb = Val(txt_d.Text)
        Else
            MsgBox("Value should be -0.25 <= D <= 0.25")
            txt_d.Text = ""
            Exit Sub
        End If

        If Val(txt_r.Text) > 0.5 Then
            MsgBox("Recombination rate should be smaller than 0.5. Please restart.")
            txt_r.Text = ""
            Exit Sub
        End If

        dgen = Val(txt_gentorun.Text)
        PlotPoints(maingraph)
        cmd_save.Enabled = True
    End Sub

    Private Sub MagD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
    End Sub
    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.MajorStep = 10
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.XAxis.Title.Text = "Generations"
        canvas.X2Axis.IsVisible = False
        canvas.YAxis.Scale.Max = 0.25
        canvas.YAxis.Scale.Min = -0.25
        canvas.YAxis.Title.Text = "D"
        zgc.AxisChange()
    End Sub
    Private Sub PlotPoints(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim dt, dt1, cy As Double
        Dim i As Integer

        ReDim mD(dgen + 1)
        Dim mdplot As New PointPairList

        dt = drecomb
        mD(0) = drecomb
        mdplot.Add(0, mD(0))

        For i = 1 To dgen
            dt1 = (1 - rrecomb) * dt
            mD(i) = dt1
            mdplot.Add(i, dt1)
            If i = dgen / 2 Then
                cy = 0.25 - dt
            End If
            dt = dt1
        Next

        Randomize()

        Dim rcolor As Integer = Rnd() * 255
        Dim rcolor2 As Integer = Rnd() * 255
        Dim rcolor3 As Integer = Rnd() * 255

        Dim curve As LineItem = canvas.AddCurve("", mdplot, Color.FromArgb(rcolor, rcolor2, rcolor3), SymbolType.None)

        If mD(0) > 0 And canvas.YAxis.Scale.Max <> 0 Then
            canvas.YAxis.Scale.Min = 0
        ElseIf mD(0) > 0 And canvas.YAxis.Scale.Max = 0 Then
            canvas.YAxis.Scale.Max = 0.25
            canvas.YAxis.Scale.Min = -0.25
        ElseIf mD(0) < 0 And canvas.YAxis.Scale.Min <> 0 Then
            canvas.YAxis.Scale.Max = 0
        ElseIf mD(0) < 0 And canvas.YAxis.Scale.Min = 0 Then
            canvas.YAxis.Scale.Max = 0.25
            canvas.YAxis.Scale.Min = -0.25
        End If
        zgc.AxisChange()
        zgc.Refresh()

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
        Dim i As Integer

        With dlg_save
            .DefaultExt = ".txt"
            .OverwritePrompt = True
            .Filter = "All files|*.*|Text files (*.txt)|*.txt"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objWriter As New System.IO.StreamWriter(.FileName)
                objWriter.WriteLine("Linkage Disequilibrium - Magnitude of D")
                objWriter.WriteLine("Recombination rate : " & Val(txt_r))
                objWriter.WriteLine("Initial Linkage Disequilibrium : " & Val(txt_d))
                objWriter.WriteLine("Generations run : " & Val(txt_gentorun))
                objWriter.WriteLine()
                objWriter.WriteLine("Gen" & vbTab & "D")
                For i = 1 To Val(txt_gentorun)
                    objWriter.WriteLine(i & vbTab & Format(mD(i), "0.####"))
                Next
                objWriter.WriteLine()
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/magnitude.html")
    End Sub
End Class
