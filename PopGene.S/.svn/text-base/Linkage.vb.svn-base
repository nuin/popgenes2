Public Class Linkage
    Inherits System.Windows.Forms.Form
    Dim total As Double
    Dim g1, g2, g3, g4 As Double
    Dim p1, p2, p3, p4 As Double
    Dim d, chi As Double
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Dim link_run As Boolean

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_link1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_link2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_link3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_link4 As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents txt_linkR4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkR3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkR2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkR1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkA4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkA3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkA2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_linkA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiff4 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiff3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiff2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiff1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_D As System.Windows.Forms.TextBox
    Friend WithEvents txt_chi As System.Windows.Forms.TextBox
    Friend WithEvents cmd_histo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Linkage))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_link4 = New System.Windows.Forms.TextBox
        Me.txt_link3 = New System.Windows.Forms.TextBox
        Me.txt_link2 = New System.Windows.Forms.TextBox
        Me.txt_link1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmd_save = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_chi = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_D = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtDiff4 = New System.Windows.Forms.TextBox
        Me.txtDiff3 = New System.Windows.Forms.TextBox
        Me.txtDiff2 = New System.Windows.Forms.TextBox
        Me.txtDiff1 = New System.Windows.Forms.TextBox
        Me.txt_linkA4 = New System.Windows.Forms.TextBox
        Me.txt_linkA3 = New System.Windows.Forms.TextBox
        Me.txt_linkA2 = New System.Windows.Forms.TextBox
        Me.txt_linkA1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmd_histo = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_linkR4 = New System.Windows.Forms.TextBox
        Me.txt_linkR3 = New System.Windows.Forms.TextBox
        Me.txt_linkR2 = New System.Windows.Forms.TextBox
        Me.txt_linkR1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_link4)
        Me.GroupBox1.Controls.Add(Me.txt_link3)
        Me.GroupBox1.Controls.Add(Me.txt_link2)
        Me.GroupBox1.Controls.Add(Me.txt_link1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 272)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Observed frequencies"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(88, 200)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "N(ab)"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "N(aB)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "N(Ab)"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "N(AB)"
        '
        'txt_link4
        '
        Me.txt_link4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_link4.Location = New System.Drawing.Point(88, 168)
        Me.txt_link4.Name = "txt_link4"
        Me.txt_link4.Size = New System.Drawing.Size(64, 22)
        Me.txt_link4.TabIndex = 3
        '
        'txt_link3
        '
        Me.txt_link3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_link3.Location = New System.Drawing.Point(88, 136)
        Me.txt_link3.Name = "txt_link3"
        Me.txt_link3.Size = New System.Drawing.Size(64, 22)
        Me.txt_link3.TabIndex = 2
        '
        'txt_link2
        '
        Me.txt_link2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_link2.Location = New System.Drawing.Point(88, 102)
        Me.txt_link2.Name = "txt_link2"
        Me.txt_link2.Size = New System.Drawing.Size(64, 22)
        Me.txt_link2.TabIndex = 1
        '
        'txt_link1
        '
        Me.txt_link1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_link1.Location = New System.Drawing.Point(88, 72)
        Me.txt_link1.Name = "txt_link1"
        Me.txt_link1.Size = New System.Drawing.Size(64, 22)
        Me.txt_link1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 40)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Enter the numbers of each gamete (integer)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmd_save)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_chi)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_D)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtDiff4)
        Me.GroupBox2.Controls.Add(Me.txtDiff3)
        Me.GroupBox2.Controls.Add(Me.txtDiff2)
        Me.GroupBox2.Controls.Add(Me.txtDiff1)
        Me.GroupBox2.Controls.Add(Me.txt_linkA4)
        Me.GroupBox2.Controls.Add(Me.txt_linkA3)
        Me.GroupBox2.Controls.Add(Me.txt_linkA2)
        Me.GroupBox2.Controls.Add(Me.txt_linkA1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmd_histo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txt_linkR4)
        Me.GroupBox2.Controls.Add(Me.txt_linkR3)
        Me.GroupBox2.Controls.Add(Me.txt_linkR2)
        Me.GroupBox2.Controls.Add(Me.txt_linkR1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(209, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(544, 272)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Observed frequencies"
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(112, 200)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(72, 56)
        Me.cmd_save.TabIndex = 6
        Me.cmd_save.Text = "Save file"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(448, 200)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 16)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "df = 1"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(408, 224)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 16)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Critical value = 3.84"
        '
        'txt_chi
        '
        Me.txt_chi.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_chi.Location = New System.Drawing.Point(440, 168)
        Me.txt_chi.Name = "txt_chi"
        Me.txt_chi.Size = New System.Drawing.Size(64, 22)
        Me.txt_chi.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(424, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 16)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Chi-square value"
        '
        'txt_D
        '
        Me.txt_D.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_D.Location = New System.Drawing.Point(440, 72)
        Me.txt_D.Name = "txt_D"
        Me.txt_D.Size = New System.Drawing.Size(64, 22)
        Me.txt_D.TabIndex = 36
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(432, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 32)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Disequilibrium coefficient"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(288, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 16)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Observed - Expected"
        '
        'txtDiff4
        '
        Me.txtDiff4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiff4.Location = New System.Drawing.Point(312, 168)
        Me.txtDiff4.Name = "txtDiff4"
        Me.txtDiff4.Size = New System.Drawing.Size(64, 22)
        Me.txtDiff4.TabIndex = 33
        '
        'txtDiff3
        '
        Me.txtDiff3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiff3.Location = New System.Drawing.Point(312, 136)
        Me.txtDiff3.Name = "txtDiff3"
        Me.txtDiff3.Size = New System.Drawing.Size(64, 22)
        Me.txtDiff3.TabIndex = 32
        '
        'txtDiff2
        '
        Me.txtDiff2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiff2.Location = New System.Drawing.Point(312, 104)
        Me.txtDiff2.Name = "txtDiff2"
        Me.txtDiff2.Size = New System.Drawing.Size(64, 22)
        Me.txtDiff2.TabIndex = 31
        '
        'txtDiff1
        '
        Me.txtDiff1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiff1.Location = New System.Drawing.Point(312, 72)
        Me.txtDiff1.Name = "txtDiff1"
        Me.txtDiff1.Size = New System.Drawing.Size(64, 22)
        Me.txtDiff1.TabIndex = 30
        '
        'txt_linkA4
        '
        Me.txt_linkA4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkA4.Location = New System.Drawing.Point(192, 168)
        Me.txt_linkA4.Name = "txt_linkA4"
        Me.txt_linkA4.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkA4.TabIndex = 29
        '
        'txt_linkA3
        '
        Me.txt_linkA3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkA3.Location = New System.Drawing.Point(192, 136)
        Me.txt_linkA3.Name = "txt_linkA3"
        Me.txt_linkA3.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkA3.TabIndex = 28
        '
        'txt_linkA2
        '
        Me.txt_linkA2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkA2.Location = New System.Drawing.Point(192, 104)
        Me.txt_linkA2.Name = "txt_linkA2"
        Me.txt_linkA2.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkA2.TabIndex = 27
        '
        'txt_linkA1
        '
        Me.txt_linkA1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkA1.Location = New System.Drawing.Point(192, 72)
        Me.txt_linkA1.Name = "txt_linkA1"
        Me.txt_linkA1.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkA1.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(160, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 32)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Expected numbers of gametes (N*EP)"
        '
        'cmd_histo
        '
        Me.cmd_histo.Enabled = False
        Me.cmd_histo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_histo.Image = CType(resources.GetObject("cmd_histo.Image"), System.Drawing.Image)
        Me.cmd_histo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_histo.Location = New System.Drawing.Point(24, 200)
        Me.cmd_histo.Name = "cmd_histo"
        Me.cmd_histo.Size = New System.Drawing.Size(72, 56)
        Me.cmd_histo.TabIndex = 5
        Me.cmd_histo.Text = "Histogram"
        Me.cmd_histo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "EP(ab)"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "EP(aB)"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "EP(Ab)"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "EP(AB)"
        '
        'txt_linkR4
        '
        Me.txt_linkR4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkR4.Location = New System.Drawing.Point(72, 168)
        Me.txt_linkR4.Name = "txt_linkR4"
        Me.txt_linkR4.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkR4.TabIndex = 18
        '
        'txt_linkR3
        '
        Me.txt_linkR3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkR3.Location = New System.Drawing.Point(72, 136)
        Me.txt_linkR3.Name = "txt_linkR3"
        Me.txt_linkR3.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkR3.TabIndex = 16
        '
        'txt_linkR2
        '
        Me.txt_linkR2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkR2.Location = New System.Drawing.Point(72, 104)
        Me.txt_linkR2.Name = "txt_linkR2"
        Me.txt_linkR2.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkR2.TabIndex = 15
        '
        'txt_linkR1
        '
        Me.txt_linkR1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_linkR1.Location = New System.Drawing.Point(72, 72)
        Me.txt_linkR1.Name = "txt_linkR1"
        Me.txt_linkR1.Size = New System.Drawing.Size(64, 22)
        Me.txt_linkR1.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Expected frequencies"
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(678, 290)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Linkage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(765, 317)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Linkage"
        Me.Text = "Linkage :: 2 Loci, 4 Alleles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        If txt_link1.Text <> "" Then
            g1 = Val(txt_link1.Text)
        End If
        If txt_link2.Text <> "" Then
            g2 = Val(txt_link2.Text)
        End If
        If txt_link3.Text <> "" Then
            g3 = Val(txt_link3.Text)
        End If
        If txt_link4.Text <> "" Then
            g4 = Val(txt_link4.Text)
        End If

        total = g1 + g2 + g3 + g4

        If total > 1 Then
            g1 = g1 / total
            g2 = g2 / total
            g3 = g3 / total
            g4 = g4 / total
        End If

        p1 = g1 + g2
        p2 = g3 + g4
        p3 = g1 + g3
        p4 = g2 + g4

        d = (g1 * g4) - (g2 * g3)

        txt_D.Text = Format(d, "#0.00000")

        txt_linkR1.Text = Format(p1 * p3, "#0.00000")
        txt_linkR2.Text = Format(p1 * p4, "#0.00000")
        txt_linkR3.Text = Format(p2 * p3, "#0.00000")
        txt_linkR4.Text = Format(p2 * p4, "#0.00000")
        txt_linkA1.Text = Format(p1 * p3 * total, "#0.000")
        txt_linkA2.Text = Format(p1 * p4 * total, "#0.00000")
        txt_linkA3.Text = Format(p2 * p3 * total, "#0.00000")
        txt_linkA4.Text = Format(p2 * p4 * total, "#0.00000")

        txtDiff1.Text = Format(Val(txt_link1.Text) - Val(txt_linkA1.Text), "#0.00000")
        txtDiff2.Text = Format(Val(txt_link2.Text) - Val(txt_linkA2.Text), "#0.00000")
        txtDiff3.Text = Format(Val(txt_link3.Text) - Val(txt_linkA3.Text), "#0.00000")
        txtDiff4.Text = Format(Val(txt_link4.Text) - Val(txt_linkA4.Text), "#0.00000")

        chi = (total * d ^ 2) / (p1 * p2 * p3 * p4)

        txt_chi.Text = Format(chi, "#0.00000")

        cmd_histo.Enabled = True
        link_run = True

        h1 = Val(txt_link1.Text)
        h2 = Val(txt_linkA1.Text)
        h3 = Val(txt_link2.Text)
        h4 = Val(txt_linkA2.Text)
        h5 = Val(txt_link3.Text)
        h6 = Val(txt_linkA3.Text)
        h7 = Val(txt_link4.Text)
        h8 = Val(txt_linkA4.Text)
        cmd_save.Enabled = True
    End Sub

    Private Sub cmd_histo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_histo.Click
        Dim frm As New LinkHisto
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click

        With dlg_save
            .DefaultExt = ".txt"
            .OverwritePrompt = True
            .Filter = "All files|*.*|Text files (*.txt)|*.txt"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objWriter As New System.IO.StreamWriter(.FileName)
                objWriter.WriteLine("Linkage Disequilibrium - 2 loci, 4 alleles")
                objWriter.WriteLine("Observed values (absolute frequencies): ")
                objWriter.WriteLine("N(AB) = " & Val(txt_link1.Text))
                objWriter.WriteLine("N(Ab) = " & Val(txt_link2.Text))
                objWriter.WriteLine("N(aB) = " & Val(txt_link3.Text))
                objWriter.WriteLine("N(ab) = " & Val(txt_link4.Text))
                objWriter.WriteLine()


                objWriter.WriteLine("Expected values (absolute frequencies): ")
                objWriter.WriteLine("N(AB) = " & Val(txt_linkA1.Text))
                objWriter.WriteLine("N(Ab) = " & Val(txt_linkA2.Text))
                objWriter.WriteLine("N(aB) = " & Val(txt_linkA3.Text))
                objWriter.WriteLine("N(ab) = " & Val(txt_linkA4.Text))
                objWriter.WriteLine()

                objWriter.WriteLine("Expected values (absolute frequencies): ")
                objWriter.WriteLine("EP(AB) = " & Val(txt_linkR1.Text))
                objWriter.WriteLine("EP(Ab) = " & Val(txt_linkR2.Text))
                objWriter.WriteLine("EP(aB) = " & Val(txt_linkR3.Text))
                objWriter.WriteLine("EP(ab) = " & Val(txt_linkR4.Text))
                objWriter.WriteLine()

                objWriter.WriteLine("Chi-square : " & Val(txt_chi))
                objWriter.WriteLine("d.f. = 1, Critical value 3.84")
                objWriter.WriteLine()

                objWriter.WriteLine("Linkage Disequilibrium (D) : " & Val(txt_D))

                objWriter.WriteLine()
                objWriter.WriteLine()

                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/disequilibrium.html")
    End Sub
End Class
