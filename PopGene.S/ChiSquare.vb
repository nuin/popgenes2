Public Class ChiSquare
    Inherits System.Windows.Forms.Form
    Dim chi_run As Boolean

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bt_OK As System.Windows.Forms.Button
    Friend WithEvents bt_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents bt_Check As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_obs1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_obs3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_obs2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Exp2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Exp3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Exp1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExpN2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExpN3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExpN1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_chi2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_chi3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_chi1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_totalchi As System.Windows.Forms.TextBox
    Friend WithEvents txt_totalExp As System.Windows.Forms.TextBox
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChiSquare))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.bt_Clear = New System.Windows.Forms.Button
        Me.bt_OK = New System.Windows.Forms.Button
        Me.txt_3 = New System.Windows.Forms.TextBox
        Me.txt_2 = New System.Windows.Forms.TextBox
        Me.txt_1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_totalchi = New System.Windows.Forms.TextBox
        Me.txt_totalExp = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_chi2 = New System.Windows.Forms.TextBox
        Me.txt_chi3 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_chi1 = New System.Windows.Forms.TextBox
        Me.txt_ExpN2 = New System.Windows.Forms.TextBox
        Me.txt_ExpN3 = New System.Windows.Forms.TextBox
        Me.txt_ExpN1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_Exp2 = New System.Windows.Forms.TextBox
        Me.txt_Exp3 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_Exp1 = New System.Windows.Forms.TextBox
        Me.txt_obs2 = New System.Windows.Forms.TextBox
        Me.txt_obs3 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_obs1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmd_save = New System.Windows.Forms.Button
        Me.bt_Check = New System.Windows.Forms.Button
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.bt_Clear)
        Me.GroupBox1.Controls.Add(Me.bt_OK)
        Me.GroupBox1.Controls.Add(Me.txt_3)
        Me.GroupBox1.Controls.Add(Me.txt_2)
        Me.GroupBox1.Controls.Add(Me.txt_1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 144)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(240, 32)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Enter the observed number of individuals for each genotype:"
        '
        'bt_Clear
        '
        Me.bt_Clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_Clear.Image = CType(resources.GetObject("bt_Clear.Image"), System.Drawing.Image)
        Me.bt_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_Clear.Location = New System.Drawing.Point(176, 88)
        Me.bt_Clear.Name = "bt_Clear"
        Me.bt_Clear.Size = New System.Drawing.Size(64, 40)
        Me.bt_Clear.TabIndex = 4
        Me.bt_Clear.Text = "Clear"
        Me.bt_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bt_OK
        '
        Me.bt_OK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_OK.Image = CType(resources.GetObject("bt_OK.Image"), System.Drawing.Image)
        Me.bt_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_OK.Location = New System.Drawing.Point(176, 40)
        Me.bt_OK.Name = "bt_OK"
        Me.bt_OK.Size = New System.Drawing.Size(64, 40)
        Me.bt_OK.TabIndex = 3
        Me.bt_OK.Text = "OK"
        Me.bt_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_3
        '
        Me.txt_3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_3.Location = New System.Drawing.Point(64, 104)
        Me.txt_3.Name = "txt_3"
        Me.txt_3.Size = New System.Drawing.Size(64, 22)
        Me.txt_3.TabIndex = 2
        '
        'txt_2
        '
        Me.txt_2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_2.Location = New System.Drawing.Point(64, 72)
        Me.txt_2.Name = "txt_2"
        Me.txt_2.Size = New System.Drawing.Size(64, 22)
        Me.txt_2.TabIndex = 1
        '
        'txt_1
        '
        Me.txt_1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_1.Location = New System.Drawing.Point(64, 40)
        Me.txt_1.Name = "txt_1"
        Me.txt_1.Size = New System.Drawing.Size(64, 22)
        Me.txt_1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "N(aa)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "N(Aa)"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N(AA)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txt_totalchi)
        Me.GroupBox2.Controls.Add(Me.txt_totalExp)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txt_chi2)
        Me.GroupBox2.Controls.Add(Me.txt_chi3)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txt_chi1)
        Me.GroupBox2.Controls.Add(Me.txt_ExpN2)
        Me.GroupBox2.Controls.Add(Me.txt_ExpN3)
        Me.GroupBox2.Controls.Add(Me.txt_ExpN1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txt_Exp2)
        Me.GroupBox2.Controls.Add(Me.txt_Exp3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txt_Exp1)
        Me.GroupBox2.Controls.Add(Me.txt_obs2)
        Me.GroupBox2.Controls.Add(Me.txt_obs3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_obs1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(280, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 192)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Results"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 144)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 16)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "df=1, ciritcal value 3.84"
        '
        'txt_totalchi
        '
        Me.txt_totalchi.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalchi.Location = New System.Drawing.Point(304, 136)
        Me.txt_totalchi.Name = "txt_totalchi"
        Me.txt_totalchi.Size = New System.Drawing.Size(64, 22)
        Me.txt_totalchi.TabIndex = 24
        '
        'txt_totalExp
        '
        Me.txt_totalExp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalExp.Location = New System.Drawing.Point(232, 136)
        Me.txt_totalExp.Name = "txt_totalExp"
        Me.txt_totalExp.Size = New System.Drawing.Size(64, 22)
        Me.txt_totalExp.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(192, 136)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Total"
        '
        'txt_chi2
        '
        Me.txt_chi2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_chi2.Location = New System.Drawing.Point(304, 72)
        Me.txt_chi2.Name = "txt_chi2"
        Me.txt_chi2.Size = New System.Drawing.Size(64, 22)
        Me.txt_chi2.TabIndex = 21
        '
        'txt_chi3
        '
        Me.txt_chi3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_chi3.Location = New System.Drawing.Point(304, 104)
        Me.txt_chi3.Name = "txt_chi3"
        Me.txt_chi3.Size = New System.Drawing.Size(64, 22)
        Me.txt_chi3.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(296, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Chi-square"
        '
        'txt_chi1
        '
        Me.txt_chi1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_chi1.Location = New System.Drawing.Point(304, 40)
        Me.txt_chi1.Name = "txt_chi1"
        Me.txt_chi1.Size = New System.Drawing.Size(64, 22)
        Me.txt_chi1.TabIndex = 18
        '
        'txt_ExpN2
        '
        Me.txt_ExpN2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExpN2.Location = New System.Drawing.Point(232, 72)
        Me.txt_ExpN2.Name = "txt_ExpN2"
        Me.txt_ExpN2.Size = New System.Drawing.Size(64, 22)
        Me.txt_ExpN2.TabIndex = 17
        '
        'txt_ExpN3
        '
        Me.txt_ExpN3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExpN3.Location = New System.Drawing.Point(232, 104)
        Me.txt_ExpN3.Name = "txt_ExpN3"
        Me.txt_ExpN3.Size = New System.Drawing.Size(64, 22)
        Me.txt_ExpN3.TabIndex = 16
        '
        'txt_ExpN1
        '
        Me.txt_ExpN1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExpN1.Location = New System.Drawing.Point(232, 40)
        Me.txt_ExpN1.Name = "txt_ExpN1"
        Me.txt_ExpN1.Size = New System.Drawing.Size(64, 22)
        Me.txt_ExpN1.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(192, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "N(aa)"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(192, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "N(Aa)"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(192, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "N(AA)"
        '
        'txt_Exp2
        '
        Me.txt_Exp2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Exp2.Location = New System.Drawing.Point(128, 72)
        Me.txt_Exp2.Name = "txt_Exp2"
        Me.txt_Exp2.Size = New System.Drawing.Size(56, 22)
        Me.txt_Exp2.TabIndex = 11
        '
        'txt_Exp3
        '
        Me.txt_Exp3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Exp3.Location = New System.Drawing.Point(128, 104)
        Me.txt_Exp3.Name = "txt_Exp3"
        Me.txt_Exp3.Size = New System.Drawing.Size(56, 22)
        Me.txt_Exp3.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(128, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Expected"
        '
        'txt_Exp1
        '
        Me.txt_Exp1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Exp1.Location = New System.Drawing.Point(128, 40)
        Me.txt_Exp1.Name = "txt_Exp1"
        Me.txt_Exp1.Size = New System.Drawing.Size(56, 22)
        Me.txt_Exp1.TabIndex = 8
        '
        'txt_obs2
        '
        Me.txt_obs2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_obs2.Location = New System.Drawing.Point(56, 72)
        Me.txt_obs2.Name = "txt_obs2"
        Me.txt_obs2.Size = New System.Drawing.Size(56, 22)
        Me.txt_obs2.TabIndex = 7
        '
        'txt_obs3
        '
        Me.txt_obs3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_obs3.Location = New System.Drawing.Point(56, 104)
        Me.txt_obs3.Name = "txt_obs3"
        Me.txt_obs3.Size = New System.Drawing.Size(56, 22)
        Me.txt_obs3.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Observed"
        '
        'txt_obs1
        '
        Me.txt_obs1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_obs1.Location = New System.Drawing.Point(56, 40)
        Me.txt_obs1.Name = "txt_obs1"
        Me.txt_obs1.Size = New System.Drawing.Size(56, 22)
        Me.txt_obs1.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "P(Aa)"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "P(aa)"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "P(AA)"
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_save.Location = New System.Drawing.Point(16, 168)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(120, 48)
        Me.cmd_save.TabIndex = 7
        Me.cmd_save.Text = "Save Values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bt_Check
        '
        Me.bt_Check.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_Check.Location = New System.Drawing.Point(200, 168)
        Me.bt_Check.Name = "bt_Check"
        Me.bt_Check.Size = New System.Drawing.Size(72, 40)
        Me.bt_Check.TabIndex = 8
        Me.bt_Check.Text = "Check equations"
        Me.bt_Check.Visible = False
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(589, 214)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 9
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'ChiSquare
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(696, 254)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.bt_Check)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChiSquare"
        Me.Text = "ChiSquare"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub bt_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_OK.Click
        Dim g1, g2, g3, total As Integer
        Dim p As Double

        chi_run = True

        If txt_1.Text <> "" Then
            g1 = Val(txt_1.Text)
        End If

        If txt_2.Text <> "" Then
            g2 = Val(txt_2.Text)
        End If

        If txt_3.Text <> "" Then
            g3 = Val(txt_3.Text)
        End If

        total = g1 + g2 + g3
        p = (g1 + (g2 / 2)) / total
        'txt_totalObs.Text = total
        txt_totalExp.Text = total
        txt_obs1.Text = Format(g1 / total, "0.0000")
        txt_obs2.Text = Format(g2 / total, "0.0000")
        txt_obs3.Text = Format(g3 / total, "0.0000")

        txt_Exp1.Text = Format(p * p, "0.0000")
        txt_Exp2.Text = Format(2 * p * (1 - p), "0.0000")
        txt_Exp3.Text = Format((1 - p) ^ 2, "0.0000")

        p = (g1 / total) + (g2 / (2 * total))

        txt_ExpN1.Text = Format(p * p * total, "#.0000")
        txt_ExpN2.Text = Format(2 * p * (1 - p) * total, "#.0000")
        txt_ExpN3.Text = Format((1 - p) * (1 - p) * total, "#.0000")

        txt_chi1.Text = Format((Val(txt_1.Text) - Val(txt_ExpN1.Text)) ^ 2 / Val(txt_ExpN1.Text), "#0.####")
        txt_chi2.Text = Format((Val(txt_2.Text) - Val(txt_ExpN2.Text)) ^ 2 / Val(txt_ExpN2.Text), "#0.####")
        txt_chi3.Text = Format((Val(txt_3.Text) - Val(txt_ExpN3.Text)) ^ 2 / Val(txt_ExpN3.Text), "#0.####")

        txt_totalchi.Text = Val(txt_chi1.Text) + Val(txt_chi2.Text) + Val(txt_chi3.Text)

        cmd_save.Enabled = True

    End Sub

    Private Sub bt_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Clear.Click
        txt_1.Text = ""
        txt_2.Text = ""
        txt_3.Text = ""

        txt_obs1.Text = ""
        txt_obs2.Text = ""
        txt_obs3.Text = ""

        txt_Exp1.Text = ""
        txt_Exp2.Text = ""
        txt_Exp3.Text = ""

        txt_chi1.Text = ""
        txt_chi2.Text = ""
        txt_chi3.Text = ""

        txt_ExpN1.Text = ""
        txt_ExpN2.Text = ""
        txt_ExpN3.Text = ""

        txt_totalExp.Text = ""
        txt_totalchi.Text = ""
    End Sub

    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click

        With dlg_save
            .DefaultExt = ".txt"
            .OverwritePrompt = True
            .Filter = "All files|*.*|Text files (*.txt)|*.txt"
            .FilterIndex = 2
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objWriter As New System.IO.StreamWriter(.FileName)
                objWriter.WriteLine("Chi-square test - 2 alleles")
                objWriter.WriteLine("Observed values (absolute frequencies): ")
                objWriter.WriteLine("N(AA) = " & Val(txt_1.Text))
                objWriter.WriteLine("N(Aa) = " & Val(txt_2.Text))
                objWriter.WriteLine("N(aa) = " & Val(txt_3.Text))
                objWriter.WriteLine()

                objWriter.WriteLine("Observed values (relative frequencies): ")
                objWriter.WriteLine("P(AA) = " & Format(Val(txt_obs1.Text), "0.0000"))
                objWriter.WriteLine("P(Aa) = " & Format(Val(txt_obs2.Text), "0.0000"))
                objWriter.WriteLine("P(aa) = " & Format(Val(txt_obs3.Text), "0.0000"))
                objWriter.WriteLine()

                objWriter.WriteLine("Expected values (absolute frequencies): ")
                objWriter.WriteLine("N(AA) = " & Val(txt_ExpN1.Text))
                objWriter.WriteLine("N(Aa) = " & Val(txt_ExpN2.Text))
                objWriter.WriteLine("N(aa) = " & Val(txt_ExpN3.Text))
                objWriter.WriteLine()

                objWriter.WriteLine("Observed values (relative frequencies): ")
                objWriter.WriteLine("P(AA) = " & Format(Val(txt_Exp1.Text), "0.0000"))
                objWriter.WriteLine("P(Aa) = " & Format(Val(txt_Exp2.Text), "0.0000"))
                objWriter.WriteLine("P(aa) = " & Format(Val(txt_Exp3.Text), "0.0000"))
                objWriter.WriteLine()

                objWriter.WriteLine("Chi-square partial values : ")
                objWriter.WriteLine("AA = " & Format(Val(txt_chi1.Text), "0.000000"))
                objWriter.WriteLine("Aa = " & Format(Val(txt_chi2.Text), "0.000000"))
                objWriter.WriteLine("aa = " & Format(Val(txt_chi3.Text), "0.000000"))
                objWriter.WriteLine("Chi-square total = ", Val(txt_totalchi))
                objWriter.WriteLine("d.f. = 1, Critical value 3.84")

                objWriter.WriteLine()
                objWriter.WriteLine()
                objWriter.Close()
            End If
        End With

    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/chisquare.html")
    End Sub
End Class
