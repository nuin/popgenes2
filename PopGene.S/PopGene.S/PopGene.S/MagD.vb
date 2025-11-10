Imports ZedGraph
Public Class MagD
    Inherits System.Windows.Forms.Form
    Dim rrecomb As Double
    Dim drecomb As Double
    Dim dgen As Integer

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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MagD))
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Disequilibrium coefficient"
        '
        'txt_gentorun
        '
        Me.txt_gentorun.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gentorun.Location = New System.Drawing.Point(64, 160)
        Me.txt_gentorun.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_gentorun.Name = "txt_gentorun"
        Me.txt_gentorun.Size = New System.Drawing.Size(72, 21)
        Me.txt_gentorun.TabIndex = 2
        Me.txt_gentorun.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(72, 104)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 21)
        Me.txt_d.TabIndex = 1
        Me.txt_d.Text = "0.15"
        '
        'txt_r
        '
        Me.txt_r.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_r.Location = New System.Drawing.Point(72, 48)
        Me.txt_r.Name = "txt_r"
        Me.txt_r.Size = New System.Drawing.Size(64, 21)
        Me.txt_r.TabIndex = 0
        Me.txt_r.Text = "0.1"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(72, 200)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Generations to run:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Enter value of D0:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Enter value of r:"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.cmd_clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(104, 376)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(64, 72)
        Me.cmd_clear.TabIndex = 4
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MagD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(774, 460)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "MagD"
        Me.Text = "Magnitude of D"
        Me.GroupBox1.ResumeLayout(False)
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
        'If chk_points.Value = 1 Then
        '    linkLink = True
        'Else
        '    linkLink = False
        'End If


        'If dgenOld > 0 And dgen <> dgenOld Then
        '    MsgBox("Number of generations is different from previous run. The graph will be cleared before a new run is plot")
        '    pct_D.Cls()
        'End If

        'If oldmag = 0 Then
        '    oldmag = drecomb
        'ElseIf oldmag > 0 And drecomb < 0 Then
        '    MsgBox("New value of D has is negative. The window will be cleared.")
        '    frm_magD.pct_D.Cls()
        'ElseIf oldmag < 0 And drecomb > 0 Then
        '    MsgBox("New value of D has is positive. The window will be cleared.")
        '    frm_magD.pct_D.Cls()
        'End If



        'If drecomb < 0 Then
        '    Call cartesian_linkage_negative()
        '    Call magD_negative()
        'Else
        '    Call cartesian_linkage()
        '    Call MagD()
        'End If
        'mag_run = True
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
        Dim dt As Double
        Dim dt1 As Double
        Dim i As Integer
        Dim mD(dgen + 1) As Double
        Dim cy As Double

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
End Class
