<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDestinationPDF = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtSourcePDF = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSelectFolder = New System.Windows.Forms.Button()
        Me.ListViewFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmsListViewFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuRemoveFromList = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.btnCropMerge = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.cmsListViewFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDestinationPDF)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.txtSourcePDF)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 122)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtDestinationPDF
        '
        Me.txtDestinationPDF.Location = New System.Drawing.Point(18, 87)
        Me.txtDestinationPDF.Name = "txtDestinationPDF"
        Me.txtDestinationPDF.ReadOnly = True
        Me.txtDestinationPDF.Size = New System.Drawing.Size(500, 20)
        Me.txtDestinationPDF.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Target PDF"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Source PDF (Drop a PDF or select one)"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(445, 29)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(73, 21)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Select PDF"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtSourcePDF
        '
        Me.txtSourcePDF.AllowDrop = True
        Me.txtSourcePDF.Location = New System.Drawing.Point(15, 29)
        Me.txtSourcePDF.Name = "txtSourcePDF"
        Me.txtSourcePDF.Size = New System.Drawing.Size(424, 20)
        Me.txtSourcePDF.TabIndex = 0
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(226, 139)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(92, 25)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Crop"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 469)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(547, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "Status: "
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(532, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "idle"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnSelectFolder)
        Me.GroupBox2.Controls.Add(Me.ListViewFiles)
        Me.GroupBox2.Controls.Add(Me.txtOutputFolder)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(523, 260)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Output Folder"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Porcessable Files (Drop a Folder of File)"
        '
        'btnSelectFolder
        '
        Me.btnSelectFolder.Location = New System.Drawing.Point(421, 32)
        Me.btnSelectFolder.Name = "btnSelectFolder"
        Me.btnSelectFolder.Size = New System.Drawing.Size(84, 21)
        Me.btnSelectFolder.TabIndex = 6
        Me.btnSelectFolder.Text = "Select Folder"
        Me.btnSelectFolder.UseVisualStyleBackColor = True
        '
        'ListViewFiles
        '
        Me.ListViewFiles.AllowDrop = True
        Me.ListViewFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewFiles.ContextMenuStrip = Me.cmsListViewFiles
        Me.ListViewFiles.FullRowSelect = True
        Me.ListViewFiles.GridLines = True
        Me.ListViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFiles.HideSelection = False
        Me.ListViewFiles.Location = New System.Drawing.Point(14, 74)
        Me.ListViewFiles.MultiSelect = False
        Me.ListViewFiles.Name = "ListViewFiles"
        Me.ListViewFiles.Size = New System.Drawing.Size(491, 168)
        Me.ListViewFiles.TabIndex = 0
        Me.ListViewFiles.UseCompatibleStateImageBehavior = False
        Me.ListViewFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 220
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Path"
        Me.ColumnHeader2.Width = 400
        '
        'cmsListViewFiles
        '
        Me.cmsListViewFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRemoveFromList})
        Me.cmsListViewFiles.Name = "cmsListViewFiles"
        Me.cmsListViewFiles.Size = New System.Drawing.Size(165, 26)
        '
        'mnuRemoveFromList
        '
        Me.mnuRemoveFromList.Name = "mnuRemoveFromList"
        Me.mnuRemoveFromList.Size = New System.Drawing.Size(164, 22)
        Me.mnuRemoveFromList.Text = "Remove from list"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.AllowDrop = True
        Me.txtOutputFolder.Location = New System.Drawing.Point(17, 32)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(398, 20)
        Me.txtOutputFolder.TabIndex = 5
        '
        'btnMerge
        '
        Me.btnMerge.Location = New System.Drawing.Point(176, 436)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(92, 25)
        Me.btnMerge.TabIndex = 4
        Me.btnMerge.Text = "Merge"
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'btnCropMerge
        '
        Me.btnCropMerge.Location = New System.Drawing.Point(274, 436)
        Me.btnCropMerge.Name = "btnCropMerge"
        Me.btnCropMerge.Size = New System.Drawing.Size(92, 25)
        Me.btnCropMerge.TabIndex = 5
        Me.btnCropMerge.Text = "Crop and Merge"
        Me.btnCropMerge.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 491)
        Me.Controls.Add(Me.btnCropMerge)
        Me.Controls.Add(Me.btnMerge)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDF Cropper"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.cmsListViewFiles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtSourcePDF As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents txtDestinationPDF As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ListViewFiles As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents btnMerge As Button
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents cmsListViewFiles As ContextMenuStrip
    Friend WithEvents mnuRemoveFromList As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSelectFolder As Button
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCropMerge As Button
End Class
