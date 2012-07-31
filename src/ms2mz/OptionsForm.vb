Public Class OptionsForm

  Private strLoadedFile As String


  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    ' Add any initialization after the InitializeComponent() call.
    cmbFormat.DataSource = ConfigurationSet.OutputFormatList
    AddHandler lblOutputPath.DataBindings("Tag").Format, AddressOf PathChanged
    AddHandler lblContactFile.DataBindings("Tag").Format, AddressOf PathChanged
    BindingSource1.DataSource = My.Application.Config
  End Sub


  Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
              Handles btnOutputClear.Click, btnContactClear.Click
    Dim ctrTarget As Label
    If sender Is btnOutputClear Then ctrTarget = lblOutputPath Else ctrTarget = lblContactFile
    ctrTarget.Tag = String.Empty
    PathFormat(ctrTarget, String.Empty)
    ctrTarget.DataBindings("Tag").WriteValue()
  End Sub


  Private Sub btnOutputBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutputBrowse.Click
    Dim fbd As FolderBrowserDialog = New FolderBrowserDialog()

    With fbd
      .Description = "Select folder to store output files"
      .SelectedPath = lblOutputPath.Tag.ToString()
      If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        lblOutputPath.Tag = .SelectedPath
        PathFormat(lblOutputPath, .SelectedPath)
        lblOutputPath.DataBindings("Tag").WriteValue()
      End If
    End With
  End Sub


  Private Sub btnContactBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContactBrowse.Click
    Dim ofd As OpenFileDialog = New OpenFileDialog()
    With ofd
      .FileName = lblContactFile.Tag.ToString()
      .Filter = "All files|*.*"
      If .ShowDialog(Me) = DialogResult.OK Then
        lblContactFile.Tag = .FileName
        PathFormat(lblContactFile, .FileName)
        lblContactFile.DataBindings("Tag").WriteValue()
      End If
    End With
  End Sub


  Private Sub PathChanged(ByVal sender As Object, ByVal e As ConvertEventArgs)
    Dim b As Binding = DirectCast(sender, Binding)
    If e.Value Is Nothing Then e.Value = String.Empty
    PathFormat(DirectCast(b.Control, Label), e.Value.ToString())
  End Sub

  Private Sub PathFormat(ByVal Control As Label, ByVal Value As String)
    Dim size As SizeF

    Using gr As Graphics = Graphics.FromHwnd(Me.Handle)
      size = gr.MeasureString(Value, Control.Font)
      If size.Width > Control.Width Then
        If Path.GetPathRoot(Value) = Path.GetDirectoryName(Value) Then Control.Text = Value _
          Else Control.Text = Path.GetPathRoot(Value) & "...\" & Path.GetFileName(Value)
        ToolTip1.SetToolTip(Control, Value)
      Else
        Control.Text = Value
        ToolTip1.SetToolTip(Control, String.Empty)
      End If
    End Using
  End Sub



  Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
    My.Application.Config = New ConfigurationSet()
    Me.Text = "ms2mz"
    radBinary32.Checked = True
    radMzValues32.Checked = True
    radIntensityValues32.Checked = True
    BindingSource1.DataSource = My.Application.Config
  End Sub


  Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
    Dim ofd As OpenFileDialog = New OpenFileDialog()
    With ofd
      .Filter = "Ms2mz config files|*.2mz|All files|*.*"
      .DefaultExt = "2mz"
      If Not String.IsNullOrWhiteSpace(strLoadedFile) Then .InitialDirectory = Path.GetDirectoryName(strLoadedFile)
      If .ShowDialog(Me) = DialogResult.OK Then
        Using reader As StreamReader = New StreamReader(.FileName)
          Try
            My.Application.Config = ConfigurationSet.Load(reader)
            strLoadedFile = .FileName
            Me.Text = "ms2mz - " & Path.GetFileName(.FileName)
          Catch ex As Exception
            MessageBox.Show(ex.Message, "Error loading configuration")
          Finally
            radBinary32.Checked = True
            radMzValues32.Checked = True
            radIntensityValues32.Checked = True
            BindingSource1.DataSource = My.Application.Config
            lstFilters_SelectedIndexChanged(lstFilters, EventArgs.Empty)
          End Try
        End Using
      End If
    End With
  End Sub


  Private Sub mnuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSave.Click
    Using storage As IsolatedStorageFile = IsolatedStorageFile.GetMachineStoreForDomain()
      Using stream As New IsolatedStorageFileStream(My.MyApplication.DefaultConfigFile, FileMode.Create, storage)
        Using writer As New StreamWriter(stream)
          My.Application.Config.ToFile(writer)
        End Using
      End Using
    End Using

  End Sub


  Private Sub mnuSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
    Dim sfd As SaveFileDialog = New SaveFileDialog()
    With sfd
      .FileName = strLoadedFile
      .Filter = "Ms2mz config files|*.2mz|All files|*.*"
      .DefaultExt = "2mz"
      .AddExtension = True
      If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        Using writer As StreamWriter = New StreamWriter(.FileName, False)
          My.Application.Config.ToFile(writer)
        End Using
        strLoadedFile = .FileName
        Me.Text = "ms2mz - " & Path.GetFileName(strLoadedFile)
        mnuSave_Click(mnuSave, EventArgs.Empty)
      End If
    End With
  End Sub


  Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    If My.Application.JobQueue.Count = 0 OrElse MessageBox.Show("There are " & My.Application.JobQueue.Count.ToString() & _
          " jobs queued for processing." & ControlChars.CrLf & "Are you sure you want to discard these jobs and exit?", _
          "Exit confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then _
      Me.Close()
  End Sub


  Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
    Dim frmProg As ProgressForm
    mnuSave_Click(mnuSave, EventArgs.Empty)
    If My.Application.JobQueue.Count > 0 Then
      frmProg = New ProgressForm()
      frmProg.Show()
    End If
    Me.Close()
  End Sub


  Public Sub ReportJobQueued()
    Dim i As Integer
    Dim str1 As String = String.Empty
    Dim str2 As String = String.Empty
    btnGo.Text = "Save && Process queue"
    grpJobQueue.Visible = True
    btnGo.Left = (grpJobQueue.Left - btnGo.Width) \ 2
    For Each job As ReadOnlyCollection(Of String) In My.Application.JobQueue
      i += job.Count
    Next
    If i > 1 Then str1 = "s"
    If My.Application.JobQueue.Count > 1 Then str2 = "es"
    lblJobQueue.Text = String.Format("{0} file{1} in {2} batch{3}", i, str1, My.Application.JobQueue.Count, str2)
  End Sub


  Private Sub lstFilters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilters.SelectedIndexChanged
    btnUp.Enabled = lstFilters.SelectedIndex > 0
    btnDown.Enabled = lstFilters.SelectedIndex > -1 And lstFilters.SelectedIndex < lstFilters.Items.Count - 1
    btnDelete.Enabled = lstFilters.SelectedIndex <> -1
  End Sub


  Private Sub btnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
              Handles btnUp.Click, btnDown.Click
    Dim iDir As Integer
    Dim f As Filter = My.Application.Config.Filters(lstFilters.SelectedIndex)
    If sender Is btnUp Then iDir = -1 Else iDir = +1
    My.Application.Config.Filters.Remove(f)
    My.Application.Config.Filters.Insert(lstFilters.SelectedIndex + iDir, f)
    FiltersBindingSource.ResetBindings(False)
    lstFilters.SelectedIndex += iDir
  End Sub


  Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    My.Application.Config.Filters.RemoveAt(lstFilters.SelectedIndex)
    FiltersBindingSource.ResetBindings(False)
  End Sub


  Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    Dim winAdd As AddFilterForm = New AddFilterForm()
    winAdd.Owner = Me
    If winAdd.ShowDialog() = DialogResult.OK Then
      My.Application.Config.Filters.Insert(lstFilters.SelectedIndex + 1, winAdd.Filter)
      FiltersBindingSource.ResetBindings(False)
    End If
  End Sub


  Private Sub lstFilters_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFilters.MouseDoubleClick
    Dim winAdd As AddFilterForm
    If lstFilters.SelectedIndex <> -1 Then
      winAdd = New AddFilterForm()
      winAdd.Owner = Me
      winAdd.Filter = My.Application.Config.Filters(lstFilters.SelectedIndex)
      If winAdd.ShowDialog() = DialogResult.OK Then
        My.Application.Config.Filters.RemoveAt(lstFilters.SelectedIndex)
        My.Application.Config.Filters.Insert(lstFilters.SelectedIndex, winAdd.Filter)
        FiltersBindingSource.ResetBindings(False)
      End If
    End If
  End Sub
End Class
