Imports ZedGraph
Public Class Selection
    Inherits System.Windows.Forms.Form
    Dim w1, w2, w3 As Double
    Dim gentorun_sel As Integer
    Dim d_sel(), h_sel(), d_equi(), h_equi() As Double
    Dim result As Integer
    Friend WithEvents txt_gentorun As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_t As System.Windows.Forms.Label
    Friend WithEvents txt_t As System.Windows.Forms.TextBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents cartgraph As ZedGraph.ZedGraphControl
    Friend WithEvents lbl_w3 As System.Windows.Forms.Label
    Friend WithEvents lbl_w1 As System.Windows.Forms.Label
    Friend WithEvents lbl_w2 As System.Windows.Forms.Label
    Friend WithEvents lbl_6 As System.Windows.Forms.Label
    Friend WithEvents lbl_4 As System.Windows.Forms.Label
    Friend WithEvents lbl_5 As System.Windows.Forms.Label
    Friend WithEvents cmd_switch As System.Windows.Forms.Button
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Dim t As Double

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_h As System.Windows.Forms.TextBox
    Friend WithEvents txt_d As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents sst_selection As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl_3 As System.Windows.Forms.Label
    Friend WithEvents lbl_1 As System.Windows.Forms.Label
    Friend WithEvents lbl_2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pred As System.Windows.Forms.Label
    Friend WithEvents lbl_preh As System.Windows.Forms.Label
    Friend WithEvents lbl_prer As System.Windows.Forms.Label
    Friend WithEvents lbl_prep As System.Windows.Forms.Label
    Friend WithEvents lbl_preq As System.Windows.Forms.Label
    Friend WithEvents lbl_postq As System.Windows.Forms.Label
    Friend WithEvents lbl_postp As System.Windows.Forms.Label
    Friend WithEvents lbl_postr As System.Windows.Forms.Label
    Friend WithEvents lbl_posth As System.Windows.Forms.Label
    Friend WithEvents lbl_postd As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_w3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_w2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_w1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Selection))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl_w3 = New System.Windows.Forms.Label
        Me.lbl_w1 = New System.Windows.Forms.Label
        Me.lbl_w2 = New System.Windows.Forms.Label
        Me.lbl_6 = New System.Windows.Forms.Label
        Me.lbl_4 = New System.Windows.Forms.Label
        Me.lbl_5 = New System.Windows.Forms.Label
        Me.lbl_t = New System.Windows.Forms.Label
        Me.txt_t = New System.Windows.Forms.TextBox
        Me.txt_gentorun = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_w3 = New System.Windows.Forms.TextBox
        Me.lbl_3 = New System.Windows.Forms.Label
        Me.lbl_1 = New System.Windows.Forms.Label
        Me.lbl_2 = New System.Windows.Forms.Label
        Me.txt_w2 = New System.Windows.Forms.TextBox
        Me.txt_w1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_h = New System.Windows.Forms.TextBox
        Me.txt_d = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.sst_selection = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lbl_preq = New System.Windows.Forms.Label
        Me.lbl_prep = New System.Windows.Forms.Label
        Me.lbl_prer = New System.Windows.Forms.Label
        Me.lbl_preh = New System.Windows.Forms.Label
        Me.lbl_pred = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lbl_postq = New System.Windows.Forms.Label
        Me.lbl_postp = New System.Windows.Forms.Label
        Me.lbl_postr = New System.Windows.Forms.Label
        Me.lbl_posth = New System.Windows.Forms.Label
        Me.lbl_postd = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.cartgraph = New ZedGraph.ZedGraphControl
        Me.cmd_switch = New System.Windows.Forms.Button
        Me.cmd_save = New System.Windows.Forms.Button
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_gentorun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sst_selection.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_w3)
        Me.GroupBox1.Controls.Add(Me.lbl_w1)
        Me.GroupBox1.Controls.Add(Me.lbl_w2)
        Me.GroupBox1.Controls.Add(Me.lbl_6)
        Me.GroupBox1.Controls.Add(Me.lbl_4)
        Me.GroupBox1.Controls.Add(Me.lbl_5)
        Me.GroupBox1.Controls.Add(Me.lbl_t)
        Me.GroupBox1.Controls.Add(Me.txt_t)
        Me.GroupBox1.Controls.Add(Me.txt_gentorun)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_w3)
        Me.GroupBox1.Controls.Add(Me.lbl_3)
        Me.GroupBox1.Controls.Add(Me.lbl_1)
        Me.GroupBox1.Controls.Add(Me.lbl_2)
        Me.GroupBox1.Controls.Add(Me.txt_w2)
        Me.GroupBox1.Controls.Add(Me.txt_w1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_h)
        Me.GroupBox1.Controls.Add(Me.txt_d)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(296, 208)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lbl_w3
        '
        Me.lbl_w3.AutoSize = True
        Me.lbl_w3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_w3.Location = New System.Drawing.Point(53, 178)
        Me.lbl_w3.Name = "lbl_w3"
        Me.lbl_w3.Size = New System.Drawing.Size(13, 14)
        Me.lbl_w3.TabIndex = 56
        Me.lbl_w3.Text = "0"
        Me.lbl_w3.Visible = False
        '
        'lbl_w1
        '
        Me.lbl_w1.AutoSize = True
        Me.lbl_w1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_w1.Location = New System.Drawing.Point(53, 136)
        Me.lbl_w1.Name = "lbl_w1"
        Me.lbl_w1.Size = New System.Drawing.Size(13, 14)
        Me.lbl_w1.TabIndex = 55
        Me.lbl_w1.Text = "0"
        Me.lbl_w1.Visible = False
        '
        'lbl_w2
        '
        Me.lbl_w2.AutoSize = True
        Me.lbl_w2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_w2.Location = New System.Drawing.Point(53, 157)
        Me.lbl_w2.Name = "lbl_w2"
        Me.lbl_w2.Size = New System.Drawing.Size(13, 14)
        Me.lbl_w2.TabIndex = 54
        Me.lbl_w2.Text = "0"
        Me.lbl_w2.Visible = False
        '
        'lbl_6
        '
        Me.lbl_6.AutoSize = True
        Me.lbl_6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_6.Location = New System.Drawing.Point(16, 178)
        Me.lbl_6.Name = "lbl_6"
        Me.lbl_6.Size = New System.Drawing.Size(22, 14)
        Me.lbl_6.TabIndex = 53
        Me.lbl_6.Text = "w3"
        Me.lbl_6.Visible = False
        '
        'lbl_4
        '
        Me.lbl_4.AutoSize = True
        Me.lbl_4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_4.Location = New System.Drawing.Point(16, 136)
        Me.lbl_4.Name = "lbl_4"
        Me.lbl_4.Size = New System.Drawing.Size(22, 14)
        Me.lbl_4.TabIndex = 52
        Me.lbl_4.Text = "w1"
        Me.lbl_4.Visible = False
        '
        'lbl_5
        '
        Me.lbl_5.AutoSize = True
        Me.lbl_5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_5.Location = New System.Drawing.Point(16, 157)
        Me.lbl_5.Name = "lbl_5"
        Me.lbl_5.Size = New System.Drawing.Size(22, 14)
        Me.lbl_5.TabIndex = 51
        Me.lbl_5.Text = "w2"
        Me.lbl_5.Visible = False
        '
        'lbl_t
        '
        Me.lbl_t.AutoSize = True
        Me.lbl_t.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_t.Location = New System.Drawing.Point(27, 111)
        Me.lbl_t.Name = "lbl_t"
        Me.lbl_t.Size = New System.Drawing.Size(11, 14)
        Me.lbl_t.TabIndex = 50
        Me.lbl_t.Text = "t"
        Me.lbl_t.Visible = False
        '
        'txt_t
        '
        Me.txt_t.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_t.Location = New System.Drawing.Point(56, 103)
        Me.txt_t.Name = "txt_t"
        Me.txt_t.Size = New System.Drawing.Size(49, 22)
        Me.txt_t.TabIndex = 6
        Me.txt_t.Text = "0.9"
        Me.txt_t.Visible = False
        '
        'txt_gentorun
        '
        Me.txt_gentorun.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gentorun.Location = New System.Drawing.Point(166, 51)
        Me.txt_gentorun.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_gentorun.Name = "txt_gentorun"
        Me.txt_gentorun.Size = New System.Drawing.Size(72, 22)
        Me.txt_gentorun.TabIndex = 2
        Me.txt_gentorun.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 21)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Number of generations"
        '
        'txt_w3
        '
        Me.txt_w3.AcceptsReturn = True
        Me.txt_w3.BackColor = System.Drawing.Color.White
        Me.txt_w3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w3.Location = New System.Drawing.Point(226, 93)
        Me.txt_w3.Name = "txt_w3"
        Me.txt_w3.Size = New System.Drawing.Size(56, 22)
        Me.txt_w3.TabIndex = 5
        Me.txt_w3.Text = "1"
        '
        'lbl_3
        '
        Me.lbl_3.AutoSize = True
        Me.lbl_3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_3.Location = New System.Drawing.Point(197, 93)
        Me.lbl_3.Name = "lbl_3"
        Me.lbl_3.Size = New System.Drawing.Size(22, 14)
        Me.lbl_3.TabIndex = 46
        Me.lbl_3.Text = "w3"
        '
        'lbl_1
        '
        Me.lbl_1.AutoSize = True
        Me.lbl_1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_1.Location = New System.Drawing.Point(16, 93)
        Me.lbl_1.Name = "lbl_1"
        Me.lbl_1.Size = New System.Drawing.Size(22, 14)
        Me.lbl_1.TabIndex = 45
        Me.lbl_1.Text = "w1"
        '
        'lbl_2
        '
        Me.lbl_2.AutoSize = True
        Me.lbl_2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_2.Location = New System.Drawing.Point(111, 93)
        Me.lbl_2.Name = "lbl_2"
        Me.lbl_2.Size = New System.Drawing.Size(22, 14)
        Me.lbl_2.TabIndex = 44
        Me.lbl_2.Text = "w2"
        '
        'txt_w2
        '
        Me.txt_w2.AcceptsReturn = True
        Me.txt_w2.BackColor = System.Drawing.Color.White
        Me.txt_w2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w2.Location = New System.Drawing.Point(140, 93)
        Me.txt_w2.Name = "txt_w2"
        Me.txt_w2.Size = New System.Drawing.Size(51, 22)
        Me.txt_w2.TabIndex = 4
        Me.txt_w2.Text = "2"
        '
        'txt_w1
        '
        Me.txt_w1.BackColor = System.Drawing.Color.White
        Me.txt_w1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w1.Location = New System.Drawing.Point(56, 93)
        Me.txt_w1.Name = "txt_w1"
        Me.txt_w1.Size = New System.Drawing.Size(49, 22)
        Me.txt_w1.TabIndex = 3
        Me.txt_w1.Text = "1"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "P(AA)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "P(Aa)"
        '
        'txt_h
        '
        Me.txt_h.AcceptsReturn = True
        Me.txt_h.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_h.Location = New System.Drawing.Point(56, 54)
        Me.txt_h.Name = "txt_h"
        Me.txt_h.Size = New System.Drawing.Size(64, 22)
        Me.txt_h.TabIndex = 1
        Me.txt_h.Text = "0.5"
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(56, 24)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 22)
        Me.txt_d.TabIndex = 0
        Me.txt_d.Text = "0.2"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(184, 136)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(72, 56)
        Me.cmd_ok.TabIndex = 7
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(324, 12)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(470, 470)
        Me.maingraph.TabIndex = 3
        '
        'sst_selection
        '
        Me.sst_selection.Controls.Add(Me.TabPage1)
        Me.sst_selection.Controls.Add(Me.TabPage2)
        Me.sst_selection.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sst_selection.Location = New System.Drawing.Point(8, 224)
        Me.sst_selection.Name = "sst_selection"
        Me.sst_selection.SelectedIndex = 0
        Me.sst_selection.Size = New System.Drawing.Size(296, 192)
        Me.sst_selection.TabIndex = 4
        Me.sst_selection.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage1.Controls.Add(Me.lbl_preq)
        Me.TabPage1.Controls.Add(Me.lbl_prep)
        Me.TabPage1.Controls.Add(Me.lbl_prer)
        Me.TabPage1.Controls.Add(Me.lbl_preh)
        Me.TabPage1.Controls.Add(Me.lbl_pred)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.Red
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(288, 166)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pre-selection values"
        '
        'lbl_preq
        '
        Me.lbl_preq.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_preq.Location = New System.Drawing.Point(176, 64)
        Me.lbl_preq.Name = "lbl_preq"
        Me.lbl_preq.Size = New System.Drawing.Size(56, 16)
        Me.lbl_preq.TabIndex = 41
        '
        'lbl_prep
        '
        Me.lbl_prep.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prep.Location = New System.Drawing.Point(176, 16)
        Me.lbl_prep.Name = "lbl_prep"
        Me.lbl_prep.Size = New System.Drawing.Size(56, 16)
        Me.lbl_prep.TabIndex = 40
        '
        'lbl_prer
        '
        Me.lbl_prer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prer.Location = New System.Drawing.Point(72, 64)
        Me.lbl_prer.Name = "lbl_prer"
        Me.lbl_prer.Size = New System.Drawing.Size(56, 16)
        Me.lbl_prer.TabIndex = 39
        '
        'lbl_preh
        '
        Me.lbl_preh.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_preh.Location = New System.Drawing.Point(72, 40)
        Me.lbl_preh.Name = "lbl_preh"
        Me.lbl_preh.Size = New System.Drawing.Size(56, 16)
        Me.lbl_preh.TabIndex = 38
        '
        'lbl_pred
        '
        Me.lbl_pred.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pred.Location = New System.Drawing.Point(72, 16)
        Me.lbl_pred.Name = "lbl_pred"
        Me.lbl_pred.Size = New System.Drawing.Size(56, 16)
        Me.lbl_pred.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(152, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 15)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "p:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(152, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 15)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "q:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 15)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "P(aa):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "P(Aa):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "P(AA):"
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.lbl_postq)
        Me.TabPage2.Controls.Add(Me.lbl_postp)
        Me.TabPage2.Controls.Add(Me.lbl_postr)
        Me.TabPage2.Controls.Add(Me.lbl_posth)
        Me.TabPage2.Controls.Add(Me.lbl_postd)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(288, 166)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Post-selection values"
        '
        'lbl_postq
        '
        Me.lbl_postq.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_postq.Location = New System.Drawing.Point(176, 64)
        Me.lbl_postq.Name = "lbl_postq"
        Me.lbl_postq.Size = New System.Drawing.Size(56, 16)
        Me.lbl_postq.TabIndex = 51
        '
        'lbl_postp
        '
        Me.lbl_postp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_postp.Location = New System.Drawing.Point(176, 16)
        Me.lbl_postp.Name = "lbl_postp"
        Me.lbl_postp.Size = New System.Drawing.Size(56, 16)
        Me.lbl_postp.TabIndex = 50
        '
        'lbl_postr
        '
        Me.lbl_postr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_postr.Location = New System.Drawing.Point(72, 64)
        Me.lbl_postr.Name = "lbl_postr"
        Me.lbl_postr.Size = New System.Drawing.Size(56, 16)
        Me.lbl_postr.TabIndex = 49
        '
        'lbl_posth
        '
        Me.lbl_posth.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posth.Location = New System.Drawing.Point(72, 40)
        Me.lbl_posth.Name = "lbl_posth"
        Me.lbl_posth.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posth.TabIndex = 48
        '
        'lbl_postd
        '
        Me.lbl_postd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_postd.Location = New System.Drawing.Point(72, 16)
        Me.lbl_postd.Name = "lbl_postd"
        Me.lbl_postd.Size = New System.Drawing.Size(56, 16)
        Me.lbl_postd.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(152, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 15)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "p:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(152, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(17, 15)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "q:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 15)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "P(aa):"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 15)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "P(Aa):"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(16, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 15)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "P(AA):"
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(196, 427)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(108, 55)
        Me.cmd_clear.TabIndex = 23
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cartgraph
        '
        Me.cartgraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cartgraph.Location = New System.Drawing.Point(324, 12)
        Me.cartgraph.Name = "cartgraph"
        Me.cartgraph.ScrollGrace = 0
        Me.cartgraph.ScrollMaxX = 0
        Me.cartgraph.ScrollMaxY = 0
        Me.cartgraph.ScrollMaxY2 = 0
        Me.cartgraph.ScrollMinX = 0
        Me.cartgraph.ScrollMinY = 0
        Me.cartgraph.ScrollMinY2 = 0
        Me.cartgraph.Size = New System.Drawing.Size(470, 470)
        Me.cartgraph.TabIndex = 24
        '
        'cmd_switch
        '
        Me.cmd_switch.Location = New System.Drawing.Point(324, 490)
        Me.cmd_switch.Name = "cmd_switch"
        Me.cmd_switch.Size = New System.Drawing.Size(160, 21)
        Me.cmd_switch.TabIndex = 25
        Me.cmd_switch.Text = "Switch to triangular coord."
        Me.cmd_switch.UseVisualStyleBackColor = True
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(8, 427)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(112, 56)
        Me.cmd_save.TabIndex = 26
        Me.cmd_save.Text = "Save values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(719, 489)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Selection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(817, 519)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.cmd_switch)
        Me.Controls.Add(Me.cartgraph)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.sst_selection)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Selection"
        Me.Text = "Selection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_gentorun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sst_selection.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        w1 = Val(txt_w1.Text)
        w2 = Val(txt_w2.Text)
        w3 = Val(txt_w3.Text)

        gentorun_sel = Val(txt_gentorun.Value)

        result = 0

        ReDim d_sel(gentorun_sel)
        ReDim h_sel(gentorun_sel)
        ReDim d_equi(gentorun_sel)
        ReDim h_equi(gentorun_sel)

        d_equi(0) = Val(txt_d.Text)
        h_equi(0) = Val(txt_h.Text)
        If txt_d.Text = "" Then txt_d.Text = 0
        If txt_h.Text = "" Then txt_h.Text = 0

        Call ErrorCheck()

        'error verification step 2
        If result = 1 Then
            txt_d.Text = ""
            txt_d.Focus()
            Exit Sub
        ElseIf result = 2 Then
            txt_h.Text = ""
            txt_h.Focus()
            Exit Sub
        ElseIf result = 3 Then
            txt_d.Text = ""
            txt_h.Text = ""
            txt_d.Focus()
            Exit Sub
        End If
        If freq_dep = True Then
            t = Val(txt_t.Text)
            w1 = 1 - t * d_equi(0)
            w2 = 1 - t * h_equi(0)
            w3 = 1 - t * (1 - d_equi(0) - h_equi(0))
        End If

        h_sel(0) = h_equi(0) * w2 / (d_equi(0) * w1 + h_equi(0) * w2 + (1 - d_equi(0) - h_equi(0)) * w3)
        d_sel(0) = d_equi(0) * w1 / (d_equi(0) * w1 + h_equi(0) * w2 + (1 - d_equi(0) - h_equi(0)) * w3)

        PlotPoints(maingraph)
        PlotCartesian(cartgraph)
        Captions()
        Me.sst_selection.Visible = True
        cmd_save.Enabled = True
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

        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12

        baseline.Add(0, 0)
        baseline.Add(1, 0)
        Dim base As LineItem = canvas.AddCurve("", baseline, Color.Black, SymbolType.None)

        side1.Add(0.5, 1)
        side1.Add(1, 0)
        Dim s1 As LineItem = canvas.AddCurve("", side1, Color.Black, SymbolType.None)

        side2.Add(0, 0)
        side2.Add(0.5, 1)
        Dim s2 As LineItem = canvas.AddCurve("", side2, Color.Black, SymbolType.None)

        For i = 0 To 1 Step 1 / 1000
            parabola.Add(i, 2 * i * (1 - i))
            'frm_panmixia.pct_triangle.PSet (d_parabola, 1 - h_parabola), RGB(100, 100, 100)
        Next

        Dim parab As LineItem = canvas.AddCurve("", parabola, Color.Gray, SymbolType.None)

        zgc.Refresh()

        'SetDeltaGraph(deltagraph)

    End Sub

    Private Sub SetGraph2(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane

        canvas.XAxis.Title.Text = "Generations"
        canvas.YAxis.Title.Text = "Frequencies"
        canvas.Title.IsVisible = False

        canvas.YAxis.Scale.Max = 1
        canvas.YAxis.Scale.Min = 0

        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12

        zgc.Refresh()

        'SetDeltaGraph(deltagraph)

    End Sub


    Private Sub SetDeltaGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.XAxis.IsVisible = False
        canvas.YAxis.IsVisible = False
        canvas.Title.IsVisible = False
    End Sub

    Private Sub PlotDelta(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim max_delta, min_delta, delta_sel As Double
        Dim ax, bx, wbar As Double

        For ax = 0 To 1 Step 1 / 2000
            bx = 1 - ax
            wbar = (bx * bx * w1) + (2 * bx * ax * w2) + (ax * ax * w3)
            delta_sel = ax * (1 - ax) * (ax * (w1 - 2 * w2 + w3) - (w1 - w2)) / wbar
            If delta_sel > max_delta Then
                max_delta = delta_sel
            End If
            If delta_sel < min_delta Then
                min_delta = delta_sel
            End If
        Next

    End Sub

    Private Sub Selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
        SetGraph2(cartgraph)
        If freq_dep = True Then
            lbl_1.Visible = False
            lbl_2.Visible = False
            lbl_3.Visible = False
            lbl_4.Visible = True
            lbl_5.Visible = True
            lbl_6.Visible = True
            txt_t.Visible = True
            lbl_t.Visible = True
            txt_w1.Visible = False
            txt_w2.Visible = False
            txt_w3.Visible = False
            lbl_w1.Visible = True
            lbl_w2.Visible = True
            lbl_w3.Visible = True
        End If
    End Sub
    Private Sub PlotCartesian(ByVal zgc As ZedGraphControl)

        Dim i As Integer
        Dim canvas As GraphPane = zgc.GraphPane
        Dim plist, p2list, pq2list, q2list As New PointPairList

        For i = 0 To gentorun_sel
            plist.Add(i, (d_sel(i) + h_sel(i) / 2))
            p2list.Add(i, d_sel(i))
            pq2list.Add(i, h_sel(i))
            q2list.Add(i, 1 - d_sel(i) - h_sel(i))
        Next

        Dim pcurve As LineItem = canvas.AddCurve("p", plist, Color.Red, SymbolType.None)
        Dim p2curve As LineItem = canvas.AddCurve("P(AA)", p2list, Color.Green, SymbolType.None)
        Dim q2curve As LineItem = canvas.AddCurve("P(aa)", q2list, Color.Blue, SymbolType.None)
        Dim pq2curve As LineItem = canvas.AddCurve("P(Aa)", pq2list, Color.Gray, SymbolType.None)


        canvas.XAxis.Scale.Max = gentorun_sel
        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False

        zgc.AxisChange()
        zgc.Refresh()

    End Sub
    Private Sub PlotPoints(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim selvalues, equivalues, line As New PointPairList
        Dim i As Integer

        selvalues.Add(d_sel(0) + h_sel(0) / 2, h_sel(0))
        equivalues.Add(d_equi(0) + h_equi(0) / 2, h_equi(0))
        line.Add(d_equi(0) + h_equi(0) / 2, h_equi(0))
        line.Add(d_sel(0) + h_sel(0) / 2, h_sel(0))
        For i = 1 To gentorun_sel
            d_equi(i) = (d_sel(i - 1) + h_sel(i - 1) / 2) * (d_sel(i - 1) + h_sel(i - 1) / 2)
            h_equi(i) = 2 * (d_sel(i - 1) + h_sel(i - 1) / 2) * (1 - (d_sel(i - 1) + h_sel(i - 1) / 2))
            If freq_dep = True Then
                w1 = 1 - t * (d_equi(i) + h_equi(i) / 2) * (d_equi(i) + h_equi(i) / 2)
                w2 = 1 - t * (2 * (d_equi(i) + h_equi(i) / 2) * (h_equi(i) / 2 + 1 - h_equi(i) - d_equi(i)))
                w3 = 1 - t * (1 - d_equi(i) - h_equi(i) / 2) * (1 - d_equi(i) - h_equi(i) / 2)
                lbl_w1.Text = Format(w1, "0.0000")
                lbl_w2.Text = Format(w2, "0.0000")
                lbl_w3.Text = Format(w3, "0.0000")
            End If
            h_sel(i) = h_equi(i) * w2 / (d_equi(i) * w1 + h_equi(i) * w2 + (1 - d_equi(i) - h_equi(i)) * w3)
            d_sel(i) = d_equi(i) * w1 / (d_equi(i) * w1 + h_equi(i) * w2 + (1 - d_equi(i) - h_equi(i)) * w3)
            selvalues.Add(d_sel(i) + h_sel(i) / 2, h_sel(i))
            equivalues.Add(d_equi(i) + h_equi(i) / 2, h_equi(i))
            line.Add(d_equi(i) + h_equi(i) / 2, h_equi(i))
            line.Add(d_sel(i) + h_sel(i) / 2, h_sel(i))
        Next

        Dim point1 As LineItem = canvas.AddCurve("", selvalues, Color.Red, SymbolType.Square)
        Dim point2 As LineItem = canvas.AddCurve("", equivalues, Color.Blue, SymbolType.Square)
        Dim conline As LineItem = canvas.AddCurve("", line, Color.LightGray, SymbolType.None)
        point1.Line.IsVisible = False
        point2.Line.IsVisible = False

        zgc.Refresh()
        'If freq_dep = False Then
        '    PlotDelta(deltagraph)
        '    Me.deltagraph.Visible = False
        'End If

    End Sub

    Private Sub ErrorCheck()

        'result = 1 when d is out of bounds
        'result = 2 when h is out of bounds
        'result = 3 when d + h is out of bounds

        'verifies value of d
        If d_equi(0) > 1 Or d_equi(0) < 0 Then
            MsgBox("Invalid frequency of homozygotes AA. Please restart.", vbExclamation)
            result = 1
        End If

        'verifies value of h
        If h_equi(0) > 1 Or h_equi(0) < 0 Then
            MsgBox("Invalid frequency of heterozygotes Aa. Please restart.", vbExclamation)
            result = 2
        End If

        'verifies value of d + h
        If d_equi(0) + h_equi(0) > 1 Then
            MsgBox("P(AA) + P(Aa) are over 1. Please restart.", vbExclamation)
            result = 3
        End If

    End Sub

    Private Sub Captions()
        Me.lbl_postd.Text = Format(d_sel(gentorun_sel), "0.00000")
        Me.lbl_posth.Text = Format(h_sel(gentorun_sel), "0.00000")
        Me.lbl_postr.Text = Format(1 - h_sel(gentorun_sel) - d_sel(gentorun_sel), "0.00000")
        Me.lbl_postp.Text = Format(d_sel(gentorun_sel) + h_sel(gentorun_sel) / 2, "0.00000")
        Me.lbl_postq.Text = Format(1 - (d_sel(gentorun_sel) + h_sel(gentorun_sel) / 2), "0.00000")

        'Me.lbl_pred.Text = Format(d_equi(gentorun_sel), "0.00000")
        'Me.lbl_preh.Text = Format(h_equi(gentorun_sel), "0.00000")
        'Me.lbl_prer.Text = Format(1 - h_equi(gentorun_sel) - d_equi(gentorun_sel), "0.00000")
        'Me.lbl_prep.Text = Format(d_equi(gentorun_sel) + h_equi(gentorun_sel) / 2, "0.00000")
        'Me.lbl_preq.Text = Format(1 - (d_equi(gentorun_sel) + h_equi(gentorun_sel) / 2), "0.00000")

        Me.lbl_pred.Text = Format(d_equi(0), "0.00000")
        Me.lbl_preh.Text = Format(h_equi(0), "0.00000")
        Me.lbl_prer.Text = Format(1 - h_equi(0) - d_equi(0), "0.00000")
        Me.lbl_prep.Text = Format(d_equi(0) + h_equi(0) / 2, "0.00000")
        Me.lbl_preq.Text = Format(1 - (d_equi(0) + h_equi(0) / 2), "0.00000")

    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(maingraph)
        ClearGraph(cartgraph)
        SetGraph(maingraph)
        SetGraph2(cartgraph)
        sst_selection.Visible = False
    End Sub
    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub

    Private Sub cmd_switch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_switch.Click
        If cmd_switch.Text = "Switch to triangular coord." Then
            cmd_switch.Text = "Switch to cartesian coord."
            maingraph.BringToFront()
        Else
            cmd_switch.Text = "Switch to triangular coord."
            maingraph.SendToBack()
        End If
    End Sub


    Private Sub cmd_switch_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_switch.MouseHover
        cmd_switch.Enabled = True
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
                objWriter.WriteLine("Selection - General Model")
                objWriter.WriteLine("Selection coefficients")
                objWriter.WriteLine("w1 = " & w1)
                objWriter.WriteLine("w2 = " & w2)
                objWriter.WriteLine("w3 = " & w3)

                objWriter.WriteLine("Initial frequencies")
                objWriter.WriteLine("P(AA) = " & d_equi(0))
                objWriter.WriteLine("P(Aa) = " & h_equi(0))
                objWriter.WriteLine("P(aa) = " & 1 - d_equi(0) - h_equi(0))
                objWriter.WriteLine("Generations run : " & gentorun_sel)
                objWriter.WriteLine()
                objWriter.WriteLine("Gen" & vbTab & "d (post)" & vbTab & "h (post)" & vbTab & "d(pre)" & vbTab & "h(pre)")
                For i = 1 To gentorun_sel
                    objWriter.WriteLine(i & vbTab & Format(d_sel(i), "0.0000") & vbTab & Format(h_sel(i), "0.0000") _
                    & vbTab & Format(d_equi(i), "0.0000") & vbTab & Format(h_equi(i), "0.0000"))
                Next
                objWriter.WriteLine()
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/selectiongen.html")
    End Sub
End Class
