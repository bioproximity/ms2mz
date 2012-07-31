Public Class AddFilterForm

  Private _Filter As Filter

  Public Sub New()
    ' This call is required by the designer.
    InitializeComponent()
    ' Add any initialization after the InitializeComponent() call.
    cmbFilter.Items.Add(String.Empty)
    cmbFilter.Items.AddRange(Filter.FilterNames)
  End Sub

  Public Property Filter As Filter
    Get
      Return _Filter
    End Get
    Set(ByVal value As Filter)
      _Filter = DirectCast(value.Clone(), Filter)
      Me.Text = "Edit filter"
      cmbFilter.SelectedItem = _Filter.Name
    End Set
  End Property


  Private Sub AddFilterForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    RemoveDynamicControls()
  End Sub

  Private Sub RemoveDynamicControls()
    Dim ctr As Control
    For i As Integer = 1 To tblFilter.ColumnCount - 1
      ctr = tblFilter.GetControlFromPosition(i, 0)
      If ctr IsNot Nothing Then
        tblFilter.Controls.Remove(ctr)
        ctr.Dispose()
      End If
      ctr = tblFilter.GetControlFromPosition(i, 1)
      If ctr IsNot Nothing Then
        tblFilter.Controls.Remove(ctr)
        ctr.Dispose()
      End If
    Next
    tblFilter.ColumnCount = 1
  End Sub


  Private Sub Control_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilter.GotFocus
    Dim str As String
    str = errError.GetError(DirectCast(sender, Control))
    If Not String.IsNullOrWhiteSpace(str) Then
      lblInfo.Text = str
    ElseIf DirectCast(sender, Control).Tag IsNot Nothing Then
      lblInfo.Text = CStr(DirectCast(sender, Control).Tag)
    End If
    btnCancel.Top = lblInfo.Bottom + 13
    btnOK.Top = lblInfo.Bottom + 13
    Me.PerformLayout()
  End Sub


  Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilter.SelectedIndexChanged
    Dim ctr As Control
    Dim flt As Filter
    RemoveDynamicControls()
    flt = Filter.CreateFilter(CStr(cmbFilter.SelectedItem))
    If flt Is Nothing Or _Filter Is Nothing OrElse flt.GetType() IsNot _Filter.GetType() Then _Filter = flt
    If _Filter IsNot Nothing Then
      tblFilter.ColumnCount = 1 + _Filter.GetControlsNumber()
      Do While tblFilter.ColumnStyles.Count < tblFilter.ColumnCount
        tblFilter.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
      Loop
      For i As Integer = 1 To tblFilter.ColumnCount - 1
        ctr = _Filter.CreateLabel(i)
        If ctr IsNot Nothing Then tblFilter.Controls.Add(ctr, i, 0)
        ctr = _Filter.CreateControl(i)
        If TypeOf (ctr) Is Panel Then
          For Each c As Control In ctr.Controls
            AddHandler c.GotFocus, AddressOf Control_GotFocus
          Next
        Else
          AddHandler ctr.GotFocus, AddressOf Control_GotFocus
        End If
        tblFilter.Controls.Add(ctr, i, 1)
      Next i
    End If
    lblInfo.Top = tblFilter.Bottom + 10
    btnCancel.Left = Math.Max(94, tblFilter.Right - btnCancel.Width - 6)
    btnCancel.Top = lblInfo.Bottom + 13 ' tblFilter.Bottom + 36
    btnOK.Left = Math.Max(13, btnCancel.Left - btnOK.Width - 6)
    btnOK.Top = lblInfo.Bottom + 13 ' tblFilter.Bottom + 36
    Me.PerformLayout()
  End Sub


  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Dim bOK As Boolean = True
    If cmbFilter.SelectedIndex <= 0 Then
      errError.SetError(cmbFilter, "Select filter type")
      lblInfo.Text = "Select filter type"
      Return
    Else
      errError.SetError(cmbFilter, String.Empty)
    End If
    For i As Integer = 1 To tblFilter.ColumnCount - 1
      bOK = bOK And _Filter.ValidateControl(tblFilter.GetControlFromPosition(i, 1), i, errError)
    Next
    If Not bOK Then Return
    For i As Integer = 1 To tblFilter.ColumnCount - 1
      _Filter.ReadValue(tblFilter.GetControlFromPosition(i, 1), i)
    Next
    Me.DialogResult = DialogResult.OK
  End Sub
End Class