Imports ZedGraph
Public Class LinkHisto
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
    Friend WithEvents maingraph As ZedGraph.ZedGraphControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.maingraph = New ZedGraph.ZedGraphControl
        Me.SuspendLayout()
        '
        'maingraph
        '
        Me.maingraph.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.maingraph.Location = New System.Drawing.Point(8, 8)
        Me.maingraph.Name = "maingraph"
        Me.maingraph.ScrollGrace = 0
        Me.maingraph.ScrollMaxX = 0
        Me.maingraph.ScrollMaxY = 0
        Me.maingraph.ScrollMaxY2 = 0
        Me.maingraph.ScrollMinX = 0
        Me.maingraph.ScrollMinY = 0
        Me.maingraph.ScrollMinY2 = 0
        Me.maingraph.Size = New System.Drawing.Size(440, 424)
        Me.maingraph.TabIndex = 0
        '
        'LinkHisto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 438)
        Me.Controls.Add(Me.maingraph)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "LinkHisto"
        Me.Text = "Linkage :: Histogram"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LinkHisto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Histogram(maingraph)

    End Sub

    Private Sub Histogram(ByVal zgc As ZedGraphControl)

        Dim t1 As Double
        Dim t2 As Double
        Dim canvas As GraphPane = zgc.GraphPane
        Dim label(3) As String
        Dim plist1 As New PointPairList
        Dim plist2 As New PointPairList

        Dim b1(3) As Double
        Dim b2(3) As Double

        label(0) = "AB"
        label(1) = "Ab"
        label(2) = "aB"
        label(3) = "ab"

        t1 = h1 + h3 + h5 + h7
        t2 = h2 + h4 + h6 + h8

        b1(0) = (h1 / t1) : b2(0) = (h2 / t2)
        b1(1) = (h3 / t1) : b2(1) = (h4 / t2)
        b1(2) = (h5 / t1) : b2(2) = (h6 / t2)
        b1(3) = (h7 / t1) : b2(3) = h8 / t2

        plist1.Add(0, b1(0)) : plist2.Add(0, b2(0))
        plist1.Add(1, b1(1)) : plist2.Add(1, b2(1))
        plist1.Add(2, b1(2)) : plist2.Add(2, b2(2))
        plist1.Add(3, b1(3)) : plist2.Add(3, b2(3))

        canvas.Title.IsVisible = False
        canvas.XAxis.Title.Text = "Gamete categories"
        canvas.YAxis.Title.IsVisible = False

        canvas.Chart.Fill = New Fill(Color.White, Color.SteelBlue, 45.0F)

        Dim myCurve1 As BarItem = canvas.AddBar("Observed frequencies", plist1, Color.Black)
        Dim mycurve2 As BarItem = canvas.AddBar("Expected frequencies", plist2, Color.LightGray)
        canvas.XAxis.MajorTic.IsBetweenLabels = True
        canvas.XAxis.Type = AxisType.Text
        canvas.XAxis.Scale.TextLabels = label

        zgc.AxisChange()
        zgc.Refresh()
        'frm_linkhisto.pct_histo.Line (0, 1)-(0.1, 1 - (h1 / t1)), , BF
        'frm_linkhisto.pct_histo.Line (0.1, 1)-(0.2, 1 - (h2 / t2)), , B
        '    frm_linkhisto.pct_histo.CurrentX = 0.08
        '    frm_linkhisto.pct_histo.CurrentY = 1.01
        '    frm_linkhisto.pct_histo.Print("AB")

        'frm_linkhisto.pct_histo.Line (0.25, 1)-(0.35, 1 - (h3 / t1)), , BF
        'frm_linkhisto.pct_histo.Line (0.35, 1)-(0.45, 1 - (h4 / t2)), , B
        '    frm_linkhisto.pct_histo.CurrentX = 0.33
        '    frm_linkhisto.pct_histo.CurrentY = 1.01
        '    frm_linkhisto.pct_histo.Print("Ab")

        'frm_linkhisto.pct_histo.Line (0.5, 1)-(0.6, 1 - (h5 / t1)), , BF
        'frm_linkhisto.pct_histo.Line (0.6, 1)-(0.7, 1 - (h6 / t2)), , B
        '    frm_linkhisto.pct_histo.CurrentX = 0.58
        '    frm_linkhisto.pct_histo.CurrentY = 1.01
        '    frm_linkhisto.pct_histo.Print("aB")

        'frm_linkhisto.pct_histo.Line (0.75, 1)-(0.85, 1 - (h7 / t1)), , BF
        'frm_linkhisto.pct_histo.Line (0.85, 1)-(0.95, 1 - (h8 / t2)), , B
        '    frm_linkhisto.pct_histo.CurrentX = 0.83
        '    frm_linkhisto.pct_histo.CurrentY = 1.01
        '    frm_linkhisto.pct_histo.Print("ab")

        '    frm_linkhisto.pct_histo.CurrentX = frm_linkhisto.pct_histo.ScaleWidth / 3
        '    frm_linkhisto.pct_histo.CurrentY = 1.05
        '    frm_linkhisto.pct_histo.Print("Gamete categories")

        'frm_linkhisto.pct_histo.Line (0, -0.06)-(0.03, -0.03), , BF
        '    frm_linkhisto.pct_histo.CurrentX = 0.04
        '    frm_linkhisto.pct_histo.CurrentY = -0.07
        '    frm_linkhisto.pct_histo.Print("Observed Frequencies")

        'frm_linkhisto.pct_histo.Line (0.5, -0.06)-(0.53, -0.03), , B
        '    frm_linkhisto.pct_histo.CurrentX = 0.54
        '    frm_linkhisto.pct_histo.CurrentY = -0.07
        '    frm_linkhisto.pct_histo.Print("Expected Frequencies")



    End Sub

End Class
