Imports ZedGraph
Imports System.Math
Public Class Drift
    Inherits System.Windows.Forms.Form
    Dim populations As Integer
    Dim generations As Integer
    Dim p0 As Double
    Dim n As Integer
    Dim drift_values(,) As Double
    Dim drift_values_r(,) As Double
    Dim drift_values_d(,) As Double
    Dim drift_mut_v As Double
    Dim drift_mut_m As Double
    Dim lost As Integer
    Dim fixed As Integer
    Dim dw1 As Double
    Dim dw2 As Double
    Dim dw3 As Double

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_population As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_frequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_size As System.Windows.Forms.NumericUpDown
    Friend WithEvents txt_generation As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents fra_fitness As System.Windows.Forms.GroupBox
    Friend WithEvents fra_mutation As System.Windows.Forms.GroupBox
    Friend WithEvents txt_w1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_w2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_w3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_v As System.Windows.Forms.TextBox
    Friend WithEvents txt_m As System.Windows.Forms.TextBox
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents secondarygraph As ZedGraph.ZedGraphControl
    Friend WithEvents lbl_fixed As System.Windows.Forms.Label
    Friend WithEvents lbl_lost As System.Windows.Forms.Label
    Friend WithEvents fra_simul As System.Windows.Forms.GroupBox
    Friend WithEvents pbr_simul As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Drift))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.txt_generation = New System.Windows.Forms.NumericUpDown
        Me.txt_size = New System.Windows.Forms.NumericUpDown
        Me.txt_frequency = New System.Windows.Forms.NumericUpDown
        Me.txt_population = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.secondarygraph = New ZedGraph.ZedGraphControl
        Me.fra_fitness = New System.Windows.Forms.GroupBox
        Me.txt_w3 = New System.Windows.Forms.TextBox
        Me.txt_w2 = New System.Windows.Forms.TextBox
        Me.txt_w1 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.fra_mutation = New System.Windows.Forms.GroupBox
        Me.txt_m = New System.Windows.Forms.TextBox
        Me.txt_v = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lbl_fixed = New System.Windows.Forms.Label
        Me.lbl_lost = New System.Windows.Forms.Label
        Me.fra_simul = New System.Windows.Forms.GroupBox
        Me.pbr_simul = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_generation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_size, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_frequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_population, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fra_fitness.SuspendLayout()
        Me.fra_mutation.SuspendLayout()
        Me.fra_simul.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.txt_generation)
        Me.GroupBox1.Controls.Add(Me.txt_size)
        Me.GroupBox1.Controls.Add(Me.txt_frequency)
        Me.GroupBox1.Controls.Add(Me.txt_population)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(280, 80)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 9
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txt_generation
        '
        Me.txt_generation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_generation.Location = New System.Drawing.Point(160, 112)
        Me.txt_generation.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_generation.Name = "txt_generation"
        Me.txt_generation.Size = New System.Drawing.Size(104, 21)
        Me.txt_generation.TabIndex = 3
        Me.txt_generation.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txt_size
        '
        Me.txt_size.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.Location = New System.Drawing.Point(160, 48)
        Me.txt_size.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(104, 21)
        Me.txt_size.TabIndex = 1
        Me.txt_size.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txt_frequency
        '
        Me.txt_frequency.DecimalPlaces = 4
        Me.txt_frequency.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_frequency.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.txt_frequency.Location = New System.Drawing.Point(160, 80)
        Me.txt_frequency.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txt_frequency.Name = "txt_frequency"
        Me.txt_frequency.Size = New System.Drawing.Size(104, 21)
        Me.txt_frequency.TabIndex = 2
        Me.txt_frequency.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'txt_population
        '
        Me.txt_population.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_population.Location = New System.Drawing.Point(160, 16)
        Me.txt_population.Name = "txt_population"
        Me.txt_population.Size = New System.Drawing.Size(104, 21)
        Me.txt_population.TabIndex = 0
        Me.txt_population.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Number of generations"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Initial frequency [P(A)]"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Population size"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Number of populations"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.IsAutoScrollRange = True
        Me.maingraph.Location = New System.Drawing.Point(16, 168)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(512, 392)
        Me.maingraph.TabIndex = 1
        '
        'secondarygraph
        '
        Me.secondarygraph.EditButtons = System.Windows.Forms.MouseButtons.None
        Me.secondarygraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.secondarygraph.Location = New System.Drawing.Point(568, 280)
        Me.secondarygraph.Name = "secondarygraph"
        Me.secondarygraph.ScrollGrace = 0
        Me.secondarygraph.ScrollMaxX = 0
        Me.secondarygraph.ScrollMaxY = 0
        Me.secondarygraph.ScrollMaxY2 = 0
        Me.secondarygraph.ScrollMinX = 0
        Me.secondarygraph.ScrollMinY = 0
        Me.secondarygraph.ScrollMinY2 = 0
        Me.secondarygraph.Size = New System.Drawing.Size(184, 160)
        Me.secondarygraph.TabIndex = 2
        '
        'fra_fitness
        '
        Me.fra_fitness.Controls.Add(Me.txt_w3)
        Me.fra_fitness.Controls.Add(Me.txt_w2)
        Me.fra_fitness.Controls.Add(Me.txt_w1)
        Me.fra_fitness.Controls.Add(Me.Label7)
        Me.fra_fitness.Controls.Add(Me.Label5)
        Me.fra_fitness.Controls.Add(Me.Label4)
        Me.fra_fitness.Location = New System.Drawing.Point(384, 16)
        Me.fra_fitness.Name = "fra_fitness"
        Me.fra_fitness.Size = New System.Drawing.Size(144, 144)
        Me.fra_fitness.TabIndex = 3
        Me.fra_fitness.TabStop = False
        Me.fra_fitness.Text = "Fitness coefficients"
        Me.fra_fitness.Visible = False
        '
        'txt_w3
        '
        Me.txt_w3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w3.Location = New System.Drawing.Point(64, 88)
        Me.txt_w3.Name = "txt_w3"
        Me.txt_w3.Size = New System.Drawing.Size(64, 21)
        Me.txt_w3.TabIndex = 6
        Me.txt_w3.Text = "1"
        '
        'txt_w2
        '
        Me.txt_w2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w2.Location = New System.Drawing.Point(64, 56)
        Me.txt_w2.Name = "txt_w2"
        Me.txt_w2.Size = New System.Drawing.Size(64, 21)
        Me.txt_w2.TabIndex = 5
        Me.txt_w2.Text = "1"
        '
        'txt_w1
        '
        Me.txt_w1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w1.Location = New System.Drawing.Point(64, 24)
        Me.txt_w1.Name = "txt_w1"
        Me.txt_w1.Size = New System.Drawing.Size(64, 21)
        Me.txt_w1.TabIndex = 4
        Me.txt_w1.Text = "1"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "w2"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "w3"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "w1"
        '
        'fra_mutation
        '
        Me.fra_mutation.Controls.Add(Me.txt_m)
        Me.fra_mutation.Controls.Add(Me.txt_v)
        Me.fra_mutation.Controls.Add(Me.Label8)
        Me.fra_mutation.Controls.Add(Me.Label10)
        Me.fra_mutation.Location = New System.Drawing.Point(544, 16)
        Me.fra_mutation.Name = "fra_mutation"
        Me.fra_mutation.Size = New System.Drawing.Size(144, 144)
        Me.fra_mutation.TabIndex = 4
        Me.fra_mutation.TabStop = False
        Me.fra_mutation.Text = "Mutation rates"
        Me.fra_mutation.Visible = False
        '
        'txt_m
        '
        Me.txt_m.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_m.Location = New System.Drawing.Point(56, 24)
        Me.txt_m.Name = "txt_m"
        Me.txt_m.Size = New System.Drawing.Size(64, 21)
        Me.txt_m.TabIndex = 7
        Me.txt_m.Text = "0"
        '
        'txt_v
        '
        Me.txt_v.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_v.Location = New System.Drawing.Point(56, 64)
        Me.txt_v.Name = "txt_v"
        Me.txt_v.Size = New System.Drawing.Size(64, 21)
        Me.txt_v.TabIndex = 8
        Me.txt_v.Text = "0"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "v"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "m"
        '
        'lbl_fixed
        '
        Me.lbl_fixed.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fixed.Location = New System.Drawing.Point(536, 168)
        Me.lbl_fixed.Name = "lbl_fixed"
        Me.lbl_fixed.Size = New System.Drawing.Size(72, 16)
        Me.lbl_fixed.TabIndex = 33
        Me.lbl_fixed.Text = "Fixed"
        '
        'lbl_lost
        '
        Me.lbl_lost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lost.Location = New System.Drawing.Point(536, 496)
        Me.lbl_lost.Name = "lbl_lost"
        Me.lbl_lost.Size = New System.Drawing.Size(48, 16)
        Me.lbl_lost.TabIndex = 34
        Me.lbl_lost.Text = "Lost"
        '
        'fra_simul
        '
        Me.fra_simul.Controls.Add(Me.pbr_simul)
        Me.fra_simul.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_simul.Location = New System.Drawing.Point(208, 216)
        Me.fra_simul.Name = "fra_simul"
        Me.fra_simul.Size = New System.Drawing.Size(440, 40)
        Me.fra_simul.TabIndex = 35
        Me.fra_simul.TabStop = False
        Me.fra_simul.Text = "Simulating please wait ..."
        Me.fra_simul.Visible = False
        '
        'pbr_simul
        '
        Me.pbr_simul.Location = New System.Drawing.Point(24, 17)
        Me.pbr_simul.Name = "pbr_simul"
        Me.pbr_simul.Size = New System.Drawing.Size(400, 16)
        Me.pbr_simul.TabIndex = 0
        '
        'Drift
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(774, 572)
        Me.Controls.Add(Me.fra_simul)
        Me.Controls.Add(Me.lbl_lost)
        Me.Controls.Add(Me.lbl_fixed)
        Me.Controls.Add(Me.fra_mutation)
        Me.Controls.Add(Me.fra_fitness)
        Me.Controls.Add(Me.secondarygraph)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Drift"
        Me.Text = "Drift"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.txt_generation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_size, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_frequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_population, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fra_fitness.ResumeLayout(False)
        Me.fra_mutation.ResumeLayout(False)
        Me.fra_simul.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Drift_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If driftType = 2 Then
            Me.fra_fitness.Visible = True
        ElseIf driftType = 3 Then
            Me.fra_mutation.Visible = True
            Me.fra_mutation.Left = 384
        ElseIf driftType = 4 Then
            Me.fra_fitness.Visible = True
            Me.fra_mutation.Visible = True
        End If

        SetGraph(maingraph)
        SetSecondaryGraph(secondarygraph)

    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim result As Boolean

        populations = Val(txt_population.Text)
        generations = Val(txt_generation.Text)
        n = 2 * Val(txt_size.Text)
        p0 = Val(txt_frequency.Text)

        If driftType = 2 Then
            dw1 = Val(txt_w1.Text)
            dw2 = Val(txt_w2.Text)
            dw3 = Val(txt_w3.Text)
            If dw1 >= dw2 And dw2 >= dw3 Then
                dw2 = dw2 / dw1
                dw3 = dw3 / dw1
                dw1 = 1
            ElseIf dw2 >= dw1 And dw2 >= dw3 Then
                dw1 = dw1 / dw2
                dw3 = dw3 / dw2
                dw2 = 1
            Else
                dw2 = dw2 / dw3
                dw1 = dw1 / dw3
                dw3 = 1
            End If
        End If

        result = VerifyErrors()
        If result = True Then Exit Sub
        If driftMut = True Then
            drift_mut_m = Val(txt_m.Text)
            drift_mut_v = Val(txt_v.Text)
        End If
        If driftType = 1 Or driftType = 3 Then
            DoDrift()
        ElseIf driftType = 2 Or driftType = 4 Then
            DoDriftSel()
        End If

    End Sub

    Private Function VerifyErrors()
        'verifies errors in data entering
        'if result = true at the end it breaks the execution

        Dim result As Boolean

        'verifies the number of populations
        If populations > 1000 Or populations <= 0 Then
            MsgBox("The number of populations cannot be over 100 (or under 0). Please restart.", vbExclamation)
            txt_population.Text = ""
            txt_population.Focus()
            result = True
        End If

        'verifies the number of generations
        If generations > 3000 Or generations <= 0 Then
            MsgBox("The number of generations cannot be over 3000 (or under 0). Please restart.", vbExclamation)
            txt_generation.Text = ""
            txt_generation.Focus()
            result = True
        End If

        'verifies the number of individuals
        If n / 2 > 10000 Or n / 2 <= 0 Then
            MsgBox("The number of individuals cannot be over 5000 (or under 0). Please restart.", vbExclamation)
            txt_size.Text = ""
            txt_size.Focus()
            result = True
        End If

        'verifies the initial frequency
        If p0 < 0 Or p0 > 1 Then
            MsgBox("Invalid initial frequency. Please restart.", vbExclamation)
            txt_frequency.Text = ""
            txt_frequency.Focus()
            result = True
        End If
        Me.pbr_simul.Maximum = generations
        Me.pbr_simul.Value = 0

        Return result
    End Function
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

        zgc.Refresh()
        zgc.AxisChange()

    End Sub
    Private Sub SetSecondaryGraph(ByVal zgc As ZedGraphControl)

        zgc.GraphPane.XAxis.IsVisible = True
        zgc.GraphPane.Border.IsVisible = False
        zgc.GraphPane.XAxis.MajorTic.IsOpposite = False
        zgc.GraphPane.XAxis.MinorTic.IsOpposite = False
        zgc.GraphPane.XAxis.Scale.MinorStep = 1
        zgc.GraphPane.XAxis.Scale.Max = 10
        zgc.GraphPane.X2Axis.IsVisible = False
        zgc.GraphPane.YAxis.IsVisible = False
        zgc.GraphPane.Title.IsVisible = False

    End Sub
    Private Sub DoDrift()

        Randomize()

        Dim a As Single
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim ind As Integer
        Dim dominants As Integer
        Dim drift_r As Integer
        Dim drift_d As Integer
        Dim genes(n) As Byte
        ReDim drift_values(populations, generations)
        ReDim drift_values_r(populations, generations)
        ReDim drift_values_d(populations, generations)

        'puts p0 value on the first generation position
        For i = 0 To populations - 1
            drift_values(i, 0) = p0
        Next

        fra_simul.Visible = True
        'simulation
        For i = 1 To generations
            Me.pbr_simul.Value = i
            For j = 0 To populations - 1
                If drift_values(j, i - 1) = 0 Then
                    dominants = 0
                ElseIf drift_values(j, i - 1) = 1 Then
                    dominants = n
                Else
                    For k = 1 To n
                        a = Rnd(1)
                        If a < drift_values(j, i - 1) Then
                            genes(k) = 1
                            dominants = dominants + 1
                        Else
                            genes(k) = 0
                        End If
                    Next
                End If
                'calculates genetic frequencies
                For ind = 1 To n Step 2
                    If genes(ind) = 1 And genes(ind + 1) = 1 Then
                        drift_d = drift_d + 1
                    ElseIf genes(ind) = 0 And genes(ind + 1) = 0 Then
                        drift_r = drift_r + 1
                    End If
                Next
                'calculates  frequency
                drift_values(j, i) = dominants / n
                drift_values_d(j, i) = drift_d / (n / 2)
                drift_values_r(j, i) = drift_r / (n / 2)
                If driftMut = True Then
                    drift_values(j, i) = (drift_values(j, i) * (1 - drift_mut_m)) + ((1 - drift_values(j, i)) * drift_mut_v)
                    'drift_values_d(j, i) = (drift_values_d(j, i) * (1 - drift_mut_m)) + (drift_values_r(j, i) * drift_mut_v)
                    'drift_values_r(j, i) = (drift_values_r(j, i) * (1 - drift_mut_v)) + (drift_values_d(j, i) * drift_mut_m)
                    drift_values_d(j, i) = drift_values(j, i) ^ 2
                    drift_values_r(j, i) = (1 - drift_values(j, i)) ^ 2
                End If
                dominants = 0
                drift_r = 0
                drift_d = 0
            Next
        Next

        For i = 0 To populations - 1
            If drift_values(i, generations) = 0 Then
                lost = lost + 1
            ElseIf drift_values(i, generations) = 1 Then
                fixed = fixed + 1
            End If
        Next
        fra_simul.Visible = False
        lbl_lost.Text = "Lost " & lost
        lbl_fixed.Text = "Fixed " & fixed
        PlotDrift(maingraph)

    End Sub
    Private Sub DoDriftSel()
        'gen, pop, n

        Dim a As Single
        Dim b As Single
        Dim i As Integer
        Dim k As Integer
        Dim j As Integer
        Dim drift_r As Integer
        Dim drift_d As Integer
        Dim genes(n) As Byte
        ReDim drift_values(populations, generations)
        ReDim drift_values_r(populations, generations)
        ReDim drift_values_d(populations, generations)
        Dim chance As Double
        Dim heterozigotes As Integer
        Dim dominants As Integer
        Dim recessives As Integer
        Dim keep As Boolean

        Randomize()
        'puts p0 value on the first generation position
        For i = 0 To populations - 1
            drift_values(i, 0) = p0
        Next
        fra_simul.Visible = True
        'simulation
        For i = 1 To generations
            Me.pbr_simul.Value = i
            For j = 0 To populations - 1
                'checks if the previous frequency value is equal to 1 or 0
                If drift_values(j, i - 1) = 0 Then
                    dominants = 0
                ElseIf drift_values(j, i - 1) = 1 Then
                    dominants = n / 2
                Else
                    While k < n
                        a = Rnd(1)
                        b = Rnd(1)
                        If a < drift_values(j, i - 1) And b < drift_values(j, i - 1) Then
                            chance = Rnd(1)
                            If chance < dw1 Then
                                k = k + 2
                                'genes(k) = 1
                                'genes(k + 1) = 1
                                dominants = dominants + 1
                            End If
                        ElseIf a < drift_values(j, i - 1) And b > drift_values(j, i - 1) _
                        Or a > drift_values(j, i - 1) And b < drift_values(j, i - 1) Then
                            chance = Rnd(1)
                            If chance < dw2 Then
                                k = k + 2
                                'genes(k) = 1
                                'genes(k + 1) = 0
                                heterozigotes = heterozigotes + 1
                            End If
                        Else
                            chance = Rnd(1)
                            If chance < dw3 Then
                                k = k + 2
                                'genes(k) = 0
                                'genes(k + 1) = 0
                                recessives = recessives + 1
                            End If
                        End If
                    End While
                End If
                drift_values(j, i) = (dominants + heterozigotes / 2) / (n / 2)
                drift_values_d(j, i) = dominants / (n / 2)
                drift_values_r(j, i) = recessives / (n / 2)
                If driftMut = True Then
                    drift_values(j, i) = (drift_values(j, i) * (1 - drift_mut_m)) + ((1 - drift_values(j, i)) * drift_mut_v)
                    'drift_values_d(j, i) = ((drift_values_d(j, i) * (1 - drift_mut_m)) + (drift_values_r(j, i) * drift_mut_v)) / (n / 2)
                    'drift_values_r(j, i) = ((drift_values_r(j, i) * (1 - drift_mut_v)) + (drift_values_d(j, i) * drift_mut_m)) / (n / 2)
                    drift_values_d(j, i) = drift_values(j, i) ^ 2
                    drift_values_r(j, i) = (1 - drift_values(j, i)) ^ 2
                End If

                'calculates genetic frequencies
                'calculates  frequency
                'drift_values(j, i) = dominants / n
                'drift_values_d(j, i) = drift_d / (n / 2)
                'drift_values_r(j, i) = drift_r / (n / 2)
                k = 0
                dominants = 0
                heterozigotes = 0
                recessives = 0
                drift_r = 0
                drift_d = 0
            Next
        Next

        'histogeneration = 0
        'ReDim fpn(pop, gen) As Double
        '    For i = 0 To pop
        '        fpn(i, 0) = fp
        '    Next
        '    For i = 0 To populations - 1
        '        If drift_values(i, generations) = 0 Then
        '            lost = lost + 1
        '        ElseIf drift_values(i, generations) = 1 Then
        '            fixed = fixed + 1
        '        End If
        '    Next
        fra_simul.Visible = False
        lbl_lost.Text = "Lost " & lost
        lbl_fixed.Text = "Fixed " & fixed
        PlotDrift(maingraph)
    End Sub
    Private Sub PlotDrift(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim drift_curve As New PointPairList
        Dim i As Integer
        Dim j As Integer
        Dim mcurves As CurveList
        Dim rotator As ColorSymbolRotator
        Dim genarr(generations) As Double

        For i = 0 To generations
            genarr(i) = i
        Next

        For j = 0 To populations - 1
            Dim points As New PointPairList
            For i = 0 To generations
                points.Add(i, drift_values(j, i))
            Next
            zgc.GraphPane.AddCurve("", points, Color.Black, SymbolType.None)
            zgc.Invalidate()
        Next
        zgc.GraphPane.XAxis.Scale.Max = generations
        zgc.GraphPane.XAxis.MajorGrid.IsVisible = True
        zgc.Validate()
        zgc.AxisChange()

    End Sub
End Class
