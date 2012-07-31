<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsForm))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmbFormat = New System.Windows.Forms.ComboBox()
    Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.RadioButton9 = New System.Windows.Forms.RadioButton()
    Me.radIntensityValues32 = New System.Windows.Forms.RadioButton()
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.RadioButton7 = New System.Windows.Forms.RadioButton()
    Me.radMzValues32 = New System.Windows.Forms.RadioButton()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.radBinary32 = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.CheckBox4 = New System.Windows.Forms.CheckBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.lblOutputPath = New System.Windows.Forms.Label()
    Me.btnOutputBrowse = New System.Windows.Forms.LinkLabel()
    Me.btnOutputClear = New System.Windows.Forms.LinkLabel()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.lblContactFile = New System.Windows.Forms.Label()
    Me.btnContactBrowse = New System.Windows.Forms.LinkLabel()
    Me.btnContactClear = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.btnDelete = New System.Windows.Forms.Button()
    Me.btnDown = New System.Windows.Forms.Button()
    Me.btnUp = New System.Windows.Forms.Button()
    Me.btnAdd = New System.Windows.Forms.Button()
    Me.lstFilters = New System.Windows.Forms.ListBox()
    Me.FiltersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
    Me.CheckBox5 = New System.Windows.Forms.CheckBox()
    Me.btnGo = New System.Windows.Forms.Button()
    Me.grpJobQueue = New System.Windows.Forms.GroupBox()
    Me.lblJobQueue = New System.Windows.Forms.Label()
    CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.TableLayoutPanel1.SuspendLayout()
    Me.Panel3.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.FiltersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.MenuStrip1.SuspendLayout()
    Me.grpJobQueue.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 36)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(74, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Output format:"
    '
    'cmbFormat
    '
    Me.cmbFormat.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BindingSource1, "OutputFormat", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.cmbFormat.DisplayMember = "Value"
    Me.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbFormat.FormattingEnabled = True
    Me.cmbFormat.Location = New System.Drawing.Point(89, 33)
    Me.cmbFormat.Name = "cmbFormat"
    Me.cmbFormat.Size = New System.Drawing.Size(101, 21)
    Me.cmbFormat.TabIndex = 1
    Me.cmbFormat.ValueMember = "Key"
    '
    'BindingSource1
    '
    Me.BindingSource1.AllowNew = False
    Me.BindingSource1.DataSource = GetType(ms2mz.ConfigurationSet)
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
    Me.GroupBox1.Location = New System.Drawing.Point(13, 57)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(223, 89)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Encoding precision"
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 1)
    Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
    Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 13)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 3
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(210, 70)
    Me.TableLayoutPanel1.TabIndex = 3
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.RadioButton9)
    Me.Panel3.Controls.Add(Me.radIntensityValues32)
    Me.Panel3.Location = New System.Drawing.Point(92, 51)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(114, 18)
    Me.Panel3.TabIndex = 3
    '
    'RadioButton9
    '
    Me.RadioButton9.AutoSize = True
    Me.RadioButton9.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "IntensityValuesPrecision64bit", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.RadioButton9.Location = New System.Drawing.Point(64, 0)
    Me.RadioButton9.Name = "RadioButton9"
    Me.RadioButton9.Size = New System.Drawing.Size(51, 17)
    Me.RadioButton9.TabIndex = 1
    Me.RadioButton9.Text = "64 bit"
    Me.RadioButton9.UseVisualStyleBackColor = True
    '
    'radIntensityValues32
    '
    Me.radIntensityValues32.AutoSize = True
    Me.radIntensityValues32.Checked = True
    Me.radIntensityValues32.Location = New System.Drawing.Point(0, 0)
    Me.radIntensityValues32.Name = "radIntensityValues32"
    Me.radIntensityValues32.Size = New System.Drawing.Size(51, 17)
    Me.radIntensityValues32.TabIndex = 0
    Me.radIntensityValues32.TabStop = True
    Me.radIntensityValues32.Text = "32 bit"
    Me.radIntensityValues32.UseVisualStyleBackColor = True
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.RadioButton7)
    Me.Panel2.Controls.Add(Me.radMzValues32)
    Me.Panel2.Location = New System.Drawing.Point(92, 27)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(114, 18)
    Me.Panel2.TabIndex = 3
    '
    'RadioButton7
    '
    Me.RadioButton7.AutoSize = True
    Me.RadioButton7.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "MzValuesPrecision64bit", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.RadioButton7.Location = New System.Drawing.Point(64, 0)
    Me.RadioButton7.Name = "RadioButton7"
    Me.RadioButton7.Size = New System.Drawing.Size(51, 17)
    Me.RadioButton7.TabIndex = 1
    Me.RadioButton7.Text = "64 bit"
    Me.RadioButton7.UseVisualStyleBackColor = True
    '
    'radMzValues32
    '
    Me.radMzValues32.AutoSize = True
    Me.radMzValues32.Checked = True
    Me.radMzValues32.Location = New System.Drawing.Point(0, 0)
    Me.radMzValues32.Name = "radMzValues32"
    Me.radMzValues32.Size = New System.Drawing.Size(51, 17)
    Me.radMzValues32.TabIndex = 0
    Me.radMzValues32.TabStop = True
    Me.radMzValues32.Text = "32 bit"
    Me.radMzValues32.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.RadioButton2)
    Me.Panel1.Controls.Add(Me.radBinary32)
    Me.Panel1.Location = New System.Drawing.Point(92, 3)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(114, 18)
    Me.Panel1.TabIndex = 2
    '
    'RadioButton2
    '
    Me.RadioButton2.AutoSize = True
    Me.RadioButton2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "BinaryPrecision64bit", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.RadioButton2.Location = New System.Drawing.Point(64, 0)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(51, 17)
    Me.RadioButton2.TabIndex = 1
    Me.RadioButton2.Text = "64 bit"
    Me.RadioButton2.UseVisualStyleBackColor = True
    '
    'radBinary32
    '
    Me.radBinary32.AutoSize = True
    Me.radBinary32.Checked = True
    Me.radBinary32.Location = New System.Drawing.Point(0, 0)
    Me.radBinary32.Name = "radBinary32"
    Me.radBinary32.Size = New System.Drawing.Size(51, 17)
    Me.radBinary32.TabIndex = 0
    Me.radBinary32.TabStop = True
    Me.radBinary32.Text = "32 bit"
    Me.radBinary32.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(47, 5)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(39, 13)
    Me.Label2.TabIndex = 0
    Me.Label2.Text = "Binary:"
    '
    'Label4
    '
    Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(3, 53)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(83, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Intensity values:"
    '
    'Label3
    '
    Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(23, 29)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(63, 13)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "M/z values:"
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "NoIndex", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.CheckBox1.Location = New System.Drawing.Point(13, 151)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(111, 17)
    Me.CheckBox1.TabIndex = 3
    Me.CheckBox1.Text = "Do not write index"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "Zlib", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.CheckBox2.Location = New System.Drawing.Point(13, 174)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(195, 17)
    Me.CheckBox2.TabIndex = 4
    Me.CheckBox2.Text = "Use zlib compression for binary data"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "Gzip", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.CheckBox3.Location = New System.Drawing.Point(13, 197)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(125, 17)
    Me.CheckBox3.TabIndex = 5
    Me.CheckBox3.Text = "Gzip entire output file"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'CheckBox4
    '
    Me.CheckBox4.AutoSize = True
    Me.CheckBox4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BindingSource1, "Merge", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.CheckBox4.Location = New System.Drawing.Point(13, 220)
    Me.CheckBox4.Name = "CheckBox4"
    Me.CheckBox4.Size = New System.Drawing.Size(224, 17)
    Me.CheckBox4.TabIndex = 6
    Me.CheckBox4.Text = "Merge multiple input files into single output"
    Me.CheckBox4.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(9, 270)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(85, 13)
    Me.Label5.TabIndex = 7
    Me.Label5.Text = "Output directory:"
    '
    'lblOutputPath
    '
    Me.lblOutputPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblOutputPath.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.BindingSource1, "OutputPath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.lblOutputPath.Location = New System.Drawing.Point(12, 286)
    Me.lblOutputPath.Name = "lblOutputPath"
    Me.lblOutputPath.Size = New System.Drawing.Size(224, 17)
    Me.lblOutputPath.TabIndex = 10
    '
    'btnOutputBrowse
    '
    Me.btnOutputBrowse.AutoSize = True
    Me.btnOutputBrowse.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.btnOutputBrowse.Location = New System.Drawing.Point(108, 270)
    Me.btnOutputBrowse.Name = "btnOutputBrowse"
    Me.btnOutputBrowse.Size = New System.Drawing.Size(42, 13)
    Me.btnOutputBrowse.TabIndex = 8
    Me.btnOutputBrowse.TabStop = True
    Me.btnOutputBrowse.Text = "Browse"
    Me.btnOutputBrowse.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    '
    'btnOutputClear
    '
    Me.btnOutputClear.AutoSize = True
    Me.btnOutputClear.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.btnOutputClear.Location = New System.Drawing.Point(172, 270)
    Me.btnOutputClear.Name = "btnOutputClear"
    Me.btnOutputClear.Size = New System.Drawing.Size(31, 13)
    Me.btnOutputClear.TabIndex = 9
    Me.btnOutputClear.TabStop = True
    Me.btnOutputClear.Text = "Clear"
    Me.btnOutputClear.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(9, 313)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(83, 13)
    Me.Label7.TabIndex = 11
    Me.Label7.Text = "Contact info file:"
    '
    'lblContactFile
    '
    Me.lblContactFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblContactFile.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.BindingSource1, "ContactFile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.lblContactFile.Location = New System.Drawing.Point(12, 329)
    Me.lblContactFile.Name = "lblContactFile"
    Me.lblContactFile.Size = New System.Drawing.Size(224, 17)
    Me.lblContactFile.TabIndex = 14
    '
    'btnContactBrowse
    '
    Me.btnContactBrowse.AutoSize = True
    Me.btnContactBrowse.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.btnContactBrowse.Location = New System.Drawing.Point(108, 313)
    Me.btnContactBrowse.Name = "btnContactBrowse"
    Me.btnContactBrowse.Size = New System.Drawing.Size(42, 13)
    Me.btnContactBrowse.TabIndex = 12
    Me.btnContactBrowse.TabStop = True
    Me.btnContactBrowse.Text = "Browse"
    Me.btnContactBrowse.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    '
    'btnContactClear
    '
    Me.btnContactClear.AutoSize = True
    Me.btnContactClear.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.btnContactClear.Location = New System.Drawing.Point(172, 313)
    Me.btnContactClear.Name = "btnContactClear"
    Me.btnContactClear.Size = New System.Drawing.Size(31, 13)
    Me.btnContactClear.TabIndex = 13
    Me.btnContactClear.TabStop = True
    Me.btnContactClear.Text = "Clear"
    Me.btnContactClear.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.btnDelete)
    Me.GroupBox2.Controls.Add(Me.btnDown)
    Me.GroupBox2.Controls.Add(Me.btnUp)
    Me.GroupBox2.Controls.Add(Me.btnAdd)
    Me.GroupBox2.Controls.Add(Me.lstFilters)
    Me.GroupBox2.Location = New System.Drawing.Point(257, 27)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(233, 319)
    Me.GroupBox2.TabIndex = 15
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Filters"
    '
    'btnDelete
    '
    Me.btnDelete.Image = Global.ms2mz.My.Resources.Resources.Delete
    Me.btnDelete.Location = New System.Drawing.Point(200, 120)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.Size = New System.Drawing.Size(28, 28)
    Me.btnDelete.TabIndex = 1
    Me.ToolTip1.SetToolTip(Me.btnDelete, "Delete filter")
    Me.btnDelete.UseVisualStyleBackColor = True
    '
    'btnDown
    '
    Me.btnDown.Image = Global.ms2mz.My.Resources.Resources.Down
    Me.btnDown.Location = New System.Drawing.Point(200, 86)
    Me.btnDown.Name = "btnDown"
    Me.btnDown.Size = New System.Drawing.Size(28, 28)
    Me.btnDown.TabIndex = 1
    Me.ToolTip1.SetToolTip(Me.btnDown, "Move down")
    Me.btnDown.UseVisualStyleBackColor = True
    '
    'btnUp
    '
    Me.btnUp.Image = Global.ms2mz.My.Resources.Resources.Up
    Me.btnUp.Location = New System.Drawing.Point(200, 52)
    Me.btnUp.Name = "btnUp"
    Me.btnUp.Size = New System.Drawing.Size(28, 28)
    Me.btnUp.TabIndex = 1
    Me.ToolTip1.SetToolTip(Me.btnUp, "Move up")
    Me.btnUp.UseVisualStyleBackColor = True
    '
    'btnAdd
    '
    Me.btnAdd.Image = Global.ms2mz.My.Resources.Resources.NewFilter
    Me.btnAdd.Location = New System.Drawing.Point(200, 18)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.Size = New System.Drawing.Size(28, 28)
    Me.btnAdd.TabIndex = 1
    Me.ToolTip1.SetToolTip(Me.btnAdd, "Add filter")
    Me.btnAdd.UseVisualStyleBackColor = True
    '
    'lstFilters
    '
    Me.lstFilters.DataSource = Me.FiltersBindingSource
    Me.lstFilters.FormattingEnabled = True
    Me.lstFilters.Location = New System.Drawing.Point(7, 18)
    Me.lstFilters.Name = "lstFilters"
    Me.lstFilters.Size = New System.Drawing.Size(187, 290)
    Me.lstFilters.TabIndex = 0
    '
    'FiltersBindingSource
    '
    Me.FiltersBindingSource.DataMember = "Filters"
    Me.FiltersBindingSource.DataSource = Me.BindingSource1
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.mnuSave, Me.mnuSaveAs, Me.mnuExit})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(505, 24)
    Me.MenuStrip1.TabIndex = 16
    Me.MenuStrip1.Text = "MenuStrip1"
    '
    'mnuNew
    '
    Me.mnuNew.Name = "mnuNew"
    Me.mnuNew.Size = New System.Drawing.Size(40, 20)
    Me.mnuNew.Text = "&New"
    '
    'mnuOpen
    '
    Me.mnuOpen.Name = "mnuOpen"
    Me.mnuOpen.Size = New System.Drawing.Size(57, 20)
    Me.mnuOpen.Text = "&Open..."
    '
    'mnuSave
    '
    Me.mnuSave.Name = "mnuSave"
    Me.mnuSave.Size = New System.Drawing.Size(43, 20)
    Me.mnuSave.Text = "&Save"
    '
    'mnuSaveAs
    '
    Me.mnuSaveAs.Name = "mnuSaveAs"
    Me.mnuSaveAs.Size = New System.Drawing.Size(69, 20)
    Me.mnuSaveAs.Text = "&Save as..."
    '
    'mnuExit
    '
    Me.mnuExit.Name = "mnuExit"
    Me.mnuExit.Size = New System.Drawing.Size(37, 20)
    Me.mnuExit.Text = "&Exit"
    '
    'CheckBox5
    '
    Me.CheckBox5.AutoSize = True
    Me.CheckBox5.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Verbose", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.CheckBox5.Location = New System.Drawing.Point(13, 243)
    Me.CheckBox5.Name = "CheckBox5"
    Me.CheckBox5.Size = New System.Drawing.Size(197, 17)
    Me.CheckBox5.TabIndex = 6
    Me.CheckBox5.Text = "Display detailed progress information"
    Me.CheckBox5.UseVisualStyleBackColor = True
    '
    'btnGo
    '
    Me.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Top
    Me.btnGo.AutoSize = True
    Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
    Me.btnGo.Location = New System.Drawing.Point(203, 358)
    Me.btnGo.Name = "btnGo"
    Me.btnGo.Size = New System.Drawing.Size(99, 26)
    Me.btnGo.TabIndex = 17
    Me.btnGo.Text = "Save && Exit"
    Me.btnGo.UseVisualStyleBackColor = True
    '
    'grpJobQueue
    '
    Me.grpJobQueue.Controls.Add(Me.lblJobQueue)
    Me.grpJobQueue.Location = New System.Drawing.Point(320, 352)
    Me.grpJobQueue.Name = "grpJobQueue"
    Me.grpJobQueue.Size = New System.Drawing.Size(170, 35)
    Me.grpJobQueue.TabIndex = 18
    Me.grpJobQueue.TabStop = False
    Me.grpJobQueue.Text = "Job Queue"
    Me.grpJobQueue.Visible = False
    '
    'lblJobQueue
    '
    Me.lblJobQueue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblJobQueue.Location = New System.Drawing.Point(6, 14)
    Me.lblJobQueue.Name = "lblJobQueue"
    Me.lblJobQueue.Size = New System.Drawing.Size(158, 15)
    Me.lblJobQueue.TabIndex = 0
    Me.lblJobQueue.Text = "6 files in 3 batches"
    Me.lblJobQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'OptionsForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(505, 396)
    Me.Controls.Add(Me.grpJobQueue)
    Me.Controls.Add(Me.btnGo)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.btnContactClear)
    Me.Controls.Add(Me.btnOutputClear)
    Me.Controls.Add(Me.btnContactBrowse)
    Me.Controls.Add(Me.btnOutputBrowse)
    Me.Controls.Add(Me.lblContactFile)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.lblOutputPath)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.CheckBox5)
    Me.Controls.Add(Me.CheckBox4)
    Me.Controls.Add(Me.CheckBox3)
    Me.Controls.Add(Me.CheckBox2)
    Me.Controls.Add(Me.CheckBox1)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.cmbFormat)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.MenuStrip1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.MaximizeBox = False
    Me.Name = "OptionsForm"
    Me.Text = "ms2mz"
    CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    CType(Me.FiltersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.grpJobQueue.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Private WithEvents Label1 As System.Windows.Forms.Label
  Private WithEvents cmbFormat As System.Windows.Forms.ComboBox
  Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Private WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Private WithEvents radBinary32 As System.Windows.Forms.RadioButton
  Private WithEvents Label4 As System.Windows.Forms.Label
  Private WithEvents Label3 As System.Windows.Forms.Label
  Private WithEvents Label2 As System.Windows.Forms.Label
  Private WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Private WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Private WithEvents CheckBox3 As System.Windows.Forms.CheckBox
  Private WithEvents CheckBox4 As System.Windows.Forms.CheckBox
  Private WithEvents Label5 As System.Windows.Forms.Label
  Private WithEvents lblOutputPath As System.Windows.Forms.Label
  Private WithEvents btnOutputBrowse As System.Windows.Forms.LinkLabel
  Private WithEvents btnOutputClear As System.Windows.Forms.LinkLabel
  Private WithEvents Label7 As System.Windows.Forms.Label
  Private WithEvents lblContactFile As System.Windows.Forms.Label
  Private WithEvents btnContactBrowse As System.Windows.Forms.LinkLabel
  Private WithEvents btnContactClear As System.Windows.Forms.LinkLabel
  Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Private WithEvents RadioButton9 As System.Windows.Forms.RadioButton
  Private WithEvents radIntensityValues32 As System.Windows.Forms.RadioButton
  Private WithEvents RadioButton7 As System.Windows.Forms.RadioButton
  Private WithEvents radMzValues32 As System.Windows.Forms.RadioButton
  Private WithEvents Panel3 As System.Windows.Forms.Panel
  Private WithEvents Panel2 As System.Windows.Forms.Panel
  Private WithEvents Panel1 As System.Windows.Forms.Panel
  Private WithEvents BindingSource1 As System.Windows.Forms.BindingSource
  Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Private WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
  Private WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
  Private WithEvents CheckBox5 As System.Windows.Forms.CheckBox
  Private WithEvents btnGo As System.Windows.Forms.Button
  Private WithEvents grpJobQueue As System.Windows.Forms.GroupBox
  Private WithEvents lblJobQueue As System.Windows.Forms.Label
  Private WithEvents lstFilters As System.Windows.Forms.ListBox
  Friend WithEvents FiltersBindingSource As System.Windows.Forms.BindingSource
  Private WithEvents btnAdd As System.Windows.Forms.Button
  Private WithEvents btnDelete As System.Windows.Forms.Button
  Private WithEvents btnDown As System.Windows.Forms.Button
  Private WithEvents btnUp As System.Windows.Forms.Button

End Class
