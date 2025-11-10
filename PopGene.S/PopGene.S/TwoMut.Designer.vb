<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TwoMut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TwoMut))
        Me.lbl_q = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_p = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.fra_values = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_gen = New System.Windows.Forms.NumericUpDown
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_p = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_rate_v = New System.Windows.Forms.TextBox
        Me.txt_rate_m = New System.Windows.Forms.TextBox
        Me.cmd_save = New System.Windows.Forms.Button
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.fra_values.SuspendLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_q
        '
        Me.lbl_q.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_q.Location = New System.Drawing.Point(42, 56)
        Me.lbl_q.Name = "lbl_q"
        Me.lbl_q.Size = New System.Drawing.Size(101, 17)
        Me.lbl_q.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 24)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "A"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(67, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 24)
        Me.Label1.TabIndex = 27
        '
        'lbl_p
        '
        Me.lbl_p.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_p.Location = New System.Drawing.Point(42, 22)
        Me.lbl_p.Name = "lbl_p"
        Me.lbl_p.Size = New System.Drawing.Size(101, 17)
        Me.lbl_p.TabIndex = 41
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(209, 10)
        Me.maingraph.Margin = New System.Windows.Forms.Padding(0)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(532, 486)
        Me.maingraph.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "p:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 14)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "q:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(130, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 24)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "a"
        '
        'fra_values
        '
        Me.fra_values.Controls.Add(Me.lbl_q)
        Me.fra_values.Controls.Add(Me.lbl_p)
        Me.fra_values.Controls.Add(Me.Label8)
        Me.fra_values.Controls.Add(Me.Label15)
        Me.fra_values.Controls.Add(Me.Label18)
        Me.fra_values.Location = New System.Drawing.Point(12, 328)
        Me.fra_values.Name = "fra_values"
        Me.fra_values.Size = New System.Drawing.Size(180, 80)
        Me.fra_values.TabIndex = 29
        Me.fra_values.TabStop = False
        Me.fra_values.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 60)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 14)
        Me.Label18.TabIndex = 27
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(112, 424)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(80, 72)
        Me.cmd_clear.TabIndex = 28
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(42, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 17)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Mutation rates"
        '
        'txt_gen
        '
        Me.txt_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gen.Location = New System.Drawing.Point(95, 196)
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
        Me.cmd_ok.Location = New System.Drawing.Point(94, 241)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 4
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 42)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Generations to run"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.Location = New System.Drawing.Point(67, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 24)
        Me.Label3.TabIndex = 22
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txt_p)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txt_gen)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_rate_v)
        Me.GroupBox1.Controls.Add(Me.txt_rate_m)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 312)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'txt_p
        '
        Me.txt_p.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_p.Location = New System.Drawing.Point(94, 35)
        Me.txt_p.Name = "txt_p"
        Me.txt_p.Size = New System.Drawing.Size(64, 22)
        Me.txt_p.TabIndex = 0
        Me.txt_p.Text = "1"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 30)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Initial frequency of A allele (p)"
        '
        'txt_rate_v
        '
        Me.txt_rate_v.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rate_v.Location = New System.Drawing.Point(60, 134)
        Me.txt_rate_v.Name = "txt_rate_v"
        Me.txt_rate_v.Size = New System.Drawing.Size(64, 22)
        Me.txt_rate_v.TabIndex = 2
        Me.txt_rate_v.Text = "0.01"
        Me.txt_rate_v.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_rate_m
        '
        Me.txt_rate_m.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rate_m.Location = New System.Drawing.Point(60, 104)
        Me.txt_rate_m.Name = "txt_rate_m"
        Me.txt_rate_m.Size = New System.Drawing.Size(64, 22)
        Me.txt_rate_m.TabIndex = 1
        Me.txt_rate_m.Text = "0.05"
        Me.txt_rate_m.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(12, 423)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(80, 73)
        Me.cmd_save.TabIndex = 30
        Me.cmd_save.Text = "Save values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(668, 499)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'TwoMut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 532)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.fra_values)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TwoMut"
        Me.Text = "Mutation :: Two-Way"
        Me.fra_values.ResumeLayout(False)
        Me.fra_values.PerformLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_q As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_p As System.Windows.Forms.Label
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fra_values As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_gen As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_rate_v As System.Windows.Forms.TextBox
    Friend WithEvents txt_rate_m As System.Windows.Forms.TextBox
    Friend WithEvents txt_p As System.Windows.Forms.TextBox
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents help_bt As System.Windows.Forms.Button
End Class
