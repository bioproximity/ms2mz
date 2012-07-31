<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddFilterForm
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
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.btnOK = New System.Windows.Forms.Button()
    Me.tblFilter = New System.Windows.Forms.TableLayoutPanel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmbFilter = New System.Windows.Forms.ComboBox()
    Me.errError = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.lblInfo = New System.Windows.Forms.Label()
    Me.tblFilter.SuspendLayout()
    CType(Me.errError, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnCancel
    '
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(94, 88)
    Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 15)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(75, 23)
    Me.btnCancel.TabIndex = 3
    Me.btnCancel.Text = "Cancel"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'btnOK
    '
    Me.btnOK.Location = New System.Drawing.Point(13, 88)
    Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 3, 3, 15)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(75, 23)
    Me.btnOK.TabIndex = 2
    Me.btnOK.Text = "OK"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'tblFilter
    '
    Me.tblFilter.AutoSize = True
    Me.tblFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.tblFilter.BackColor = System.Drawing.SystemColors.Control
    Me.tblFilter.ColumnCount = 1
    Me.tblFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
    Me.tblFilter.Controls.Add(Me.Label1, 0, 0)
    Me.tblFilter.Controls.Add(Me.cmbFilter, 0, 1)
    Me.tblFilter.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns
    Me.tblFilter.Location = New System.Drawing.Point(12, 12)
    Me.tblFilter.Name = "tblFilter"
    Me.tblFilter.RowCount = 2
    Me.tblFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.tblFilter.RowStyles.Add(New System.Windows.Forms.RowStyle())
    Me.tblFilter.Size = New System.Drawing.Size(162, 40)
    Me.tblFilter.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(55, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Filter type:"
    '
    'cmbFilter
    '
    Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbFilter.FormattingEnabled = True
    Me.cmbFilter.Location = New System.Drawing.Point(3, 16)
    Me.cmbFilter.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
    Me.cmbFilter.Name = "cmbFilter"
    Me.cmbFilter.Size = New System.Drawing.Size(139, 21)
    Me.cmbFilter.TabIndex = 1
    Me.cmbFilter.Tag = "Filter type to apply"
    '
    'errError
    '
    Me.errError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
    Me.errError.ContainerControl = Me
    '
    'lblInfo
    '
    Me.lblInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblInfo.AutoSize = True
    Me.lblInfo.Location = New System.Drawing.Point(12, 62)
    Me.lblInfo.Name = "lblInfo"
    Me.lblInfo.Size = New System.Drawing.Size(39, 13)
    Me.lblInfo.TabIndex = 1
    Me.lblInfo.Text = "Label2"
    '
    'AddFilterForm
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.AutoSize = True
    Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(183, 123)
    Me.Controls.Add(Me.lblInfo)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.tblFilter)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AddFilterForm"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Add filter"
    Me.tblFilter.ResumeLayout(False)
    Me.tblFilter.PerformLayout()
    CType(Me.errError, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Private WithEvents btnCancel As System.Windows.Forms.Button
  Private WithEvents btnOK As System.Windows.Forms.Button
  Private WithEvents tblFilter As System.Windows.Forms.TableLayoutPanel
  Private WithEvents Label1 As System.Windows.Forms.Label
  Private WithEvents cmbFilter As System.Windows.Forms.ComboBox
  Private WithEvents errError As System.Windows.Forms.ErrorProvider
  Private WithEvents lblInfo As System.Windows.Forms.Label
End Class
