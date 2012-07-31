Imports System.Text.RegularExpressions

Public Class ProgressForm

  Private strLog As StringBuilder
  Private OutdirNotSet As Boolean

  Private Declare Function FlashWindowEx Lib "user32" (ByRef FWInfo As FLASHWINFO) As Boolean
  Private Structure FLASHWINFO
    Dim cbSize As Integer     ' size of structure
    Dim hWnd As IntPtr        ' hWnd of window to use
    Dim dwFlags As Integer    ' Flags, see below
    Dim uCount As Integer     ' Number of times to flash window
    Dim dwTimeout As Integer  ' Flash rate of window in milliseconds. 0 is default.
  End Structure


  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    ' Add any initialization after the InitializeComponent() call.
    prMsconvert.StartInfo.FileName = "msconvert.exe"
    'prMsconvert.StartInfo.FileName = "d:\Work\Brian Balgley\ms2mz\ProteoWizard 3.0\msconvert.exe"
    My.Application.Config.Verbose = True
    OutdirNotSet = String.IsNullOrWhiteSpace(My.Application.Config.OutputPath)
  End Sub


  Private Sub ProgressForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim strFiles As String
    Dim job As ReadOnlyCollection(Of String)
    strLog = New StringBuilder()
    job = My.Application.JobQueue.Dequeue()
    strFiles = """" & String.Join(""" """, job.ToArray()) & """"
    ReportQueue()
    If OutdirNotSet Then My.Application.Config.OutputPath = Path.GetDirectoryName(job(0))
    prMsconvert.StartInfo.Arguments = strFiles & My.Application.Config.ToArguments()
    prMsconvert.Start()
    prMsconvert.BeginErrorReadLine()
    prMsconvert.BeginOutputReadLine()
  End Sub

  Private Sub ProgressForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
    If Not prMsconvert.HasExited Then
      prMsconvert.Kill()
    End If
    prMsconvert.Close()
  End Sub


  Public Sub ReportQueue()
    If My.Application.JobQueue.Count = 0 Then
      lblQueue.Visible = False
    Else
      lblQueue.Visible = True
      lblQueue.Text = My.Application.JobQueue.Count.ToString() & " jobs in queue"
    End If
  End Sub


  Private Sub prMsconvert_ErrorDataReceived(ByVal sender As System.Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles prMsconvert.ErrorDataReceived
    If Not String.IsNullOrWhiteSpace(e.Data) Then strLog.AppendLine(e.Data)
  End Sub


  Private Sub prMsconvert_OutputDataReceived(ByVal sender As System.Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles prMsconvert.OutputDataReceived
    Dim aMatches As MatchCollection
    Static strProgress As String

    If String.IsNullOrWhiteSpace(e.Data) Then Return
    Debug.WriteLine("Out: " & e.Data)
    If e.Data.StartsWith("[msconvert]") Then
      strLog.AppendLine(e.Data)
    ElseIf e.Data.StartsWith("processing file:") Then
      lblProgress.Text = "Processing: " & e.Data.Substring(17)
    ElseIf e.Data.StartsWith("writing output file:") Then
      strProgress = "Writing {0}/{1}: " & e.Data.Substring(21)
    ElseIf e.Data = "calculating source file checksums" Then
      lblProgress.Text = e.Data
    Else
      aMatches = Regex.Matches(e.Data, "(\d+)/(\d+)")
      If aMatches.Count = 1 AndAlso aMatches(0).Groups.Count = 3 Then
        pbProgress.Visible = True
        pbProgress.Maximum = Integer.Parse(aMatches(0).Groups(2).Value)
        pbProgress.Value = Integer.Parse(aMatches(0).Groups(1).Value)
        lblProgress.Text = String.Format(strProgress, pbProgress.Value, pbProgress.Maximum)
      End If
    End If
  End Sub


  Private Sub prMsconvert_Exited(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prMsconvert.Exited
    Dim FWInfo As FLASHWINFO

    prMsconvert.CancelErrorRead()
    prMsconvert.CancelOutputRead()
    pbProgress.Visible = False
    If prMsconvert.ExitCode <> 0 Then       ' some files failed
      strLog.AppendLine(prMsconvert.ExitCode.ToString() & " files failed to process")
    End If
    If strLog.Length = 0 Then
      ' this job was fine
      If My.Application.JobQueue.Count = 0 And String.IsNullOrWhiteSpace(txtLog.Text) Then _
        Me.Close() ' we may leave
    Else
      lblProgress.Text = "Process complete"
      txtLog.Visible = True
      txtLog.Text &= strLog.ToString() & ControlChars.CrLf
      With FWInfo
        .cbSize = 20
        .hWnd = Me.Handle
        .dwFlags = 0
        .uCount = 0
        .dwTimeout = 0
      End With
      FlashWindowEx(FWInfo)
    End If
    If My.Application.JobQueue.Count > 0 Then _
      ProgressForm_Load(Me, New EventArgs())
  End Sub
End Class
