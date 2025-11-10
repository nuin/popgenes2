
Public Class mainF
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents chisquare_mnu As System.Windows.Forms.MenuItem
    Friend WithEvents quanti_mnu As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents autosomal_mnu As System.Windows.Forms.MenuItem
    Friend WithEvents xlinked_mnu As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_magd As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_drift As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_driftsoft As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_driftmut As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_driftsoftmut As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_markov As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_linkage As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_selgnal As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_seldep As System.Windows.Forms.MenuItem
    Friend WithEvents mnu_seldepcart As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.chisquare_mnu = New System.Windows.Forms.MenuItem
        Me.quanti_mnu = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.autosomal_mnu = New System.Windows.Forms.MenuItem
        Me.xlinked_mnu = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.mnu_linkage = New System.Windows.Forms.MenuItem
        Me.mnu_magd = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.mnu_drift = New System.Windows.Forms.MenuItem
        Me.mnu_driftsoft = New System.Windows.Forms.MenuItem
        Me.mnu_driftmut = New System.Windows.Forms.MenuItem
        Me.mnu_driftsoftmut = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.mnu_markov = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.mnu_selgnal = New System.Windows.Forms.MenuItem
        Me.mnu_seldep = New System.Windows.Forms.MenuItem
        Me.mnu_seldepcart = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem6, Me.MenuItem14, Me.MenuItem16, Me.MenuItem15})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.chisquare_mnu, Me.quanti_mnu})
        Me.MenuItem1.Text = "Allele and Genotype frequencies"
        '
        'chisquare_mnu
        '
        Me.chisquare_mnu.Index = 0
        Me.chisquare_mnu.Text = "Chi-square calculation: 2 alleles"
        '
        'quanti_mnu
        '
        Me.quanti_mnu.Index = 1
        Me.quanti_mnu.Text = "Quantifying: 2 alleles"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.autosomal_mnu, Me.xlinked_mnu, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem2.Text = "Panmixia and Assortative Matings"
        '
        'autosomal_mnu
        '
        Me.autosomal_mnu.Index = 0
        Me.autosomal_mnu.Text = "Autosomal case"
        '
        'xlinked_mnu
        '
        Me.xlinked_mnu.Index = 1
        Me.xlinked_mnu.Text = "X-linked case"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "De Finetti's Parabola"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "-"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem8, Me.MenuItem9, Me.MenuItem10, Me.MenuItem11})
        Me.MenuItem5.Text = "Assortative matings"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "Positive with dominance"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "Positive without dominance"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 2
        Me.MenuItem9.Text = "Negative"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 3
        Me.MenuItem10.Text = "Forbidden"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 4
        Me.MenuItem11.Text = "Sterile"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_linkage, Me.mnu_magd})
        Me.MenuItem6.Text = "Linkage disequilibrium"
        '
        'mnu_linkage
        '
        Me.mnu_linkage.Index = 0
        Me.mnu_linkage.Text = "Linkage : 2 loci, 4 alleles"
        '
        'mnu_magd
        '
        Me.mnu_magd.Index = 1
        Me.mnu_magd.Text = "Magnitude of D"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 3
        Me.MenuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_drift, Me.mnu_driftsoft, Me.mnu_driftmut, Me.mnu_driftsoftmut, Me.MenuItem20, Me.mnu_markov})
        Me.MenuItem14.Text = "Drift"
        '
        'mnu_drift
        '
        Me.mnu_drift.Index = 0
        Me.mnu_drift.Text = "Drift"
        '
        'mnu_driftsoft
        '
        Me.mnu_driftsoft.Index = 1
        Me.mnu_driftsoft.Text = "Drift + ""Soft Selection"
        '
        'mnu_driftmut
        '
        Me.mnu_driftmut.Index = 2
        Me.mnu_driftmut.Text = "Drift + Mutation"
        '
        'mnu_driftsoftmut
        '
        Me.mnu_driftsoftmut.Index = 3
        Me.mnu_driftsoftmut.Text = "Drift + ""Soft Selection"" + Mutation"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 4
        Me.MenuItem20.Text = "-"
        '
        'mnu_markov
        '
        Me.mnu_markov.Index = 5
        Me.mnu_markov.Text = "Markov process"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 5
        Me.MenuItem15.Text = "Mutation"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 4
        Me.MenuItem16.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnu_selgnal, Me.mnu_seldep, Me.mnu_seldepcart})
        Me.MenuItem16.Text = "Selection"
        '
        'mnu_selgnal
        '
        Me.mnu_selgnal.Index = 0
        Me.mnu_selgnal.Text = "General Model"
        '
        'mnu_seldep
        '
        Me.mnu_seldep.Index = 1
        Me.mnu_seldep.Text = "Frequency dependent selection"
        '
        'mnu_seldepcart
        '
        Me.mnu_seldepcart.Index = 2
        Me.mnu_seldepcart.Text = "Frequency dependent selection - cartesian"
        '
        'mainF
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(892, 745)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "mainF"
        Me.Text = "PopGene.S^2"

    End Sub

#End Region

    Private Sub chisquare_mnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chisquare_mnu.Click
        Dim frm As New ChiSquare
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub quanti_mnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quanti_mnu.Click
        Dim frm As New Quanti
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub xlinked_mnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xlinked_mnu.Click
        Dim frm As New Xlinked
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub autosomal_mnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles autosomal_mnu.Click
        Dim frm As New Autosomal
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_magd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_magd.Click
        Dim frm As New MagD
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_drift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_drift.Click
        Dim frm As New Drift
        driftType = 1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_driftsoft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_driftsoft.Click
        Dim frm As New Drift
        driftType = 2
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_driftmut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_driftmut.Click
        Dim frm As New Drift
        driftType = 3
        driftMut = True
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_driftsoftmut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_driftsoftmut.Click
        Dim frm As New Drift
        driftMut = True
        driftType = 4
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_linkage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_linkage.Click
        Dim frm As New Linkage
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub mnu_selgnal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_selgnal.Click
        Dim frm As New Selection
        selType = 1
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnu_seldep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_seldep.Click
        Dim frm As New Selection
        selType = 2
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
