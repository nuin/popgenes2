<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FStats
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FStats))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_nplot = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_f = New System.Windows.Forms.TextBox
        Me.txt_m = New System.Windows.Forms.TextBox
        Me.txt_n = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_gen = New System.Windows.Forms.NumericUpDown
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_freq = New System.Windows.Forms.TextBox
        Me.txt_pops = New System.Windows.Forms.TextBox
        Me.txt_nloci = New System.Windows.Forms.TextBox
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.auxgraph = New ZedGraph.ZedGraphControl
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.cmd_save = New System.Windows.Forms.Button
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_nplot)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_f)
        Me.GroupBox1.Controls.Add(Me.txt_m)
        Me.GroupBox1.Controls.Add(Me.txt_n)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_gen)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_freq)
        Me.GroupBox1.Controls.Add(Me.txt_pops)
        Me.GroupBox1.Controls.Add(Me.txt_nloci)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 150)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txt_nplot
        '
        Me.txt_nplot.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nplot.Location = New System.Drawing.Point(278, 97)
        Me.txt_nplot.Name = "txt_nplot"
        Me.txt_nplot.Size = New System.Drawing.Size(64, 22)
        Me.txt_nplot.TabIndex = 33
        Me.txt_nplot.Text = "20"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(191, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 50)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Number of subpops to plot"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(362, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 18)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "m"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(361, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "f"
        '
        'txt_f
        '
        Me.txt_f.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_f.Location = New System.Drawing.Point(392, 58)
        Me.txt_f.Name = "txt_f"
        Me.txt_f.Size = New System.Drawing.Size(64, 22)
        Me.txt_f.TabIndex = 28
        Me.txt_f.Text = "-0.1"
        '
        'txt_m
        '
        Me.txt_m.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_m.Location = New System.Drawing.Point(392, 20)
        Me.txt_m.Name = "txt_m"
        Me.txt_m.Size = New System.Drawing.Size(64, 22)
        Me.txt_m.TabIndex = 27
        Me.txt_m.Text = "0.1"
        '
        'txt_n
        '
        Me.txt_n.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_n.Location = New System.Drawing.Point(278, 58)
        Me.txt_n.Name = "txt_n"
        Me.txt_n.Size = New System.Drawing.Size(64, 22)
        Me.txt_n.TabIndex = 26
        Me.txt_n.Text = "10"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(191, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 34)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Ne of each subpopulation"
        '
        'txt_gen
        '
        Me.txt_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gen.Location = New System.Drawing.Point(278, 20)
        Me.txt_gen.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txt_gen.Name = "txt_gen"
        Me.txt_gen.Size = New System.Drawing.Size(64, 22)
        Me.txt_gen.TabIndex = 24
        Me.txt_gen.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(478, 20)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 60)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(191, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 36)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Generations to run"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 39)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Initial frequency"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 36)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Number of subpopulations"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 39)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Number of nuclear loci"
        '
        'txt_freq
        '
        Me.txt_freq.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freq.Location = New System.Drawing.Point(108, 97)
        Me.txt_freq.Name = "txt_freq"
        Me.txt_freq.Size = New System.Drawing.Size(64, 22)
        Me.txt_freq.TabIndex = 2
        Me.txt_freq.Text = "0.5"
        '
        'txt_pops
        '
        Me.txt_pops.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pops.Location = New System.Drawing.Point(108, 58)
        Me.txt_pops.Name = "txt_pops"
        Me.txt_pops.Size = New System.Drawing.Size(64, 22)
        Me.txt_pops.TabIndex = 1
        Me.txt_pops.Text = "200"
        '
        'txt_nloci
        '
        Me.txt_nloci.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nloci.Location = New System.Drawing.Point(108, 19)
        Me.txt_nloci.Name = "txt_nloci"
        Me.txt_nloci.Size = New System.Drawing.Size(64, 22)
        Me.txt_nloci.TabIndex = 0
        Me.txt_nloci.Text = "1"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(12, 179)
        Me.maingraph.Margin = New System.Windows.Forms.Padding(0)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(386, 470)
        Me.maingraph.TabIndex = 8
        '
        'auxgraph
        '
        Me.auxgraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.auxgraph.Location = New System.Drawing.Point(404, 179)
        Me.auxgraph.Margin = New System.Windows.Forms.Padding(0)
        Me.auxgraph.Name = "auxgraph"
        Me.auxgraph.ScrollGrace = 0
        Me.auxgraph.ScrollMaxX = 0
        Me.auxgraph.ScrollMaxY = 0
        Me.auxgraph.ScrollMaxY2 = 0
        Me.auxgraph.ScrollMinX = 0
        Me.auxgraph.ScrollMinY = 0
        Me.auxgraph.ScrollMinY2 = 0
        Me.auxgraph.Size = New System.Drawing.Size(386, 470)
        Me.auxgraph.TabIndex = 9
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(583, 90)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(80, 72)
        Me.cmd_clear.TabIndex = 29
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(669, 90)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(80, 72)
        Me.cmd_save.TabIndex = 38
        Me.cmd_save.Text = "Save Values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_save.Visible = False
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(669, 27)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'FStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 663)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.auxgraph)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FStats"
        Me.Text = "F Statistics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_gen As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_freq As System.Windows.Forms.TextBox
    Friend WithEvents txt_pops As System.Windows.Forms.TextBox
    Friend WithEvents txt_nloci As System.Windows.Forms.TextBox
    Friend WithEvents txt_n As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_f As System.Windows.Forms.TextBox
    Friend WithEvents txt_m As System.Windows.Forms.TextBox
    Friend WithEvents auxgraph As ZedGraph.ZedGraphControl
    Friend WithEvents txt_nplot As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents help_bt As System.Windows.Forms.Button
End Class
