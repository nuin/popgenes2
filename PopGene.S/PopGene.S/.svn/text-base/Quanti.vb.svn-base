Imports ZedGraph
Public Class Quanti
    Inherits System.Windows.Forms.Form


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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_q As System.Windows.Forms.TextBox
    Friend WithEvents txt_p As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_r As System.Windows.Forms.TextBox
    Friend WithEvents txt_h As System.Windows.Forms.TextBox
    Friend WithEvents txt_d As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Quanti))
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_q = New System.Windows.Forms.TextBox
        Me.txt_p = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_r = New System.Windows.Forms.TextBox
        Me.txt_h = New System.Windows.Forms.TextBox
        Me.txt_d = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.help_bt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "q"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "p"
        '
        'txt_q
        '
        Me.txt_q.BackColor = System.Drawing.Color.White
        Me.txt_q.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_q.Location = New System.Drawing.Point(58, 116)
        Me.txt_q.Name = "txt_q"
        Me.txt_q.ReadOnly = True
        Me.txt_q.Size = New System.Drawing.Size(64, 22)
        Me.txt_q.TabIndex = 16
        Me.txt_q.Text = "0.5"
        '
        'txt_p
        '
        Me.txt_p.BackColor = System.Drawing.Color.White
        Me.txt_p.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_p.Location = New System.Drawing.Point(58, 82)
        Me.txt_p.Name = "txt_p"
        Me.txt_p.ReadOnly = True
        Me.txt_p.Size = New System.Drawing.Size(64, 22)
        Me.txt_p.TabIndex = 15
        Me.txt_p.Text = "0.5"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "P(aa)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(138, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "P(Aa)"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(444, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Enter genotype frequency values and click OK"
        '
        'txt_r
        '
        Me.txt_r.BackColor = System.Drawing.Color.White
        Me.txt_r.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_r.Location = New System.Drawing.Point(306, 48)
        Me.txt_r.Name = "txt_r"
        Me.txt_r.ReadOnly = True
        Me.txt_r.Size = New System.Drawing.Size(64, 22)
        Me.txt_r.TabIndex = 2
        Me.txt_r.Text = "0.25"
        '
        'txt_h
        '
        Me.txt_h.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_h.Location = New System.Drawing.Point(186, 48)
        Me.txt_h.Name = "txt_h"
        Me.txt_h.Size = New System.Drawing.Size(64, 22)
        Me.txt_h.TabIndex = 1
        Me.txt_h.Text = "0.5"
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(58, 48)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 22)
        Me.txt_d.TabIndex = 0
        Me.txt_d.Text = "0.25"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txt_q)
        Me.GroupBox1.Controls.Add(Me.txt_p)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_r)
        Me.GroupBox1.Controls.Add(Me.txt_h)
        Me.GroupBox1.Controls.Add(Me.txt_d)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 153)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(306, 84)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 3
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "P(AA)"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(455, 34)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Curves represent Hardy-Weinberg expected genotype frequencies for a given allele " & _
            "frequency"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(8, 205)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(466, 412)
        Me.maingraph.TabIndex = 15
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(399, 623)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 16
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Quanti
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(481, 648)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Quanti"
        Me.Opacity = 0.5
        Me.Text = "Quantifying: 2 alleles"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Quanti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreateGraph(maingraph)
        txt_q.ReadOnly = True
        txt_r.ReadOnly = True
    End Sub

    Private Sub CreateGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i, ql, pl As Double
        Dim parabolapoints, curve1points, curve2points As New PointPairList

        canvas.Title.IsVisible = False
        canvas.X2Axis.IsVisible = True

        canvas.X2Axis.Title.Text = "frequency of A"
        canvas.YAxis.Title.Text = "Genotype frequencies"
        canvas.XAxis.Title.Text = "frequency of a"

        canvas.XAxis.Scale.Max = 1
        canvas.X2Axis.Scale.Max = 1

        canvas.YAxis.Scale.Max = 1

        For i = 0 To 1 Step 1 / 10000
            parabolapoints.Add(i, 2 * i * (1 - i))
            ql = i
            pl = 1 - i
            curve1points.Add(i, ql * ql)
            curve2points.Add(i, pl * pl)
            'pct_freqs.PSet (), RGB(255, 0, 0)
            'pct_freqs.PSet (i, 1 - 2 * pl * ql), RGB(0, 255, 0)
            'pct_freqs.PSet (i, 1 - pl * pl), RGB(0, 0, 255)

        Next
        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False
        Dim parabola As LineItem = canvas.AddCurve("P(aa)", parabolapoints, Color.Green, SymbolType.None)
        Dim curve1 As LineItem = canvas.AddCurve("P(Aa)", curve1points, Color.Red, SymbolType.None)
        Dim curve2 As LineItem = canvas.AddCurve("P(AA)", curve2points, Color.Blue, SymbolType.None)

    End Sub
    Private Sub AddPoint(ByVal zgc As ZedGraphControl)

        Dim p, h As Double
        Dim canvas As GraphPane = zgc.GraphPane

        p = Val(Me.txt_p.Text)
        h = Val(Me.txt_h.Text)

        Dim pointset As New PointPairList
        pointset.Add(p, h)

        Dim point As LineItem = canvas.AddCurve("", pointset, Color.Black, SymbolType.Circle)

        zgc.Refresh()
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim d, h As Double

        If txt_d.Text <> "" Then d = Val(txt_d.Text)
        If txt_h.Text <> "" Then h = Val(txt_h.Text)

        If d > 1 Then
            MsgBox("P(AA) cannot be greater than 1. Please restart")
            txt_d.Text = ""
            txt_h.Text = ""
            Exit Sub
        End If

        If h > 1 Then
            MsgBox("P(Aa) cannot be greater than 1. Please restart")
            txt_d.Text = ""
            txt_h.Text = ""
            Exit Sub
        End If

        If d + h > 1 Then
            MsgBox("P(AA) + P(Aa) cannot be greater than 1. Please restart")
            txt_d.Text = ""
            txt_h.Text = ""
            Exit Sub
        End If
        AddPoint(maingraph)

    End Sub

    Private Sub txt_d_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_d.TextChanged
        Dim r, p As Double
        r = 1 - Val(Me.txt_d.Text) - Val(Me.txt_h.Text)
        p = Val(Me.txt_d.Text) + Val(Me.txt_h.Text) / 2

        Me.txt_r.Text = r
        Me.txt_p.Text = p

    End Sub

    Private Sub txt_h_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_h.TextChanged
        Me.txt_r.Text = 1 - Val(Me.txt_d.Text) - Val(Me.txt_h.Text)
        Me.txt_p.Text = Val(Me.txt_d.Text) + Val(Me.txt_h.Text) / 2
    End Sub

    Private Sub txt_p_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_p.TextChanged
        Dim p As Double
        p = Val(Me.txt_p.Text)
        txt_q.Text = 1 - Val(Me.txt_p.Text)
    End Sub

    Private Sub txt_q_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_q.TextChanged
        Dim q As Double
        q = Val(Me.txt_q.Text)
        txt_p.Text = 1 - Val(Me.txt_q.Text)
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/genotype.html")
    End Sub
End Class
