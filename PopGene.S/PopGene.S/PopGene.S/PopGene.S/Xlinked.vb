Imports ZedGraph
Public Class Xlinked
    Inherits System.Windows.Forms.Form
    Dim xlinked_pf(20) As Double
    Dim xlinked_pm(20) As Double
    Dim delta(20) As Double
    Dim pfList As New PointPairList
    Dim pmList As New PointPairList
    Dim deltaList As New PointPairList

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
    Friend WithEvents txt_pm As System.Windows.Forms.TextBox
    Friend WithEvents txt_pf As System.Windows.Forms.TextBox
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
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
    Friend WithEvents lbl_value1 As System.Windows.Forms.Label
    Friend WithEvents lbl_value2 As System.Windows.Forms.Label
    Friend WithEvents lbl_value3 As System.Windows.Forms.Label
    Friend WithEvents lbl_value4 As System.Windows.Forms.Label
    Friend WithEvents lbl_value5 As System.Windows.Forms.Label
    Friend WithEvents lbl_value6 As System.Windows.Forms.Label
    Friend WithEvents lbl_value7 As System.Windows.Forms.Label
    Friend WithEvents chk_delta As System.Windows.Forms.CheckBox
    Friend WithEvents fra_values As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Xlinked))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt_pm = New System.Windows.Forms.TextBox
        Me.txt_pf = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.fra_values = New System.Windows.Forms.GroupBox
        Me.lbl_value7 = New System.Windows.Forms.Label
        Me.lbl_value6 = New System.Windows.Forms.Label
        Me.lbl_value5 = New System.Windows.Forms.Label
        Me.lbl_value4 = New System.Windows.Forms.Label
        Me.lbl_value3 = New System.Windows.Forms.Label
        Me.lbl_value2 = New System.Windows.Forms.Label
        Me.lbl_value1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.chk_delta = New System.Windows.Forms.CheckBox
        Me.cmd_clear = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.fra_values.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_pm)
        Me.GroupBox1.Controls.Add(Me.txt_pf)
        Me.GroupBox1.Controls.Add(Me.cmd_ok)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "pf(A)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "pm(A)"
        '
        'txt_pm
        '
        Me.txt_pm.AcceptsReturn = True
        Me.txt_pm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pm.Location = New System.Drawing.Point(68, 48)
        Me.txt_pm.Name = "txt_pm"
        Me.txt_pm.Size = New System.Drawing.Size(64, 21)
        Me.txt_pm.TabIndex = 1
        Me.txt_pm.Text = "0"
        '
        'txt_pf
        '
        Me.txt_pf.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pf.Location = New System.Drawing.Point(68, 16)
        Me.txt_pf.Name = "txt_pf"
        Me.txt_pf.Size = New System.Drawing.Size(64, 21)
        Me.txt_pf.TabIndex = 0
        Me.txt_pf.Text = "1"
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(148, 16)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 56)
        Me.cmd_ok.TabIndex = 2
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'fra_values
        '
        Me.fra_values.Controls.Add(Me.lbl_value7)
        Me.fra_values.Controls.Add(Me.lbl_value6)
        Me.fra_values.Controls.Add(Me.lbl_value5)
        Me.fra_values.Controls.Add(Me.lbl_value4)
        Me.fra_values.Controls.Add(Me.lbl_value3)
        Me.fra_values.Controls.Add(Me.lbl_value2)
        Me.fra_values.Controls.Add(Me.lbl_value1)
        Me.fra_values.Controls.Add(Me.Label11)
        Me.fra_values.Controls.Add(Me.Label9)
        Me.fra_values.Controls.Add(Me.Label10)
        Me.fra_values.Controls.Add(Me.Label7)
        Me.fra_values.Controls.Add(Me.Label8)
        Me.fra_values.Controls.Add(Me.Label5)
        Me.fra_values.Controls.Add(Me.Label4)
        Me.fra_values.Controls.Add(Me.Label3)
        Me.fra_values.Controls.Add(Me.Label1)
        Me.fra_values.Location = New System.Drawing.Point(16, 128)
        Me.fra_values.Name = "fra_values"
        Me.fra_values.Size = New System.Drawing.Size(232, 184)
        Me.fra_values.TabIndex = 1
        Me.fra_values.TabStop = False
        Me.fra_values.Visible = False
        '
        'lbl_value7
        '
        Me.lbl_value7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value7.Location = New System.Drawing.Point(160, 144)
        Me.lbl_value7.Name = "lbl_value7"
        Me.lbl_value7.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value7.TabIndex = 47
        '
        'lbl_value6
        '
        Me.lbl_value6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value6.Location = New System.Drawing.Point(48, 144)
        Me.lbl_value6.Name = "lbl_value6"
        Me.lbl_value6.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value6.TabIndex = 46
        '
        'lbl_value5
        '
        Me.lbl_value5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value5.Location = New System.Drawing.Point(48, 120)
        Me.lbl_value5.Name = "lbl_value5"
        Me.lbl_value5.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value5.TabIndex = 45
        '
        'lbl_value4
        '
        Me.lbl_value4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value4.Location = New System.Drawing.Point(160, 96)
        Me.lbl_value4.Name = "lbl_value4"
        Me.lbl_value4.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value4.TabIndex = 44
        '
        'lbl_value3
        '
        Me.lbl_value3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value3.Location = New System.Drawing.Point(48, 96)
        Me.lbl_value3.Name = "lbl_value3"
        Me.lbl_value3.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value3.TabIndex = 43
        '
        'lbl_value2
        '
        Me.lbl_value2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value2.Location = New System.Drawing.Point(160, 40)
        Me.lbl_value2.Name = "lbl_value2"
        Me.lbl_value2.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value2.TabIndex = 42
        '
        'lbl_value1
        '
        Me.lbl_value1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_value1.Location = New System.Drawing.Point(48, 40)
        Me.lbl_value1.Name = "lbl_value1"
        Me.lbl_value1.Size = New System.Drawing.Size(40, 16)
        Me.lbl_value1.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(120, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 17)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "2pq:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 17)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "p2:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 17)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "q2:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "p:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(120, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "q:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Female frequencies"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "p:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(120, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "q:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Male frequencies"
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(264, 24)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(536, 408)
        Me.maingraph.TabIndex = 2
        '
        'chk_delta
        '
        Me.chk_delta.Location = New System.Drawing.Point(16, 104)
        Me.chk_delta.Name = "chk_delta"
        Me.chk_delta.Size = New System.Drawing.Size(232, 16)
        Me.chk_delta.TabIndex = 3
        Me.chk_delta.Text = "Display delta(p) curve?"
        '
        'cmd_clear
        '
        Me.cmd_clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.Image = CType(resources.GetObject("cmd_clear.Image"), System.Drawing.Image)
        Me.cmd_clear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_clear.Location = New System.Drawing.Point(184, 360)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(64, 72)
        Me.cmd_clear.TabIndex = 4
        Me.cmd_clear.Text = "Clear Screen"
        Me.cmd_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Xlinked
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(816, 446)
        Me.Controls.Add(Me.cmd_clear)
        Me.Controls.Add(Me.chk_delta)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.fra_values)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Xlinked"
        Me.Text = "Panmixia :: X-linked"
        Me.GroupBox1.ResumeLayout(False)
        Me.fra_values.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Xlinked_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetGraph(maingraph)

    End Sub

    Private Sub SetGraph(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane

        canvas.Title.IsVisible = False
        canvas.XAxis.Scale.Max = 20
        canvas.XAxis.Scale.MajorStep = 1
        canvas.XAxis.MinorTic.IsAllTics = False
        canvas.XAxis.Title.Text = "Generations"
        canvas.X2Axis.IsVisible = False

        canvas.YAxis.Scale.Max = 1
        canvas.YAxis.Title.Text = "frequency of A"
        zgc.AxisChange()
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click

        xlinked_pm(0) = Val(txt_pm.Text)
        xlinked_pf(0) = Val(txt_pf.Text)
        delta(0) = System.Math.Abs(xlinked_pm(0) - xlinked_pf(0))

        If Me.chk_delta.Checked = True Then
            PlotPoints(maingraph, True)
        Else
            PlotPoints(maingraph, False)
        End If

        lbl_value1.Text = Format(xlinked_pm(20), "0.0000")
        lbl_value2.Text = Format(1 - xlinked_pm(20), "0.0000")
        lbl_value3.Text = Format(xlinked_pm(20) * xlinked_pf(20), "0.0000")
        lbl_value4.Text = Format(xlinked_pf(20) * (1 - xlinked_pf(20)) + xlinked_pf(20) * (1 - xlinked_pf(20)), "0.0000")
        lbl_value5.Text = Format((1 - xlinked_pf(20)) * (1 - xlinked_pf(20)), "0.0000")
        lbl_value6.Text = Format(xlinked_pf(20), "0.0000")
        lbl_value7.Text = Format(1 - xlinked_pf(20), "0.0000")

        fra_values.Visible = True
    End Sub
    Private Sub PlotPoints(ByVal zgc As ZedGraphControl, ByVal deltachecked As Boolean)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim i As Integer

        pfList.Clear()
        pmList.Clear()
        deltaList.Clear()

        pfList.Add(0, xlinked_pf(0))
        pmList.Add(0, xlinked_pm(0))
        deltaList.Add(0, delta(0))

        For i = 1 To 20
            xlinked_pf(i) = (xlinked_pf(i - 1) + xlinked_pm(i - 1)) / 2
            xlinked_pm(i) = xlinked_pf(i - 1)
            delta(i) = System.Math.Abs(xlinked_pm(i) - xlinked_pf(i))
            pfList.Add(i, xlinked_pf(i))
            pmList.Add(i, xlinked_pm(i))
            deltaList.Add(i, delta(i))
        Next

        Dim male As LineItem = canvas.AddCurve("pm", pmList, Color.Blue, SymbolType.None)
        Dim female As LineItem = canvas.AddCurve("pf", pfList, Color.Red, SymbolType.None)
        If deltachecked = True Then
            Dim deltacurve As LineItem = canvas.AddCurve("delta(p)", deltaList, Color.Gray, SymbolType.None)
        End If
        zgc.AxisChange()
        zgc.Refresh()
    End Sub
    Private Sub chk_delta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_delta.Click

        If chk_delta.Checked = False Then
            RemoveDelta(maingraph)
        Else
            AddDelta(maingraph)
        End If

    End Sub

    Private Sub RemoveDelta(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane

        canvas.CurveList.Remove(2)
        zgc.Refresh()

    End Sub
    Private Sub AddDelta(ByVal zgc As ZedGraphControl)

        Dim canvas As GraphPane = zgc.GraphPane
        Dim deltacurve As LineItem = canvas.AddCurve("delta(p)", deltaList, Color.Gray, SymbolType.None)

        zgc.Refresh()

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
