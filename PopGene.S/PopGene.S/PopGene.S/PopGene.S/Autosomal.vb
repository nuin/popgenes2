Imports ZedGraph
Public Class Autosomal
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_h As System.Windows.Forms.TextBox
    Friend WithEvents txt_d As System.Windows.Forms.TextBox
    Friend WithEvents fra_values As System.Windows.Forms.GroupBox
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_value1 As System.Windows.Forms.Label
    Friend WithEvents lbl_value3 As System.Windows.Forms.Label
    Friend WithEvents lbl_value2 As System.Windows.Forms.Label
    Friend WithEvents lbl_value4 As System.Windows.Forms.Label
    Friend WithEvents lbl_value5 As System.Windows.Forms.Label
    Friend WithEvents lbl_value6 As System.Windows.Forms.Label
    Friend WithEvents lbl_value7 As System.Windows.Forms.Label
    Friend WithEvents lbl_value8 As System.Windows.Forms.Label
    Friend WithEvents lbl_value9 As System.Windows.Forms.Label
    Friend WithEvents lbl_value10 As System.Windows.Forms.Label
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Autosomal))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_h = New System.Windows.Forms.TextBox
        Me.txt_d = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.fra_values = New System.Windows.Forms.GroupBox
        Me.lbl_value10 = New System.Windows.Forms.Label
        Me.lbl_value9 = New System.Windows.Forms.Label
        Me.lbl_value8 = New System.Windows.Forms.Label
        Me.lbl_value7 = New System.Windows.Forms.Label
        Me.lbl_value6 = New System.Windows.Forms.Label
        Me.lbl_value5 = New System.Windows.Forms.Label
        Me.lbl_value4 = New System.Windows.Forms.Label
        Me.lbl_value2 = New System.Windows.Forms.Label
        Me.lbl_value3 = New System.Windows.Forms.Label
        Me.lbl_value1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.fra_values.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_h)
        Me.GroupBox1.Controls.Add(Me.txt_d)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
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
        Me.txt_h.Text = ""
        '
        'txt_d
        '
        Me.txt_d.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_d.Location = New System.Drawing.Point(56, 24)
        Me.txt_d.Name = "txt_d"
        Me.txt_d.Size = New System.Drawing.Size(64, 21)
        Me.txt_d.TabIndex = 0
        Me.txt_d.Text = ""
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(136, 24)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 2
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'fra_values
        '
        Me.fra_values.Controls.Add(Me.lbl_value10)
        Me.fra_values.Controls.Add(Me.lbl_value9)
        Me.fra_values.Controls.Add(Me.lbl_value8)
        Me.fra_values.Controls.Add(Me.lbl_value7)
        Me.fra_values.Controls.Add(Me.lbl_value6)
        Me.fra_values.Controls.Add(Me.lbl_value5)
        Me.fra_values.Controls.Add(Me.lbl_value4)
        Me.fra_values.Controls.Add(Me.lbl_value2)
        Me.fra_values.Controls.Add(Me.lbl_value3)
        Me.fra_values.Controls.Add(Me.lbl_value1)
        Me.fra_values.Controls.Add(Me.Label9)
        Me.fra_values.Controls.Add(Me.Label10)
        Me.fra_values.Controls.Add(Me.Label11)
        Me.fra_values.Controls.Add(Me.Label12)
        Me.fra_values.Controls.Add(Me.Label13)
        Me.fra_values.Controls.Add(Me.Label14)
        Me.fra_values.Controls.Add(Me.Label8)
        Me.fra_values.Controls.Add(Me.Label7)
        Me.fra_values.Controls.Add(Me.Label5)
        Me.fra_values.Controls.Add(Me.Label4)
        Me.fra_values.Controls.Add(Me.Label3)
        Me.fra_values.Controls.Add(Me.Label1)
        Me.fra_values.Location = New System.Drawing.Point(16, 112)
        Me.fra_values.Name = "fra_values"
        Me.fra_values.Size = New System.Drawing.Size(208, 256)
        Me.fra_values.TabIndex = 1
        Me.fra_values.TabStop = False
        Me.fra_values.Visible = False
        '
        'lbl_value10
        '
        Me.lbl_value10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value10.Location = New System.Drawing.Point(136, 200)
        Me.lbl_value10.Name = "lbl_value10"
        Me.lbl_value10.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value10.TabIndex = 47
        '
        'lbl_value9
        '
        Me.lbl_value9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value9.Location = New System.Drawing.Point(136, 152)
        Me.lbl_value9.Name = "lbl_value9"
        Me.lbl_value9.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value9.TabIndex = 46
        '
        'lbl_value8
        '
        Me.lbl_value8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value8.Location = New System.Drawing.Point(56, 200)
        Me.lbl_value8.Name = "lbl_value8"
        Me.lbl_value8.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value8.TabIndex = 45
        '
        'lbl_value7
        '
        Me.lbl_value7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value7.Location = New System.Drawing.Point(56, 176)
        Me.lbl_value7.Name = "lbl_value7"
        Me.lbl_value7.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value7.TabIndex = 44
        '
        'lbl_value6
        '
        Me.lbl_value6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value6.Location = New System.Drawing.Point(56, 152)
        Me.lbl_value6.Name = "lbl_value6"
        Me.lbl_value6.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value6.TabIndex = 43
        '
        'lbl_value5
        '
        Me.lbl_value5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value5.Location = New System.Drawing.Point(136, 96)
        Me.lbl_value5.Name = "lbl_value5"
        Me.lbl_value5.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value5.TabIndex = 42
        '
        'lbl_value4
        '
        Me.lbl_value4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value4.Location = New System.Drawing.Point(136, 48)
        Me.lbl_value4.Name = "lbl_value4"
        Me.lbl_value4.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value4.TabIndex = 41
        '
        'lbl_value2
        '
        Me.lbl_value2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value2.Location = New System.Drawing.Point(64, 72)
        Me.lbl_value2.Name = "lbl_value2"
        Me.lbl_value2.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value2.TabIndex = 40
        '
        'lbl_value3
        '
        Me.lbl_value3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value3.Location = New System.Drawing.Point(64, 96)
        Me.lbl_value3.Name = "lbl_value3"
        Me.lbl_value3.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value3.TabIndex = 39
        '
        'lbl_value1
        '
        Me.lbl_value1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value1.Location = New System.Drawing.Point(64, 48)
        Me.lbl_value1.Name = "lbl_value1"
        Me.lbl_value1.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value1.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(112, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 17)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "p:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(112, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 17)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "q:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 17)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "q2:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 17)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "2pq:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 152)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 17)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "p2:"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(16, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(136, 16)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Initial frequencies:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(112, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 17)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "p:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "q:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 17)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "P(aa):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "P(Aa):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "P(AA):"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Initial frequencies:"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(232, 16)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(470, 470)
        Me.maingraph.TabIndex = 2
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(160, 416)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(64, 72)
        Me.cmd_clear.TabIndex = 22
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Autosomal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 502)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.fra_values)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Autosomal"
        Me.Text = "Panmixia :: Autosomal"
        Me.GroupBox1.ResumeLayout(False)
        Me.fra_values.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        Dim d As Double
        Dim h As Double
        'takes the values inside the text boxes
        d = Val(Me.txt_d.Text)
        h = Val(Me.txt_h.Text)

        If d > 1 Or d < 0 Then
            MsgBox("Invalid frequency of homozygotes AA. Please restart.", vbExclamation)
            Exit Sub
        End If

        If h > 1 Or h < 0 Then
            MsgBox("Invalid frequency of heterozygotes Aa. Please restart.", vbExclamation)
            Exit Sub
        End If

        If d + h > 1 Then
            MsgBox("P(AA) + P(Aa) are over 1. Please restart.", vbExclamation)
            Exit Sub
        End If

        If txt_d.Text = "" Then txt_d.Text = "0"
        If txt_h.Text = "" Then txt_h.Text = "0"

        PlotPoints(maingraph, d, h)
        Captions(d, h)

    End Sub

    Private Sub txt_d_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_d.TextChanged

    End Sub

    Private Sub Autosomal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetGraph(maingraph)

    End Sub
    Private Sub PlotPoints(ByVal zgc As ZedGraphControl, ByVal d As Double, ByVal h As Double)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim enteredvalues As New PointPairList
        Dim panvalues As New PointPairList
        Dim line As New PointPairList

        d = d + h / 2

        enteredvalues.Add(d, h)
        panvalues.Add(d, 2 * d * (1 - d))
        line.Add(d, h)
        line.Add(d, 2 * d * (1 - d))

        Dim point1 As LineItem = canvas.AddCurve("", enteredvalues, Color.Red, SymbolType.Square)
        Dim point2 As LineItem = canvas.AddCurve("", panvalues, Color.Blue, SymbolType.Square)
        Dim connectline As LineItem = canvas.AddCurve("", line, Color.Gray, SymbolType.None)

        zgc.Refresh()

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

    Private Sub Captions(ByVal d As Double, ByVal h As Double)

        Me.fra_values.Visible = True
        Me.lbl_value1.Text = Format(d, "0.0000")
        Me.lbl_value2.Text = Format(h, "0.0000")
        Me.lbl_value3.Text = Format(1 - d - h, "0.0000")
        Me.lbl_value4.Text = Format(d + h / 2, "0.0000")
        Me.lbl_value5.Text = Format(1 - (d + h / 2), "0.0000")
        Me.lbl_value6.Text = Format((d + h / 2) * (d + h / 2), "0.0000")
        Me.lbl_value7.Text = Format(2 * (d + h / 2) * (1 - (d + h / 2)), "0.0000")
        Me.lbl_value8.Text = Format((1 - (d + h / 2)) * (1 - (d + h / 2)), "0.0000")
        Me.lbl_value9.Text = Format(d + h / 2, "0.0000")
        Me.lbl_value10.Text = Format(1 - (d + h / 2), "0.0000")
    End Sub

    Private Sub cmd_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_clear.Click
        ClearGraph(maingraph)
        SetGraph(maingraph)
        fra_values.Visible = False
    End Sub

    Private Sub ClearGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        zgc.GraphPane.CurveList.Clear()
        zgc.Refresh()
    End Sub
End Class
