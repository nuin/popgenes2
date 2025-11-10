<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Muller
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Muller))
        Me.graph1 = New ZedGraph.ZedGraphControl
        Me.graph2 = New ZedGraph.ZedGraphControl
        Me.graph3 = New ZedGraph.ZedGraphControl
        Me.graph4 = New ZedGraph.ZedGraphControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_generation = New System.Windows.Forms.NumericUpDown
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_m = New System.Windows.Forms.TextBox
        Me.txt_s = New System.Windows.Forms.TextBox
        Me.txt_loci = New System.Windows.Forms.TextBox
        Me.txt_haploid = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_generation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'graph1
        '
        Me.graph1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.graph1.Location = New System.Drawing.Point(240, 17)
        Me.graph1.Name = "graph1"
        Me.graph1.ScrollGrace = 0
        Me.graph1.ScrollMaxX = 0
        Me.graph1.ScrollMaxY = 0
        Me.graph1.ScrollMaxY2 = 0
        Me.graph1.ScrollMinX = 0
        Me.graph1.ScrollMinY = 0
        Me.graph1.ScrollMinY2 = 0
        Me.graph1.Size = New System.Drawing.Size(335, 320)
        Me.graph1.TabIndex = 1
        '
        'graph2
        '
        Me.graph2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.graph2.Location = New System.Drawing.Point(594, 17)
        Me.graph2.Name = "graph2"
        Me.graph2.ScrollGrace = 0
        Me.graph2.ScrollMaxX = 0
        Me.graph2.ScrollMaxY = 0
        Me.graph2.ScrollMaxY2 = 0
        Me.graph2.ScrollMinX = 0
        Me.graph2.ScrollMinY = 0
        Me.graph2.ScrollMinY2 = 0
        Me.graph2.Size = New System.Drawing.Size(335, 320)
        Me.graph2.TabIndex = 2
        '
        'graph3
        '
        Me.graph3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.graph3.Location = New System.Drawing.Point(240, 352)
        Me.graph3.Name = "graph3"
        Me.graph3.ScrollGrace = 0
        Me.graph3.ScrollMaxX = 0
        Me.graph3.ScrollMaxY = 0
        Me.graph3.ScrollMaxY2 = 0
        Me.graph3.ScrollMinX = 0
        Me.graph3.ScrollMinY = 0
        Me.graph3.ScrollMinY2 = 0
        Me.graph3.Size = New System.Drawing.Size(335, 320)
        Me.graph3.TabIndex = 3
        '
        'graph4
        '
        Me.graph4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.graph4.Location = New System.Drawing.Point(594, 352)
        Me.graph4.Name = "graph4"
        Me.graph4.ScrollGrace = 0
        Me.graph4.ScrollMaxX = 0
        Me.graph4.ScrollMaxY = 0
        Me.graph4.ScrollMaxY2 = 0
        Me.graph4.ScrollMinX = 0
        Me.graph4.ScrollMinY = 0
        Me.graph4.ScrollMinY2 = 0
        Me.graph4.Size = New System.Drawing.Size(335, 320)
        Me.graph4.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_generation)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_m)
        Me.GroupBox1.Controls.Add(Me.txt_s)
        Me.GroupBox1.Controls.Add(Me.txt_loci)
        Me.GroupBox1.Controls.Add(Me.txt_haploid)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(222, 276)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 17)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Generations to run"
        '
        'txt_generation
        '
        Me.txt_generation.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_generation.Location = New System.Drawing.Point(138, 167)
        Me.txt_generation.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txt_generation.Name = "txt_generation"
        Me.txt_generation.Size = New System.Drawing.Size(64, 22)
        Me.txt_generation.TabIndex = 25
        Me.txt_generation.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(138, 205)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 60)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 17)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Mutation chance"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 34)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Number of loci per individual"
        '
        'txt_m
        '
        Me.txt_m.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_m.Location = New System.Drawing.Point(138, 130)
        Me.txt_m.Name = "txt_m"
        Me.txt_m.Size = New System.Drawing.Size(64, 22)
        Me.txt_m.TabIndex = 3
        Me.txt_m.Text = "0.06"
        '
        'txt_s
        '
        Me.txt_s.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_s.Location = New System.Drawing.Point(138, 94)
        Me.txt_s.Name = "txt_s"
        Me.txt_s.Size = New System.Drawing.Size(64, 22)
        Me.txt_s.TabIndex = 2
        Me.txt_s.Text = "0.01"
        '
        'txt_loci
        '
        Me.txt_loci.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_loci.Location = New System.Drawing.Point(138, 57)
        Me.txt_loci.Name = "txt_loci"
        Me.txt_loci.Size = New System.Drawing.Size(64, 22)
        Me.txt_loci.TabIndex = 1
        Me.txt_loci.Text = "10"
        '
        'txt_haploid
        '
        Me.txt_haploid.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_haploid.Location = New System.Drawing.Point(138, 22)
        Me.txt_haploid.Name = "txt_haploid"
        Me.txt_haploid.Size = New System.Drawing.Size(64, 22)
        Me.txt_haploid.TabIndex = 0
        Me.txt_haploid.Text = "20"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 32)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Population size of haploid chromosomes"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 24)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Selection coefficient"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 304)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 56)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Save file"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.Visible = False
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(150, 337)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(64, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Muller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 694)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.graph4)
        Me.Controls.Add(Me.graph3)
        Me.Controls.Add(Me.graph2)
        Me.Controls.Add(Me.graph1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Muller"
        Me.Text = "Muller"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_generation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents graph1 As ZedGraph.ZedGraphControl
    Friend WithEvents graph2 As ZedGraph.ZedGraphControl
    Friend WithEvents graph3 As ZedGraph.ZedGraphControl
    Friend WithEvents graph4 As ZedGraph.ZedGraphControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_m As System.Windows.Forms.TextBox
    Friend WithEvents txt_s As System.Windows.Forms.TextBox
    Friend WithEvents txt_loci As System.Windows.Forms.TextBox
    Friend WithEvents txt_haploid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_generation As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents help_bt As System.Windows.Forms.Button
End Class
