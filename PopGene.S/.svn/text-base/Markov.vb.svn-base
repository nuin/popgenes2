Imports ZedGraph
Imports System
Public Class Markov

    Inherits System.Windows.Forms.Form
    Dim matrix(,) As Double
    Dim vector() As Double
    Dim inifreq As Double
    Dim cl As Integer
    Dim gen As Integer
    Dim rungen As Integer = 0
    Dim newvec() As Double


    Friend WithEvents cmb_freq As System.Windows.Forms.ComboBox
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    Friend WithEvents grd_matrix As System.Windows.Forms.DataGridView
    Friend WithEvents grd_vector As System.Windows.Forms.DataGridView
    Friend WithEvents fra_gen As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_start As System.Windows.Forms.Button
    Friend WithEvents txt_gen As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_gen As System.Windows.Forms.Label
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents help_bt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label


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
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents fra_box As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_size As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmd_ok As System.Windows.Forms.Button
    Friend WithEvents txt_n As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Markov))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.fra_box = New System.Windows.Forms.GroupBox
        Me.txt_n = New System.Windows.Forms.TextBox
        Me.cmd_ok = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbl_size = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmb_freq = New System.Windows.Forms.ComboBox
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.grd_matrix = New System.Windows.Forms.DataGridView
        Me.grd_vector = New System.Windows.Forms.DataGridView
        Me.fra_gen = New System.Windows.Forms.GroupBox
        Me.txt_gen = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmd_start = New System.Windows.Forms.Button
        Me.lbl_gen = New System.Windows.Forms.Label
        Me.cmd_save = New System.Windows.Forms.Button
        Me.help_bt = New System.Windows.Forms.Button
        Me.fra_box.SuspendLayout()
        CType(Me.grd_matrix, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd_vector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fra_gen.SuspendLayout()
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fra_box
        '
        Me.fra_box.Controls.Add(Me.txt_n)
        Me.fra_box.Controls.Add(Me.cmd_ok)
        Me.fra_box.Controls.Add(Me.Label12)
        Me.fra_box.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_box.Location = New System.Drawing.Point(12, 4)
        Me.fra_box.Name = "fra_box"
        Me.fra_box.Size = New System.Drawing.Size(204, 83)
        Me.fra_box.TabIndex = 11
        Me.fra_box.TabStop = False
        '
        'txt_n
        '
        Me.txt_n.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_n.Location = New System.Drawing.Point(34, 46)
        Me.txt_n.Name = "txt_n"
        Me.txt_n.Size = New System.Drawing.Size(64, 22)
        Me.txt_n.TabIndex = 54
        '
        'cmd_ok
        '
        Me.cmd_ok.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_ok.Image = CType(resources.GetObject("cmd_ok.Image"), System.Drawing.Image)
        Me.cmd_ok.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_ok.Location = New System.Drawing.Point(134, 15)
        Me.cmd_ok.Name = "cmd_ok"
        Me.cmd_ok.Size = New System.Drawing.Size(64, 60)
        Me.cmd_ok.TabIndex = 53
        Me.cmd_ok.Text = "OK"
        Me.cmd_ok.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 37)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Effective population size"
        '
        'lbl_size
        '
        Me.lbl_size.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_size.Location = New System.Drawing.Point(222, 12)
        Me.lbl_size.Name = "lbl_size"
        Me.lbl_size.Size = New System.Drawing.Size(246, 58)
        Me.lbl_size.TabIndex = 42
        Me.lbl_size.Text = "00000"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 342)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Transition matrix"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 342)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 35)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Probabilities vector"
        '
        'cmb_freq
        '
        Me.cmb_freq.FormattingEnabled = True
        Me.cmb_freq.Location = New System.Drawing.Point(366, 65)
        Me.cmb_freq.Name = "cmb_freq"
        Me.cmb_freq.Size = New System.Drawing.Size(102, 22)
        Me.cmb_freq.TabIndex = 53
        Me.cmb_freq.Visible = False
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(484, 101)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(432, 485)
        Me.maingraph.TabIndex = 56
        '
        'grd_matrix
        '
        Me.grd_matrix.AllowUserToAddRows = False
        Me.grd_matrix.AllowUserToDeleteRows = False
        Me.grd_matrix.BackgroundColor = System.Drawing.Color.White
        Me.grd_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_matrix.Location = New System.Drawing.Point(116, 101)
        Me.grd_matrix.Name = "grd_matrix"
        Me.grd_matrix.ReadOnly = True
        Me.grd_matrix.Size = New System.Drawing.Size(362, 227)
        Me.grd_matrix.TabIndex = 58
        '
        'grd_vector
        '
        Me.grd_vector.AllowUserToAddRows = False
        Me.grd_vector.AllowUserToDeleteRows = False
        Me.grd_vector.BackgroundColor = System.Drawing.Color.White
        Me.grd_vector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grd_vector.Location = New System.Drawing.Point(10, 101)
        Me.grd_vector.MultiSelect = False
        Me.grd_vector.Name = "grd_vector"
        Me.grd_vector.ReadOnly = True
        Me.grd_vector.RowHeadersWidth = 30
        Me.grd_vector.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grd_vector.Size = New System.Drawing.Size(100, 227)
        Me.grd_vector.TabIndex = 59
        '
        'fra_gen
        '
        Me.fra_gen.Controls.Add(Me.txt_gen)
        Me.fra_gen.Controls.Add(Me.Label2)
        Me.fra_gen.Controls.Add(Me.cmd_start)
        Me.fra_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_gen.Location = New System.Drawing.Point(484, 4)
        Me.fra_gen.Name = "fra_gen"
        Me.fra_gen.Size = New System.Drawing.Size(212, 83)
        Me.fra_gen.TabIndex = 60
        Me.fra_gen.TabStop = False
        Me.fra_gen.Visible = False
        '
        'txt_gen
        '
        Me.txt_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gen.Location = New System.Drawing.Point(51, 46)
        Me.txt_gen.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.txt_gen.Name = "txt_gen"
        Me.txt_gen.Size = New System.Drawing.Size(64, 22)
        Me.txt_gen.TabIndex = 55
        Me.txt_gen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 23)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Generations to run"
        '
        'cmd_start
        '
        Me.cmd_start.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_start.Image = CType(resources.GetObject("cmd_start.Image"), System.Drawing.Image)
        Me.cmd_start.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_start.Location = New System.Drawing.Point(134, 15)
        Me.cmd_start.Name = "cmd_start"
        Me.cmd_start.Size = New System.Drawing.Size(64, 60)
        Me.cmd_start.TabIndex = 53
        Me.cmd_start.Text = "Start"
        Me.cmd_start.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbl_gen
        '
        Me.lbl_gen.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gen.Location = New System.Drawing.Point(702, 73)
        Me.lbl_gen.Name = "lbl_gen"
        Me.lbl_gen.Size = New System.Drawing.Size(139, 16)
        Me.lbl_gen.TabIndex = 61
        Me.lbl_gen.Text = "Generations run: "
        Me.lbl_gen.Visible = False
        '
        'cmd_save
        '
        Me.cmd_save.Enabled = False
        Me.cmd_save.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Image = CType(resources.GetObject("cmd_save.Image"), System.Drawing.Image)
        Me.cmd_save.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_save.Location = New System.Drawing.Point(394, 531)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(84, 55)
        Me.cmd_save.TabIndex = 62
        Me.cmd_save.Text = "Save Values"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_save.Visible = False
        '
        'help_bt
        '
        Me.help_bt.Location = New System.Drawing.Point(313, 563)
        Me.help_bt.Name = "help_bt"
        Me.help_bt.Size = New System.Drawing.Size(75, 23)
        Me.help_bt.TabIndex = 63
        Me.help_bt.Text = "Help"
        Me.help_bt.UseVisualStyleBackColor = True
        '
        'Markov
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(928, 598)
        Me.Controls.Add(Me.help_bt)
        Me.Controls.Add(Me.cmd_save)
        Me.Controls.Add(Me.cmb_freq)
        Me.Controls.Add(Me.lbl_gen)
        Me.Controls.Add(Me.fra_gen)
        Me.Controls.Add(Me.grd_vector)
        Me.Controls.Add(Me.grd_matrix)
        Me.Controls.Add(Me.maingraph)
        Me.Controls.Add(Me.fra_box)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_size)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Markov"
        Me.Text = "Markov Process"
        Me.fra_box.ResumeLayout(False)
        Me.fra_box.PerformLayout()
        CType(Me.grd_matrix, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd_vector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fra_gen.ResumeLayout(False)
        CType(Me.txt_gen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Markov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_size.Text = ""
        SetGraph(maingraph)
    End Sub

    Private Sub cmd_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ok.Click
        Dim i, j, n As Integer
        Dim m, q, p As Double

        cl = 2 * Val(txt_n.Text) + 1

        cmb_freq.Items.Clear()


        If Val(txt_n.Text) > 70 Then
            MsgBox("Maximum population size is 70. Grid objects limit size to 150 rows and columns. Sorry for any inconvenience.")
            Exit Sub
        End If

        lbl_size.Text = "There are " & cl & " possible states for this population."
        lbl_size.Text = lbl_size.Text & " Select the starting frequency from the drop down box below and click Start to run"
        'cmb_freq.Visible = True
        'cmd_ok2.Visible = True

        n = 0
        For m = 0 To 1.00001 Step 1 / (cl - 1)
            cmb_freq.Items.Add(Format(m, "0.0000"))
            'cmb_freq.ItemData(cmb_freq.NewIndex) = n
            n = n + 1
        Next
        ' cmb_freq.AddItem "1"

        ReDim matrix(cl, cl)

        Dim c4 As New DataGridViewColumn(New DataGridViewTextBoxCell())
        c4.Width = 40
        c4.FillWeight = 1
        c4.Name = "State"
        grd_matrix.Columns.Add(c4)

        For i = 1 To cl
            Dim c As New DataGridViewColumn(New DataGridViewTextBoxCell())
            c.Width = 50
            c.FillWeight = 1
            c.Name = (i - 1).ToString
            c.Resizable = DataGridViewTriState.False
            grd_matrix.Columns.Add(c)
        Next
        grd_matrix.Rows.Add(cl)
        grd_matrix.RowHeadersVisible = False

        Dim c2 As New DataGridViewColumn(New DataGridViewTextBoxCell())
        c2.Width = 40
        c2.FillWeight = 1
        c2.Name = "State"
        c2.Resizable = DataGridViewTriState.False
        grd_vector.Columns.Add(c2)

        Dim c3 As New DataGridViewColumn(New DataGridViewTextBoxCell())
        c3.Width = 50
        c3.FillWeight = 1
        c3.Name = ""
        c3.Resizable = DataGridViewTriState.False
        grd_vector.Columns.Add(c3)

        grd_vector.Rows.Add(cl)
        grd_vector.RowHeadersVisible = False

        matrix(1, 1) = 1
        matrix(cl, cl) = 1

        For i = 0 To cl - 1
            q = (i - 1) / (cl - 1)
            p = 1 - q
            matrix(i, 1) = p ^ (cl - 1)
            matrix(i, cl) = q ^ (cl - 1)
            For j = 2 To cl - 1
                matrix(i, j) = (cl - (j - 1)) * q * matrix(i, j - 1) / ((j - 1) * p)
            Next
        Next

        For i = 0 To cl - 1
            grd_matrix.Rows(i).Cells(0).Value = i
            grd_vector.Rows(i).Cells(0).Value = i
        Next

        For i = 1 To cl
            For j = 1 To cl
                grd_matrix.Rows(i - 1).Cells(j).Value = Format(matrix(i, j), "0.0000")
            Next
        Next
        cmb_freq.Visible = True
        cmd_ok.Enabled = False
    End Sub

    Private Sub SetGraph(ByVal zgc As ZedGraphControl)
        Dim canvas As GraphPane = zgc.GraphPane
        canvas.Title.IsVisible = False
        canvas.XAxis.IsVisible = False
        canvas.YAxis.IsVisible = False
        zgc.Refresh()
        zgc.AxisChange()
    End Sub

    Private Sub cmb_freq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_freq.SelectedIndexChanged
        Dim selected As Integer
        Dim i As Integer
        selected = cmb_freq.SelectedIndex
        inifreq = cmb_freq.SelectedItem

        ReDim vector(cl)

        For i = 1 To cl
            If i = selected + 1 Then
                grd_vector.Rows(i - 1).Cells(1).Value = 1
                vector(i) = 1
            Else
                grd_vector.Rows(i - 1).Cells(1).Value = 0
                vector(i) = 0
            End If
        Next

        PlotInitial(maingraph)
        fra_gen.Visible = True
        lbl_gen.Visible = True
    End Sub
    Private Sub PlotInitial(ByVal zgc As ZedGraphControl)
        Dim i As Integer
        Dim canvas As GraphPane = zgc.GraphPane
        Dim label(cl - 1) As String
        Dim plist As New PointPairList
        Dim b1(3), b2(3) As Double

        canvas.CurveList.Clear()

        For i = 1 To cl
            label(i - 1) = i - 1.ToString
            plist.Add(i - 1, vector(i))
        Next

        canvas.XAxis.IsVisible = True
        canvas.XAxis.Title.Text = "State"

        canvas.YAxis.IsVisible = True
        canvas.YAxis.Scale.Max = cl - 2
        canvas.YAxis.Scale.Max = 1
        canvas.YAxis.Title.Text = "p"

        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False

        Dim myCurve1 As BarItem = canvas.AddBar("", plist, Color.Black)
        canvas.XAxis.MajorTic.IsBetweenLabels = True
        canvas.XAxis.Type = AxisType.Text
        canvas.XAxis.Scale.TextLabels = label

        zgc.AxisChange()
        zgc.Refresh()
    End Sub

    Private Sub cmd_start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_start.Click
        ReDim newvec(cl)
        Dim i, j, k As Integer

        gen = Val(txt_gen.Text)

        For k = 0 To gen
            For i = 1 To cl
                For j = 1 To cl
                    newvec(i) = newvec(i) + vector(j) * matrix(j, i)
                Next
                grd_vector.Rows(i - 1).Cells(1).Value = Format(newvec(i), "0.0000")
            Next

            For i = 1 To cl
                vector(i) = newvec(i)
                newvec(i) = 0
            Next
            PlotGens(maingraph)
        Next

        rungen = rungen + gen
        lbl_gen.Text = "Generations run: " + rungen.ToString
    End Sub
    Private Sub PlotGens(ByVal zgc As ZedGraphControl)
        Dim i As Integer
        Dim canvas As GraphPane = zgc.GraphPane
        Dim label(cl - 1) As String
        Dim plist As New PointPairList
        Dim b1(3), b2(3) As Double

        canvas.CurveList.Clear()

        For i = 1 To cl
            label(i - 1) = i - 1.ToString
            plist.Add(i - 1, vector(i))
        Next

        canvas.Title.IsVisible = False
        canvas.XAxis.IsVisible = True
        canvas.XAxis.Title.Text = "State"

        canvas.YAxis.IsVisible = True
        canvas.YAxis.Scale.Max = cl - 2
        canvas.YAxis.Scale.Max = 1
        canvas.YAxis.Title.Text = "p"

        canvas.XAxis.Scale.FontSpec.Size = 12
        canvas.YAxis.Scale.FontSpec.Size = 12
        canvas.Legend.FontSpec.Size = 12
        canvas.Legend.Border.IsVisible = False

        Dim myCurve1 As BarItem = canvas.AddBar("", plist, Color.Black)
        canvas.XAxis.MajorTic.IsBetweenLabels = True
        canvas.XAxis.Type = AxisType.Text
        canvas.XAxis.Scale.TextLabels = label

        zgc.AxisChange()
        zgc.Refresh()
    End Sub

    Private Sub help_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help_bt.Click
        System.Diagnostics.Process.Start("http://genedrift.org/popgeneshelp/markov.html")
    End Sub
End Class
