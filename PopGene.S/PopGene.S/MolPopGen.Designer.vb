<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MolPopGen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MolPopGen))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup6 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left)
        Me.rtx_seqs = New System.Windows.Forms.RichTextBox
        Me.cmd_open = New System.Windows.Forms.Button
        Me.cmd_align = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.CloseWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AlignSequencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NucleotidePolimorphismToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SiteNucleotideDsitributionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dlg_open = New System.Windows.Forms.OpenFileDialog
        Me.lst_freqs = New System.Windows.Forms.ListBox
        Me.fra_info = New System.Windows.Forms.GroupBox
        Me.lbl_div = New System.Windows.Forms.Label
        Me.lbl_nseqs = New System.Windows.Forms.Label
        Me.lbl_large = New System.Windows.Forms.Label
        Me.lbl_align = New System.Windows.Forms.Label
        Me.lbl_sites = New System.Windows.Forms.Label
        Me.lbl_k = New System.Windows.Forms.Label
        Me.lbl_gaps = New System.Windows.Forms.Label
        Me.lbl_muts = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.fra_box = New System.Windows.Forms.GroupBox
        Me.txt_size = New System.Windows.Forms.Label
        Me.txt_ng = New System.Windows.Forms.Label
        Me.txt_nt = New System.Windows.Forms.Label
        Me.txt_ngaps = New System.Windows.Forms.Label
        Me.txt_nc = New System.Windows.Forms.Label
        Me.txt_na = New System.Windows.Forms.Label
        Me.txt_gaps = New System.Windows.Forms.Label
        Me.txt_freqt = New System.Windows.Forms.Label
        Me.txt_freqg = New System.Windows.Forms.Label
        Me.txt_freqc = New System.Windows.Forms.Label
        Me.txt_freqa = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmd_poly = New System.Windows.Forms.Button
        Me.cmd_dist = New System.Windows.Forms.Button
        Me.lbl_poly = New System.Windows.Forms.Label
        Me.lst_poly = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.lst_div = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.lbl_diversity = New System.Windows.Forms.Label
        Me.runclustal = New System.Diagnostics.Process
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ex1 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ex2 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ex3 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ex4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.fra_info.SuspendLayout()
        Me.fra_box.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtx_seqs
        '
        Me.rtx_seqs.BackColor = System.Drawing.Color.White
        Me.rtx_seqs.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtx_seqs.Location = New System.Drawing.Point(265, 279)
        Me.rtx_seqs.Name = "rtx_seqs"
        Me.rtx_seqs.ReadOnly = True
        Me.rtx_seqs.Size = New System.Drawing.Size(419, 273)
        Me.rtx_seqs.TabIndex = 0
        Me.rtx_seqs.Text = "Your sequences will be displayed here"
        Me.rtx_seqs.WordWrap = False
        '
        'cmd_open
        '
        Me.cmd_open.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_open.Image = CType(resources.GetObject("cmd_open.Image"), System.Drawing.Image)
        Me.cmd_open.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_open.Location = New System.Drawing.Point(12, 42)
        Me.cmd_open.Name = "cmd_open"
        Me.cmd_open.Size = New System.Drawing.Size(80, 69)
        Me.cmd_open.TabIndex = 5
        Me.cmd_open.Text = "Open File"
        Me.cmd_open.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmd_align
        '
        Me.cmd_align.Enabled = False
        Me.cmd_align.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_align.Image = CType(resources.GetObject("cmd_align.Image"), System.Drawing.Image)
        Me.cmd_align.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_align.Location = New System.Drawing.Point(156, 42)
        Me.cmd_align.Name = "cmd_align"
        Me.cmd_align.Size = New System.Drawing.Size(78, 69)
        Me.cmd_align.TabIndex = 6
        Me.cmd_align.Text = "Align Sequences"
        Me.cmd_align.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ActionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1080, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripMenuItem1, Me.CloseWindowToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'CloseWindowToolStripMenuItem
        '
        Me.CloseWindowToolStripMenuItem.Name = "CloseWindowToolStripMenuItem"
        Me.CloseWindowToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CloseWindowToolStripMenuItem.Text = "&Close Window"
        '
        'ActionsToolStripMenuItem
        '
        Me.ActionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlignSequencesToolStripMenuItem, Me.NucleotidePolimorphismToolStripMenuItem, Me.SiteNucleotideDsitributionToolStripMenuItem})
        Me.ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem"
        Me.ActionsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ActionsToolStripMenuItem.Text = "Actions"
        '
        'AlignSequencesToolStripMenuItem
        '
        Me.AlignSequencesToolStripMenuItem.Name = "AlignSequencesToolStripMenuItem"
        Me.AlignSequencesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.AlignSequencesToolStripMenuItem.Text = "Align sequences"
        '
        'NucleotidePolimorphismToolStripMenuItem
        '
        Me.NucleotidePolimorphismToolStripMenuItem.Name = "NucleotidePolimorphismToolStripMenuItem"
        Me.NucleotidePolimorphismToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.NucleotidePolimorphismToolStripMenuItem.Text = "Nucleotide polimorphism"
        '
        'SiteNucleotideDsitributionToolStripMenuItem
        '
        Me.SiteNucleotideDsitributionToolStripMenuItem.Name = "SiteNucleotideDsitributionToolStripMenuItem"
        Me.SiteNucleotideDsitributionToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SiteNucleotideDsitributionToolStripMenuItem.Text = "Site nucleotide dsitribution"
        '
        'lst_freqs
        '
        Me.lst_freqs.ColumnWidth = 20
        Me.lst_freqs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_freqs.FormattingEnabled = True
        Me.lst_freqs.HorizontalScrollbar = True
        Me.lst_freqs.ItemHeight = 14
        Me.lst_freqs.Location = New System.Drawing.Point(265, 33)
        Me.lst_freqs.Name = "lst_freqs"
        Me.lst_freqs.Size = New System.Drawing.Size(189, 228)
        Me.lst_freqs.TabIndex = 8
        '
        'fra_info
        '
        Me.fra_info.Controls.Add(Me.lbl_div)
        Me.fra_info.Controls.Add(Me.lbl_nseqs)
        Me.fra_info.Controls.Add(Me.lbl_large)
        Me.fra_info.Controls.Add(Me.lbl_align)
        Me.fra_info.Controls.Add(Me.lbl_sites)
        Me.fra_info.Controls.Add(Me.lbl_k)
        Me.fra_info.Controls.Add(Me.lbl_gaps)
        Me.fra_info.Controls.Add(Me.lbl_muts)
        Me.fra_info.Controls.Add(Me.Label19)
        Me.fra_info.Controls.Add(Me.Label18)
        Me.fra_info.Controls.Add(Me.Label17)
        Me.fra_info.Controls.Add(Me.Label16)
        Me.fra_info.Controls.Add(Me.Label15)
        Me.fra_info.Controls.Add(Me.Label2)
        Me.fra_info.Controls.Add(Me.Label1)
        Me.fra_info.Controls.Add(Me.Label6)
        Me.fra_info.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_info.Location = New System.Drawing.Point(12, 117)
        Me.fra_info.Name = "fra_info"
        Me.fra_info.Size = New System.Drawing.Size(222, 235)
        Me.fra_info.TabIndex = 9
        Me.fra_info.TabStop = False
        Me.fra_info.Visible = False
        '
        'lbl_div
        '
        Me.lbl_div.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_div.Location = New System.Drawing.Point(170, 210)
        Me.lbl_div.Name = "lbl_div"
        Me.lbl_div.Size = New System.Drawing.Size(45, 16)
        Me.lbl_div.TabIndex = 55
        Me.lbl_div.Text = "00000"
        '
        'lbl_nseqs
        '
        Me.lbl_nseqs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nseqs.Location = New System.Drawing.Point(170, 18)
        Me.lbl_nseqs.Name = "lbl_nseqs"
        Me.lbl_nseqs.Size = New System.Drawing.Size(45, 16)
        Me.lbl_nseqs.TabIndex = 54
        Me.lbl_nseqs.Text = "00000"
        '
        'lbl_large
        '
        Me.lbl_large.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_large.Location = New System.Drawing.Point(170, 38)
        Me.lbl_large.Name = "lbl_large"
        Me.lbl_large.Size = New System.Drawing.Size(45, 16)
        Me.lbl_large.TabIndex = 53
        Me.lbl_large.Text = "00000"
        '
        'lbl_align
        '
        Me.lbl_align.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_align.Location = New System.Drawing.Point(170, 58)
        Me.lbl_align.Name = "lbl_align"
        Me.lbl_align.Size = New System.Drawing.Size(45, 16)
        Me.lbl_align.TabIndex = 52
        Me.lbl_align.Text = "00000"
        '
        'lbl_sites
        '
        Me.lbl_sites.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sites.Location = New System.Drawing.Point(170, 77)
        Me.lbl_sites.Name = "lbl_sites"
        Me.lbl_sites.Size = New System.Drawing.Size(45, 16)
        Me.lbl_sites.TabIndex = 51
        Me.lbl_sites.Text = "00000"
        '
        'lbl_k
        '
        Me.lbl_k.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_k.Location = New System.Drawing.Point(170, 117)
        Me.lbl_k.Name = "lbl_k"
        Me.lbl_k.Size = New System.Drawing.Size(45, 16)
        Me.lbl_k.TabIndex = 50
        Me.lbl_k.Text = "00000"
        '
        'lbl_gaps
        '
        Me.lbl_gaps.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gaps.Location = New System.Drawing.Point(170, 150)
        Me.lbl_gaps.Name = "lbl_gaps"
        Me.lbl_gaps.Size = New System.Drawing.Size(45, 16)
        Me.lbl_gaps.TabIndex = 49
        Me.lbl_gaps.Text = "00000"
        '
        'lbl_muts
        '
        Me.lbl_muts.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_muts.Location = New System.Drawing.Point(170, 174)
        Me.lbl_muts.Name = "lbl_muts"
        Me.lbl_muts.Size = New System.Drawing.Size(45, 16)
        Me.lbl_muts.TabIndex = 48
        Me.lbl_muts.Text = "00000"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(15, 212)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(129, 14)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Nucleotide diversity"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 152)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 14)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Number of gaps"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 174)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 30)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Number of mutations (gaps+k)"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(150, 28)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Number of segregating sites (k)"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(15, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(112, 40)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Number of sites (no gaps)"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 14)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Sequences aligned?"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Largest sequence"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Number of sequences"
        '
        'fra_box
        '
        Me.fra_box.Controls.Add(Me.txt_size)
        Me.fra_box.Controls.Add(Me.txt_ng)
        Me.fra_box.Controls.Add(Me.txt_nt)
        Me.fra_box.Controls.Add(Me.txt_ngaps)
        Me.fra_box.Controls.Add(Me.txt_nc)
        Me.fra_box.Controls.Add(Me.txt_na)
        Me.fra_box.Controls.Add(Me.txt_gaps)
        Me.fra_box.Controls.Add(Me.txt_freqt)
        Me.fra_box.Controls.Add(Me.txt_freqg)
        Me.fra_box.Controls.Add(Me.txt_freqc)
        Me.fra_box.Controls.Add(Me.txt_freqa)
        Me.fra_box.Controls.Add(Me.Label14)
        Me.fra_box.Controls.Add(Me.Label13)
        Me.fra_box.Controls.Add(Me.Label12)
        Me.fra_box.Controls.Add(Me.Label11)
        Me.fra_box.Controls.Add(Me.Label10)
        Me.fra_box.Controls.Add(Me.Label9)
        Me.fra_box.Controls.Add(Me.Label8)
        Me.fra_box.Controls.Add(Me.Label7)
        Me.fra_box.Controls.Add(Me.Label3)
        Me.fra_box.Controls.Add(Me.Label4)
        Me.fra_box.Controls.Add(Me.Label5)
        Me.fra_box.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fra_box.Location = New System.Drawing.Point(460, 27)
        Me.fra_box.Name = "fra_box"
        Me.fra_box.Size = New System.Drawing.Size(224, 235)
        Me.fra_box.TabIndex = 10
        Me.fra_box.TabStop = False
        Me.fra_box.Visible = False
        '
        'txt_size
        '
        Me.txt_size.AutoSize = True
        Me.txt_size.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_size.Location = New System.Drawing.Point(100, 18)
        Me.txt_size.Name = "txt_size"
        Me.txt_size.Size = New System.Drawing.Size(37, 14)
        Me.txt_size.TabIndex = 52
        Me.txt_size.Text = "00000"
        '
        'txt_ng
        '
        Me.txt_ng.AutoSize = True
        Me.txt_ng.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ng.Location = New System.Drawing.Point(182, 101)
        Me.txt_ng.Name = "txt_ng"
        Me.txt_ng.Size = New System.Drawing.Size(37, 14)
        Me.txt_ng.TabIndex = 51
        Me.txt_ng.Text = "00000"
        '
        'txt_nt
        '
        Me.txt_nt.AutoSize = True
        Me.txt_nt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nt.Location = New System.Drawing.Point(182, 127)
        Me.txt_nt.Name = "txt_nt"
        Me.txt_nt.Size = New System.Drawing.Size(37, 14)
        Me.txt_nt.TabIndex = 50
        Me.txt_nt.Text = "00000"
        '
        'txt_ngaps
        '
        Me.txt_ngaps.AutoSize = True
        Me.txt_ngaps.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ngaps.Location = New System.Drawing.Point(182, 158)
        Me.txt_ngaps.Name = "txt_ngaps"
        Me.txt_ngaps.Size = New System.Drawing.Size(37, 14)
        Me.txt_ngaps.TabIndex = 49
        Me.txt_ngaps.Text = "00000"
        '
        'txt_nc
        '
        Me.txt_nc.AutoSize = True
        Me.txt_nc.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nc.Location = New System.Drawing.Point(182, 74)
        Me.txt_nc.Name = "txt_nc"
        Me.txt_nc.Size = New System.Drawing.Size(37, 14)
        Me.txt_nc.TabIndex = 48
        Me.txt_nc.Text = "00000"
        '
        'txt_na
        '
        Me.txt_na.AutoSize = True
        Me.txt_na.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_na.Location = New System.Drawing.Point(182, 49)
        Me.txt_na.Name = "txt_na"
        Me.txt_na.Size = New System.Drawing.Size(37, 14)
        Me.txt_na.TabIndex = 47
        Me.txt_na.Text = "00000"
        '
        'txt_gaps
        '
        Me.txt_gaps.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gaps.Location = New System.Drawing.Point(100, 158)
        Me.txt_gaps.Name = "txt_gaps"
        Me.txt_gaps.Size = New System.Drawing.Size(45, 16)
        Me.txt_gaps.TabIndex = 46
        Me.txt_gaps.Text = "00000"
        '
        'txt_freqt
        '
        Me.txt_freqt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freqt.Location = New System.Drawing.Point(100, 127)
        Me.txt_freqt.Name = "txt_freqt"
        Me.txt_freqt.Size = New System.Drawing.Size(45, 16)
        Me.txt_freqt.TabIndex = 45
        Me.txt_freqt.Text = "00000"
        '
        'txt_freqg
        '
        Me.txt_freqg.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freqg.Location = New System.Drawing.Point(100, 101)
        Me.txt_freqg.Name = "txt_freqg"
        Me.txt_freqg.Size = New System.Drawing.Size(45, 16)
        Me.txt_freqg.TabIndex = 44
        Me.txt_freqg.Text = "00000"
        '
        'txt_freqc
        '
        Me.txt_freqc.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freqc.Location = New System.Drawing.Point(100, 74)
        Me.txt_freqc.Name = "txt_freqc"
        Me.txt_freqc.Size = New System.Drawing.Size(45, 16)
        Me.txt_freqc.TabIndex = 43
        Me.txt_freqc.Text = "00000"
        '
        'txt_freqa
        '
        Me.txt_freqa.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_freqa.Location = New System.Drawing.Point(100, 49)
        Me.txt_freqa.Name = "txt_freqa"
        Me.txt_freqa.Size = New System.Drawing.Size(45, 16)
        Me.txt_freqa.TabIndex = 42
        Me.txt_freqa.Text = "00000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(151, 158)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 14)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "N = "
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 158)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 16)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Gaps"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 22)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Sequence size"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(151, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 14)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "N = "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(151, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 14)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "N = "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(151, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 14)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "N = "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(151, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 14)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "N = "
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Frequency of T"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Frequency of G"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Frequency of C"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Frequency of A"
        '
        'cmd_poly
        '
        Me.cmd_poly.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_poly.Image = CType(resources.GetObject("cmd_poly.Image"), System.Drawing.Image)
        Me.cmd_poly.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_poly.Location = New System.Drawing.Point(12, 367)
        Me.cmd_poly.Name = "cmd_poly"
        Me.cmd_poly.Size = New System.Drawing.Size(100, 86)
        Me.cmd_poly.TabIndex = 11
        Me.cmd_poly.Text = "Pairwise Nucleotide Diversity"
        Me.cmd_poly.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmd_dist
        '
        Me.cmd_dist.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_dist.Image = CType(resources.GetObject("cmd_dist.Image"), System.Drawing.Image)
        Me.cmd_dist.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_dist.Location = New System.Drawing.Point(134, 367)
        Me.cmd_dist.Name = "cmd_dist"
        Me.cmd_dist.Size = New System.Drawing.Size(100, 86)
        Me.cmd_dist.TabIndex = 12
        Me.cmd_dist.Text = "Nucleotide site distribution"
        Me.cmd_dist.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lbl_poly
        '
        Me.lbl_poly.AutoSize = True
        Me.lbl_poly.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_poly.Location = New System.Drawing.Point(696, 29)
        Me.lbl_poly.Name = "lbl_poly"
        Me.lbl_poly.Size = New System.Drawing.Size(147, 14)
        Me.lbl_poly.TabIndex = 40
        Me.lbl_poly.Text = "Nucleotide polymorphism"
        Me.lbl_poly.Visible = False
        '
        'lst_poly
        '
        Me.lst_poly.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lst_poly.GridLines = True
        ListViewGroup1.Header = "ListViewGroup"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "ListViewGroup"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "ListViewGroup"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.lst_poly.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lst_poly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lst_poly.Location = New System.Drawing.Point(699, 45)
        Me.lst_poly.MultiSelect = False
        Me.lst_poly.Name = "lst_poly"
        Me.lst_poly.ShowGroups = False
        Me.lst_poly.Size = New System.Drawing.Size(369, 217)
        Me.lst_poly.TabIndex = 41
        Me.lst_poly.UseCompatibleStateImageBehavior = False
        Me.lst_poly.View = System.Windows.Forms.View.Details
        Me.lst_poly.VirtualListSize = 3
        Me.lst_poly.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Species 1"
        Me.ColumnHeader1.Width = 140
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Species 2"
        Me.ColumnHeader2.Width = 140
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Pi"
        Me.ColumnHeader3.Width = 85
        '
        'lst_div
        '
        Me.lst_div.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lst_div.GridLines = True
        ListViewGroup4.Header = "ListViewGroup"
        ListViewGroup4.Name = "ListViewGroup1"
        ListViewGroup5.Header = "ListViewGroup"
        ListViewGroup5.Name = "ListViewGroup2"
        ListViewGroup6.Header = "ListViewGroup"
        ListViewGroup6.Name = "ListViewGroup3"
        Me.lst_div.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup4, ListViewGroup5, ListViewGroup6})
        Me.lst_div.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lst_div.Location = New System.Drawing.Point(699, 296)
        Me.lst_div.MultiSelect = False
        Me.lst_div.Name = "lst_div"
        Me.lst_div.ShowGroups = False
        Me.lst_div.Size = New System.Drawing.Size(369, 256)
        Me.lst_div.TabIndex = 42
        Me.lst_div.UseCompatibleStateImageBehavior = False
        Me.lst_div.View = System.Windows.Forms.View.Details
        Me.lst_div.VirtualListSize = 3
        Me.lst_div.Visible = False
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Site"
        Me.ColumnHeader4.Width = 40
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "A"
        Me.ColumnHeader5.Width = 65
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "C"
        Me.ColumnHeader6.Width = 65
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "G"
        Me.ColumnHeader7.Width = 65
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "T"
        Me.ColumnHeader8.Width = 65
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Gaps"
        Me.ColumnHeader9.Width = 65
        '
        'lbl_diversity
        '
        Me.lbl_diversity.AutoSize = True
        Me.lbl_diversity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_diversity.Location = New System.Drawing.Point(696, 279)
        Me.lbl_diversity.Name = "lbl_diversity"
        Me.lbl_diversity.Size = New System.Drawing.Size(156, 14)
        Me.lbl_diversity.TabIndex = 43
        Me.lbl_diversity.Text = "Site nucleotide distribution"
        Me.lbl_diversity.Visible = False
        '
        'runclustal
        '
        Me.runclustal.StartInfo.Domain = ""
        Me.runclustal.StartInfo.LoadUserProfile = False
        Me.runclustal.StartInfo.Password = Nothing
        Me.runclustal.StartInfo.StandardErrorEncoding = Nothing
        Me.runclustal.StartInfo.StandardOutputEncoding = Nothing
        Me.runclustal.StartInfo.UserName = ""
        Me.runclustal.SynchronizingObject = Me
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1080, 24)
        Me.MenuStrip2.TabIndex = 44
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_ex1, Me.mnu_ex2, Me.mnu_ex3, Me.mnu_ex4, Me.ToolStripMenuItem2, Me.HelpToolStripMenuItem})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'mnu_ex1
        '
        Me.mnu_ex1.Name = "mnu_ex1"
        Me.mnu_ex1.Size = New System.Drawing.Size(152, 22)
        Me.mnu_ex1.Text = "Example 1"
        '
        'mnu_ex2
        '
        Me.mnu_ex2.Name = "mnu_ex2"
        Me.mnu_ex2.Size = New System.Drawing.Size(152, 22)
        Me.mnu_ex2.Text = "Example 2"
        '
        'mnu_ex3
        '
        Me.mnu_ex3.Name = "mnu_ex3"
        Me.mnu_ex3.Size = New System.Drawing.Size(152, 22)
        Me.mnu_ex3.Text = "Example 3"
        '
        'mnu_ex4
        '
        Me.mnu_ex4.Name = "mnu_ex4"
        Me.mnu_ex4.Size = New System.Drawing.Size(152, 22)
        Me.mnu_ex4.Text = "Example 4"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'MolPopGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1080, 564)
        Me.Controls.Add(Me.lbl_diversity)
        Me.Controls.Add(Me.lst_div)
        Me.Controls.Add(Me.lst_poly)
        Me.Controls.Add(Me.lbl_poly)
        Me.Controls.Add(Me.cmd_dist)
        Me.Controls.Add(Me.cmd_poly)
        Me.Controls.Add(Me.fra_box)
        Me.Controls.Add(Me.fra_info)
        Me.Controls.Add(Me.lst_freqs)
        Me.Controls.Add(Me.cmd_align)
        Me.Controls.Add(Me.cmd_open)
        Me.Controls.Add(Me.rtx_seqs)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MolPopGen"
        Me.Text = "MolPopGen"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.fra_info.ResumeLayout(False)
        Me.fra_box.ResumeLayout(False)
        Me.fra_box.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtx_seqs As System.Windows.Forms.RichTextBox
    Friend WithEvents cmd_open As System.Windows.Forms.Button
    Friend WithEvents cmd_align As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlg_open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ActionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlignSequencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NucleotidePolimorphismToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SiteNucleotideDsitributionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lst_freqs As System.Windows.Forms.ListBox
    Friend WithEvents fra_info As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fra_box As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_ng As System.Windows.Forms.Label
    Friend WithEvents txt_nt As System.Windows.Forms.Label
    Friend WithEvents txt_ngaps As System.Windows.Forms.Label
    Friend WithEvents txt_nc As System.Windows.Forms.Label
    Friend WithEvents txt_na As System.Windows.Forms.Label
    Friend WithEvents txt_gaps As System.Windows.Forms.Label
    Friend WithEvents txt_freqt As System.Windows.Forms.Label
    Friend WithEvents txt_freqg As System.Windows.Forms.Label
    Friend WithEvents txt_freqc As System.Windows.Forms.Label
    Friend WithEvents txt_freqa As System.Windows.Forms.Label
    Friend WithEvents txt_size As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lbl_div As System.Windows.Forms.Label
    Friend WithEvents lbl_nseqs As System.Windows.Forms.Label
    Friend WithEvents lbl_large As System.Windows.Forms.Label
    Friend WithEvents lbl_align As System.Windows.Forms.Label
    Friend WithEvents lbl_sites As System.Windows.Forms.Label
    Friend WithEvents lbl_k As System.Windows.Forms.Label
    Friend WithEvents lbl_gaps As System.Windows.Forms.Label
    Friend WithEvents lbl_muts As System.Windows.Forms.Label
    Friend WithEvents cmd_poly As System.Windows.Forms.Button
    Friend WithEvents cmd_dist As System.Windows.Forms.Button
    Friend WithEvents lbl_poly As System.Windows.Forms.Label
    Friend WithEvents lst_poly As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lst_div As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbl_diversity As System.Windows.Forms.Label
    Friend WithEvents runclustal As System.Diagnostics.Process
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ex1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ex2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ex3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ex4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
