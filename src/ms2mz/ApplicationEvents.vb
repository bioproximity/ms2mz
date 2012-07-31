Namespace My

  ' The following events are available for MyApplication:
  ' 
  ' Startup: Raised when the application starts, before the startup form is created.
  ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
  ' UnhandledException: Raised if the application encounters an unhandled exception.
  ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
  ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
  Partial Friend Class MyApplication
    Public Const DefaultConfigFile As String = "ms2mz.config"

    Public Property Config As ConfigurationSet
    Public JobQueue As Queue(Of ReadOnlyCollection(Of String))


    Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
      Using storage As IsolatedStorageFile = IsolatedStorageFile.GetMachineStoreForDomain()
        If storage.FileExists(DefaultConfigFile) Then
          Using stream As New IsolatedStorageFileStream(DefaultConfigFile, FileMode.Open, storage)
            Using reader As New StreamReader(stream)
              Try
                Config = ConfigurationSet.Load(reader)
              Catch ex As Exception
              End Try
            End Using
          End Using
        End If
      End Using
      If Config Is Nothing Then Config = New ConfigurationSet()
      JobQueue = New Queue(Of System.Collections.ObjectModel.ReadOnlyCollection(Of String))()
      If Me.CommandLineArgs.Count > 0 Then
        JobQueue.Enqueue(Me.CommandLineArgs)
        Me.MainForm = New ProgressForm()
      End If
    End Sub


    Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
      If e.CommandLine.Count = 0 Then      ' want to change settings, while program already running?
        If Me.MainForm Is OptionsForm Then
          e.BringToForeground = True
        Else     ' some job in progress
          Me.MainForm.Activate()
          MessageBox.Show(Me.MainForm, "You need to wait for active jobs to finish before you can change options.")
        End If
        Return
      End If
      ' else - adding a new job to queue
      JobQueue.Enqueue(e.CommandLine)
      Me.MainForm.Activate()
      If Me.MainForm Is OptionsForm Then
        DirectCast(Me.MainForm, OptionsForm).ReportJobQueued()
      Else
        CType(Me.MainForm, ProgressForm).ReportQueue()
      End If
    End Sub
  End Class
End Namespace

