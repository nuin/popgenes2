<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Htime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Htime))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.l8 = New System.Windows.Forms.Label
        Me.txt_gen = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_drift = New System.Windows.Forms.TextBox
        Me.txt_p = New System.Windows.Forms.TextBox
        Me.txt_size = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chk_drift = New System.Windows.Forms.CheckBox
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.cmd_save = New System.Windows.Forms.Button
        Me.dlg_save = New System.Windows.Forms.SaveFileDialog
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.l8)
        Me.GroupBox1.Controls.Add(Me.txt_gen)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_drift)
        Me.GroupBox1.Controls.Add(Me.txt_p)
        Me.GroupBox1.Controls.Add(Me.txt_size)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chk_drift)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 353)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'l8
        '
        Me.l8.AutoSize = True
        Me.l8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l8.Location = New System.Drawing.Point(14, 218)
        Me.l8.Name = "l8"
        Me.l8.Size = New System.Drawing.Size(133, 14)
        Me.l8.TabIndex = 50
        Me.l8.Text = "Number of populations"
        '
        'txt_gen
        '
        Me.txt_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gen.Location = New System.Drawing.Point(59, 130)
        Me.txt_gen.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txt_gen.Name = "txt_gen"
        Me.txt_gen.Size = New System.Drawing.Size(61, 22)
        Me.txt_gen.TabIndex = 2
        Me.txt_gen.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 21)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Number of generations"
        '
        'txt_drift
        '
        Me.txt_drift.BackColor = System.Drawing.Color.White
        Me.txt_drift.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_drift.Location = New System.Drawing.Point(59, 238)
        Me.txt_drift.Name = "txt_drift"
        Me.txt_drift.Size = New System.Drawing.Size(61, 22)
        Me.txt_drift.TabIndex = 3
        Me.txt_drift.Text = "6"
        '
        'txt_p
        '
        Me.txt_p.AcceptsReturn = True
        Me.txt_p.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_p.Location = New System.Drawing.Point(56, 81)
        Me.txt_p.Name = "txt_p"
        Me.txt_p.Size = New System.Drawing.Size(64, 22)
        Me.txt_p.TabIndex = 1
        Me.txt_p.Text = "0.5"
        '
        'txt_size
        '
        Me.txt_size.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.Location = New System.Drawing.Point(56, 34)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(64, 22)
        Me.txt_size.TabIndex = 0
        Me.txt_size.Text = "100"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(83, 291)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(72, 56)
        Me.cmd_ok.TabIndex = 7
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 32)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Effective population size"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 31)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Initial allele frequency P(A)"
        '
        'chk_drift
        '
        Me.chk_drift.Checked = True
        Me.chk_drift.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_drift.Location = New System.Drawing.Point(13, 147)
        Me.chk_drift.Name = "chk_drift"
        Me.chk_drift.Size = New System.Drawing.Size(158, 85)
        Me.chk_drift.TabIndex = 51
        Me.chk_drift.Text = "Show the heterezigosity (H) in independent replicate populations?"
        Me.chk_drift.UseVisualStyleBackColor = True
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(216, 12)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(530, 430)
        Me.maingraph.TabIndex = 4
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(111, 387)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(84, 55)
        Me.cmd_clear.TabIndex = 23
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(12, 387)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(84, 55)
        Me.cmd_save.TabIndex = 38
        Me.cmd_save.Text = "Save Values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(671, 448)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 49
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Htime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 476)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Htime"
        Me.Text = "H decline over time"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_gen As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_drift As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_p As System.Windows.Forms.TextBox
    Friend WithEvents txt_size As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents chk_drift As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents l8 As System.Windows.Forms.Label
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents dlg_save As System.Windows.Forms.SaveFileDialog
    Friend WithEvents help_bt As System.Windows.Forms.Button
End Class
