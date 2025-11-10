Imports ZedGraph
Public Class Selection
    Inherits System.Windows.Forms.Form
    Dim w1 As Double
    Dim w2 As Double
    Dim w3 As Double
    Dim gentorun_sel As Integer
    Dim d_sel() As Double
    Dim h_sel() As Double
    Dim d_equi() As Double
    Dim h_equi() As Double

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_gentorun As System.Windows.Forms.NumericUpDown
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents sst_selection As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_pred As System.Windows.Forms.Label
    Friend WithEvents lbl_preh As System.Windows.Forms.Label
    Friend WithEvents lbl_prer As System.Windows.Forms.Label
    Friend WithEvents lbl_prep As System.Windows.Forms.Label
    Friend WithEvents lbl_preq As System.Windows.Forms.Label
    Friend WithEvents lbl_posq As System.Windows.Forms.Label
    Friend WithEvents lbl_posp As System.Windows.Forms.Label
    Friend WithEvents lbl_posr As System.Windows.Forms.Label
    Friend WithEvents lbl_posh As System.Windows.Forms.Label
    Friend WithEvents lbl_posd As System.Windows.Forms.Label
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
        Me.txt_w3 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_w2 = New System.Windows.Forms.TextBox
        Me.txt_w1 = New System.Windows.Forms.TextBox
        Me.txt_gentorun = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.lbl_posq = New System.Windows.Forms.Label
        Me.lbl_posp = New System.Windows.Forms.Label
        Me.lbl_posr = New System.Windows.Forms.Label
        Me.lbl_posh = New System.Windows.Forms.Label
        Me.lbl_posd = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_gentorun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sst_selection.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_w3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_w2)
        Me.GroupBox1.Controls.Add(Me.txt_w1)
        Me.GroupBox1.Controls.Add(Me.txt_gentorun)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_h)
        Me.GroupBox1.Controls.Add(Me.txt_d)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 208)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txt_w3
        '
        Me.txt_w3.AcceptsReturn = True
        Me.txt_w3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w3.Location = New System.Drawing.Point(192, 88)
        Me.txt_w3.Name = "txt_w3"
        Me.txt_w3.Size = New System.Drawing.Size(64, 21)
        Me.txt_w3.TabIndex = 5
        Me.txt_w3.Text = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(152, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "w3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(152, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "w1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(152, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 15)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "w2"
        '
        'txt_w2
        '
        Me.txt_w2.AcceptsReturn = True
        Me.txt_w2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w2.Location = New System.Drawing.Point(192, 56)
        Me.txt_w2.Name = "txt_w2"
        Me.txt_w2.Size = New System.Drawing.Size(64, 21)
        Me.txt_w2.TabIndex = 4
        Me.txt_w2.Text = "1"
        '
        'txt_w1
        '
        Me.txt_w1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_w1.Location = New System.Drawing.Point(192, 24)
        Me.txt_w1.Name = "txt_w1"
        Me.txt_w1.Size = New System.Drawing.Size(64, 21)
        Me.txt_w1.TabIndex = 3
        Me.txt_w1.Text = "1"
        '
        'txt_gentorun
        '
        Me.txt_gentorun.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gentorun.Location = New System.Drawing.Point(48, 136)
        Me.txt_gentorun.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_gentorun.Name = "txt_gentorun"
        Me.txt_gentorun.Size = New System.Drawing.Size(72, 21)
        Me.txt_gentorun.TabIndex = 2
        Me.txt_gentorun.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 40)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Number of generations"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "P(AA)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "P(Aa)"
        '
        'txt_h
        '
        Me.txt_h.AcceptsReturn = True
        Me.txt_h.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_h.Location = New System.Drawing.Point(56, 54)
        Me.txt_h.Name = "txt_h"
        Me.txt_h.Size = New System.Drawing.Size(64, 21)
        Me.txt_h.TabIndex = 1
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(56, 24)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 21)
        Me.txt_d.TabIndex = 0
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(184, 136)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(72, 56)
        Me.cmd_ok.TabIndex = 6
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(328, 16)
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
        Me.sst_selection.Controls.Add(Me.TabPage3)
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
        Me.TabPage1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.Red
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(288, 166)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pre-selection values"
        '
        'lbl_preq
        '
        Me.lbl_preq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_preq.Location = New System.Drawing.Point(176, 64)
        Me.lbl_preq.Name = "lbl_preq"
        Me.lbl_preq.Size = New System.Drawing.Size(56, 16)
        Me.lbl_preq.TabIndex = 41
        '
        'lbl_prep
        '
        Me.lbl_prep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prep.Location = New System.Drawing.Point(176, 16)
        Me.lbl_prep.Name = "lbl_prep"
        Me.lbl_prep.Size = New System.Drawing.Size(56, 16)
        Me.lbl_prep.TabIndex = 40
        '
        'lbl_prer
        '
        Me.lbl_prer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prer.Location = New System.Drawing.Point(72, 64)
        Me.lbl_prer.Name = "lbl_prer"
        Me.lbl_prer.Size = New System.Drawing.Size(56, 16)
        Me.lbl_prer.TabIndex = 39
        '
        'lbl_preh
        '
        Me.lbl_preh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_preh.Location = New System.Drawing.Point(72, 40)
        Me.lbl_preh.Name = "lbl_preh"
        Me.lbl_preh.Size = New System.Drawing.Size(56, 16)
        Me.lbl_preh.TabIndex = 38
        '
        'lbl_pred
        '
        Me.lbl_pred.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pred.Location = New System.Drawing.Point(72, 16)
        Me.lbl_pred.Name = "lbl_pred"
        Me.lbl_pred.Size = New System.Drawing.Size(56, 16)
        Me.lbl_pred.TabIndex = 37
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(152, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 15)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "p:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(152, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 15)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "q:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 15)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "P(aa):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 15)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "P(Aa):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 15)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "P(AA):"
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage2.Controls.Add(Me.lbl_posq)
        Me.TabPage2.Controls.Add(Me.lbl_posp)
        Me.TabPage2.Controls.Add(Me.lbl_posr)
        Me.TabPage2.Controls.Add(Me.lbl_posh)
        Me.TabPage2.Controls.Add(Me.lbl_posd)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(288, 166)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Post-selection values"
        '
        'lbl_posq
        '
        Me.lbl_posq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posq.Location = New System.Drawing.Point(176, 64)
        Me.lbl_posq.Name = "lbl_posq"
        Me.lbl_posq.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posq.TabIndex = 51
        '
        'lbl_posp
        '
        Me.lbl_posp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posp.Location = New System.Drawing.Point(176, 16)
        Me.lbl_posp.Name = "lbl_posp"
        Me.lbl_posp.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posp.TabIndex = 50
        '
        'lbl_posr
        '
        Me.lbl_posr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posr.Location = New System.Drawing.Point(72, 64)
        Me.lbl_posr.Name = "lbl_posr"
        Me.lbl_posr.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posr.TabIndex = 49
        '
        'lbl_posh
        '
        Me.lbl_posh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posh.Location = New System.Drawing.Point(72, 40)
        Me.lbl_posh.Name = "lbl_posh"
        Me.lbl_posh.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posh.TabIndex = 48
        '
        'lbl_posd
        '
        Me.lbl_posd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_posd.Location = New System.Drawing.Point(72, 16)
        Me.lbl_posd.Name = "lbl_posd"
        Me.lbl_posd.Size = New System.Drawing.Size(56, 16)
        Me.lbl_posd.TabIndex = 47
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(152, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 15)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "p:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(152, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(17, 15)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "q:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(16, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 15)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "P(aa):"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(16, 40)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 15)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "P(Aa):"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(16, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 15)
        Me.Label21.TabIndex = 42
        Me.Label21.Text = "P(AA):"
        '
        'TabPage3
        '
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TabPage3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(288, 166)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Delta-q"
        '
        'Selection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(806, 508)
        Me.Controls.Add(Me.sst_selection)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
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

        Me.sst_selection.Visible = True

        w1 = Val(txt_w1.Text)
        w2 = Val(txt_w2.Text)
        w3 = Val(txt_w3.Text)

        'result_sel = 0

        gentorun_sel = Val(txt_gentorun.Value)

        ReDim d_sel(gentorun_sel)
        ReDim h_sel(gentorun_sel)
        ReDim d_equi(gentorun_sel)
        ReDim h_equi(gentorun_sel)

        d_equi(0) = Val(txt_d.Text)
        h_equi(0) = Val(txt_h.Text)
        If txt_d.Text = "" Then txt_d.Text = 0
        If txt_h.Text = "" Then txt_h.Text = 0

        'Call error_verification_dh(d_sel(0), h_sel(0), result_sel)

        ''error verification step 2
        'If result = 1 Then
        '    txt_d.Text = ""
        '    txt_d.SetFocus()
        '    Exit Sub
        'ElseIf result = 2 Then
        '    txt_h.Text = ""
        '    txt_h.SetFocus()
        '    Exit Sub
        'ElseIf result = 3 Then
        '    txt_d.Text = ""
        '    txt_h.Text = ""
        '    txt_d.SetFocus()
        '    Exit Sub
        'End If
        'If freq_dep = True Then
        '    t = Val(txt_t)
        '    w1 = 1 - t * d_equi(0)
        '    w2 = 1 - t * h_equi(0)
        '    w3 = 1 - t * (1 - d_equi(0) - h_equi(0))
        'End If

        h_sel(0) = h_equi(0) * w2 / (d_equi(0) * w1 + h_equi(0) * w2 + (1 - d_equi(0) - h_equi(0)) * w3)
        d_sel(0) = d_equi(0) * w1 / (d_equi(0) * w1 + h_equi(0) * w2 + (1 - d_equi(0) - h_equi(0)) * w3)

        PlotInitial(maingraph)

    End Sub
    Private Sub SetGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim parabola As New PointPairList
        Dim baseline As New PointPairList
        Dim side1 As New PointPairList
        Dim side2 As New PointPairList
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


        For i = 0 To 1 Step 1 / 1000
            parabola.Add(i, 2 * i * (1 - i))
            'frm_panmixia.pct_triangle.PSet (d_parabola, 1 - h_parabola), RGB(100, 100, 100)
        Next

        Dim parab As LineItem = canvas.AddCurve("", parabola, Color.Gray, SymbolType.None)

        zgc.Refresh()
    End Sub

    Private Sub Selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetGraph(maingraph)
    End Sub

    Private Sub PlotInitial(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim selvalues As New PointPairList
        Dim equivalues As New PointPairList
        Dim line As New PointPairList

        selvalues.Add(d_sel(0) + h_sel(0) / 2, h_sel(0))
        equivalues.Add(d_equi(0) + h_equi(0) / 2, h_equi(0))

        'Line (d_sel(0) + h_sel(0) / 2, 1 - h_sel(0))-(d_equi(0) + h_equi(0) / 2, 1 - h_equi(0)), RGB(200, 200, 200)
        
        'line.Add(d, h)
        'line.Add(d, 2 * d * (1 - d))

        Dim point1 As LineItem = canvas.AddCurve("", selvalues, Color.Red, SymbolType.Square)
        Dim point2 As LineItem = canvas.AddCurve("", equivalues, Color.Blue, SymbolType.Square)
        'Dim connectline As LineItem = canvas.AddCurve("", line, Color.Gray, SymbolType.None)

        zgc.Refresh()


    End Sub

End Class
