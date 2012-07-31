<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgressForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressForm))
    Me.lblProgress = New System.Windows.Forms.Label()
    Me.txtLog = New System.Windows.Forms.TextBox()
    Me.lblQueue = New System.Windows.Forms.Label()
    Me.prMsconvert = New System.Diagnostics.Process()
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
    Me.pbProgress = New System.Windows.Forms.ProgressBar()
    Me.FlowLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lblProgress
    '
    Me.lblProgress.AutoSize = True
    Me.lblProgress.Location = New System.Drawing.Point(3, 17)
    Me.lblProgress.MaximumSize = New System.Drawing.Size(351, 55)
    Me.lblProgress.Name = "lblProgress"
    Me.lblProgress.Size = New System.Drawing.Size(10, 13)
    Me.lblProgress.TabIndex = 1
    Me.lblProgress.Text = " "
    '
    'txtLog
    '
    Me.txtLog.Location = New System.Drawing.Point(3, 57)
    Me.txtLog.Multiline = True
    Me.txtLog.Name = "txtLog"
    Me.txtLog.ReadOnly = True
    Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.txtLog.Size = New System.Drawing.Size(351, 214)
    Me.txtLog.TabIndex = 3
    Me.txtLog.Visible = False
    '
    'lblQueue
    '
    Me.lblQueue.Location = New System.Drawing.Point(3, 0)
    Me.lblQueue.Name = "lblQueue"
    Me.lblQueue.Size = New System.Drawing.Size(351, 17)
    Me.lblQueue.TabIndex = 0
    Me.lblQueue.Text = "lblQueue"
    '
    'prMsconvert
    '
    Me.prMsconvert.EnableRaisingEvents = True
    Me.prMsconvert.StartInfo.CreateNoWindow = True
    Me.prMsconvert.StartInfo.Domain = ""
    Me.prMsconvert.StartInfo.LoadUserProfile = False
    Me.prMsconvert.StartInfo.Password = Nothing
    Me.prMsconvert.StartInfo.RedirectStandardError = True
    Me.prMsconvert.StartInfo.RedirectStandardOutput = True
    Me.prMsconvert.StartInfo.StandardErrorEncoding = Nothing
    Me.prMsconvert.StartInfo.StandardOutputEncoding = Nothing
    Me.prMsconvert.StartInfo.UserName = ""
    Me.prMsconvert.StartInfo.UseShellExecute = False
    Me.prMsconvert.SynchronizingObject = Me
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.FlowLayoutPanel1.AutoSize = True
    Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.FlowLayoutPanel1.Controls.Add(Me.lblQueue)
    Me.FlowLayoutPanel1.Controls.Add(Me.lblProgress)
    Me.FlowLayoutPanel1.Controls.Add(Me.pbProgress)
    Me.FlowLayoutPanel1.Controls.Add(Me.txtLog)
    Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(357, 274)
    Me.FlowLayoutPanel1.TabIndex = 3
    '
    'pbProgress
    '
    Me.pbProgress.Location = New System.Drawing.Point(3, 33)
    Me.pbProgress.Name = "pbProgress"
    Me.pbProgress.Size = New System.Drawing.Size(351, 18)
    Me.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pbProgress.TabIndex = 2
    Me.pbProgress.Visible = False
    '
    'ProgressForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
    Me.AutoSize = True
    Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.ClientSize = New System.Drawing.Size(363, 374)
    Me.Controls.Add(Me.FlowLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(369, 32)
    Me.Name = "ProgressForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ms2mz"
    Me.FlowLayoutPanel1.ResumeLayout(False)
    Me.FlowLayoutPanel1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Private WithEvents lblProgress As System.Windows.Forms.Label
  Private WithEvents txtLog As System.Windows.Forms.TextBox
  Private WithEvents lblQueue As System.Windows.Forms.Label
  Private WithEvents prMsconvert As System.Diagnostics.Process
  Private WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Private WithEvents pbProgress As System.Windows.Forms.ProgressBar
End Class
