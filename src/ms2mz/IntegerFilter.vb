Public MustInherit Class IntegerFilter
  Inherits Filter

  Public Property Intervals As IntervalCollection = New IntervalCollection()

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length < 2 Then Throw New Exception()
    Intervals.Clear()
    For i As Integer = 1 To Arguments.Length - 1
      Intervals.Add(Interval.Parse(Arguments(i)))
    Next
  End Sub


  Public Overrides Function ToString() As String
    Return Name & Intervals.ToString()
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim txt As TextBox = New TextBox()
    txt.Margin = New Padding(3, 3, 20, 3)
    txt.Tag = "Must be one or more integers or intervals of the form a, a-, a-b or [a,b]"
    txt.TabIndex = 2 * Number + 1
    txt.Width = 150
    txt.Text = Intervals.ToString()
    Return txt
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim txt As TextBox = DirectCast(ctr, TextBox)
    If String.IsNullOrWhiteSpace(txt.Text) Then
      err.SetError(ctr, "Parameter is required")
      Return False
    Else
      Dim astr() As String = txt.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
      Try
        For Each Str As String In astr
          Interval.Parse(Str)
        Next
        err.SetError(ctr, String.Empty)
        Return True
      Catch
        err.SetError(ctr, "Invalid format")
        Return False
      End Try
    End If
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Dim astr() As String = DirectCast(ctr, TextBox).Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
    Intervals.Clear()
    For Each Str As String In astr
      Intervals.Add(Interval.Parse(Str))
    Next
  End Sub
End Class


Public Class Interval
  Protected Lower, Upper As Integer

  Public Shared Function Parse(ByVal str As String) As Interval
    Dim int As Interval = New Interval()
    Dim m As Match = Regex.Match(str, "^\[(\d+),(\d+)\]$")
    If m.Success Then
      int.Lower = Integer.Parse(m.Groups(1).Value)
      int.Upper = Integer.Parse(m.Groups(2).Value)
      Return int
    End If
    m = Regex.Match(str, "^(\d+)-(\d+)?$")
    If m.Success Then
      int.Lower = Integer.Parse(m.Groups(1).Value)
      If m.Groups.Count = 3 AndAlso m.Groups(2).Success Then int.Upper = Integer.Parse(m.Groups(2).Value) Else int.Upper = Integer.MaxValue
      Return int
    End If
    If Not Integer.TryParse(str, int.Lower) Then Throw New Exception()
    int.Upper = int.Lower
    Return int
  End Function


  Public Overrides Function ToString() As String
    Dim str As String = Me.Lower.ToString()
    If Lower <> Upper Then
      str &= "-"
      If Upper < Integer.MaxValue Then str &= Upper.ToString()
    End If
    Return str
  End Function
End Class


Public Class IntervalCollection
  Inherits Collection(Of Interval)

  Public Overrides Function ToString() As String
    Dim str As StringBuilder = New StringBuilder()
    For Each Int As Interval In Me
      str.Append(" " & Int.ToString())
    Next
    Return str.ToString()
  End Function
End Class



Public Class IndexFilter
  Inherits IntegerFilter

  Friend Const cName As String = "index"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property
End Class


Public Class MsLevelFilter
  Inherits IntegerFilter

  Friend Const cName As String = "msLevel"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property
End Class


Public Class ScanNumberFilter
  Inherits IntegerFilter

  Friend Const cName As String = "scanNumber"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property
End Class


Public Class ScanEventFilter
  Inherits IntegerFilter

  Friend Const cName As String = "scanEvent"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property
End Class


Public Class DefaultArrayLengthFilter
  Inherits IntegerFilter

  Friend Const cName As String = "defaultArrayLength"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property
End Class


Public Class PeakPickingFilter
  Inherits IntegerFilter

  Friend Const cName As String = "peakPicking"

  Public Property PreferVendor As Boolean


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length < 3 Then Throw New Exception()
    If Not Boolean.TryParse(Arguments(1), _PreferVendor) Then Throw New Exception()
    Intervals.Clear()
    For i As Integer = 2 To Arguments.Length - 1
      Intervals.Add(Interval.Parse(Arguments(i)))
    Next
  End Sub


  Public Overrides Function ToString() As String
    Return Name & " " & PreferVendor.ToString().ToLower() & Intervals.ToString()
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 2
  End Function


  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    If Number = 2 Then
      Dim lbl As Label = New Label()
      lbl.AutoSize = True
      lbl.TabIndex = 2 * Number
      lbl.Text = "MS levels"
      Return lbl
    Else
      Return Nothing
    End If
  End Function


  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    If Number = 1 Then
      Dim chk As CheckBox = New CheckBox()
      chk.TabIndex = 2 * Number + 1
      chk.Size = New Size(100, 18)
      chk.Margin = New Padding(3, 5, 10, 3)
      chk.Text = "Prefer vendor"
      chk.Tag = "Sets if vendor peak picking should be used"
      chk.Checked = PreferVendor
      Return chk
    Else
      Return MyBase.CreateControl(Number)
    End If
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    If Number = 2 Then Return MyBase.ValidateControl(ctr, Number, err) _
      Else Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    If Number = 2 Then MyBase.ReadValue(ctr, Number) _
      Else PreferVendor = DirectCast(ctr, CheckBox).Checked
  End Sub
End Class


Public Class ThresholdFilter
  Inherits IntegerFilter


  Friend Const cName As String = "threshold"

  Private _type As String = String.Empty
  Private _selection As String = String.Empty

  Public Shared ThresholdTypes() As String = New String() {"count", "count-after-ties", "absolute", "bpi-relative", "tic-relative", "tic-cutoff"}
  Public Shared SelectionTypes() As String = New String() {"most-intense", "least-intense"}

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length < 4 Then Throw New Exception()
    Type = Arguments(1)
    If Not Double.TryParse(Arguments(2), _Threshold) Then Throw New Exception()
    Selection = Arguments(3)
    Intervals.Clear()
    For i As Integer = 4 To Arguments.Length - 1
      Intervals.Add(Interval.Parse(Arguments(i)))
    Next
  End Sub


  Public Property Threshold As Double

  Public Property Type As String
    Get
      Return _type
    End Get
    Set(ByVal value As String)
      value = value.ToLower()
      If (Not String.IsNullOrWhiteSpace(value)) AndAlso Not ThresholdTypes.Contains(value) Then Throw New Exception()
      _type = value
    End Set
  End Property

  Public Property Selection As String
    Get
      Return _selection
    End Get
    Set(ByVal value As String)
      value = value.ToLower()
      If (Not String.IsNullOrWhiteSpace(value)) AndAlso Not SelectionTypes.Contains(value) Then Throw New Exception()
      _selection = value
    End Set
  End Property


  Public Overrides Function ToString() As String
    Return (cName & " " & _type & " " & _Threshold.ToString() & " " & _selection & Intervals.ToString()).Trim()
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 4
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Threshold type"
      Case 2 : lbl.Text = "Value"
      Case 3 : lbl.Text = "Selection method"
      Case 4 : lbl.Text = "MS levels"
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Select Case Number
      Case 1
        Dim cmb As ComboBox = New ComboBox()
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.Margin = New Padding(3, 3, 20, 3)
        cmb.Tag = "Sets how to interpret threshold value"
        cmb.TabIndex = 2 * Number + 1
        cmb.Items.Add(String.Empty)
        cmb.Items.AddRange(ThresholdTypes)
        cmb.Width = 100
        cmb.SelectedItem = _type
        Return cmb
      Case 2
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 60
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Threshold value, e.g. 3, .5"
        txt.Text = _Threshold.ToString()
        Return txt
      Case 3
        Dim cmb As ComboBox = New ComboBox()
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.Margin = New Padding(3, 3, 20, 3)
        cmb.Tag = "Sets what samples will be selected"
        cmb.TabIndex = 2 * Number + 1
        cmb.Items.Add(String.Empty)
        cmb.Items.AddRange(SelectionTypes)
        cmb.Width = 100
        cmb.SelectedItem = _selection
        Return cmb
      Case 4
        Return MyBase.CreateControl(Number)
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Select Case Number
      Case 1
        Dim cmb As ComboBox = DirectCast(ctr, ComboBox)
        If cmb.SelectedIndex = 0 Then
          err.SetError(ctr, "Threshold type is required")
          Return False
        Else
          err.SetError(ctr, String.Empty)
          Return True
        End If
      Case 2
        Dim d As Double
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
          err.SetError(ctr, "Threshold value is required")
          Return False
        End If
        If Not Double.TryParse(txt.Text, d) Then
          err.SetError(ctr, "Invalid number format")
          Return False
        End If
        If d < 0 Then
          err.SetError(ctr, "Negative number is not allowed")
          Return False
        End If
        err.SetError(ctr, String.Empty)
        Return True
      Case 3
        Dim cmb As ComboBox = DirectCast(ctr, ComboBox)
        If cmb.SelectedIndex = 0 Then
          err.SetError(ctr, "Selection type is required")
          Return False
        Else
          err.SetError(ctr, String.Empty)
          Return True
        End If
      Case 4
        If String.IsNullOrWhiteSpace(DirectCast(ctr, TextBox).Text) Then Return True
        Return MyBase.ValidateControl(ctr, Number, err)
    End Select
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        _type = CStr(DirectCast(ctr, ComboBox).SelectedItem)
      Case 2
        _Threshold = Double.Parse(DirectCast(ctr, TextBox).Text)
      Case 3
        _selection = CStr(DirectCast(ctr, ComboBox).SelectedItem)
      Case 4
        MyBase.ReadValue(ctr, Number)
    End Select
  End Sub
End Class


Public Class ZeroSamplesFilter
  Inherits IntegerFilter


  Friend Const cName As String = "zeroSamples"

  Public RemoveZeros As Boolean = True
  Public FlankingZeroCount As Integer?

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    Dim i As Integer
    If Arguments.Length < 3 Then Throw New Exception()
    If Arguments(1).ToLower() = "removeextra" Then
      RemoveZeros = True
    ElseIf Arguments(1).ToLower().StartsWith("addmissing") Then
      RemoveZeros = False
      i = Arguments(1).IndexOf("=")
      If i <> -1 Then
        If Integer.TryParse(Arguments(1).Substring(i + 1), i) Then FlankingZeroCount = i Else Throw New Exception()
      End If
    Else
      Throw New Exception()
    End If
    Intervals.Clear()
    For i = 2 To Arguments.Length - 1
      Intervals.Add(Interval.Parse(Arguments(i)))
    Next
  End Sub


  Public Overrides Function ToString() As String
    Dim str As String = cName
    If RemoveZeros Then
      str &= " " & "removeExtra"
    Else
      str &= " " & "addMissing"
      If FlankingZeroCount.HasValue Then str &= "=" & FlankingZeroCount.Value.ToString()
    End If
    Return (str & Intervals.ToString()).Trim()
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 3
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Zero samples"
      Case 2 : lbl.Text = "Flank by"
      Case 3 : lbl.Text = "MS levels"
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Select Case Number
      Case 1
        Dim pan As FlowLayoutPanel = New FlowLayoutPanel()
        pan.FlowDirection = FlowDirection.TopDown
        pan.TabIndex = 2 * Number + 1
        pan.AutoSize = True
        Dim rad As RadioButton = New RadioButton()
        rad.TabIndex = 0
        rad.Size = New Size(80, 18)
        rad.Margin = New Padding(0, 0, 10, 0)
        rad.Text = "Remove extra"
        rad.Tag = "Reduces output file sizes by removing zero values which are not adjacent to nonzero values"
        rad.Checked = RemoveZeros
        pan.Controls.Add(rad)
        rad = New RadioButton()
        rad.TabIndex = 1
        rad.Size = New Size(80, 18)
        rad.Margin = New Padding(0, 0, 10, 0)
        rad.Text = "Add missing"
        rad.Tag = "Adds flanking zero values next to nonzero values where needed, to help with things like smoothing"
        rad.Checked = Not RemoveZeros
        pan.Controls.Add(rad)
        Return pan
      Case 2
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 60
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Flanking zero count"
        txt.Text = FlankingZeroCount.ToString()
        Return txt
      Case 3
        Return MyBase.CreateControl(Number)
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Select Case Number
      Case 1
      Case 2
        Dim i As Integer
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
          err.SetError(ctr, String.Empty)
          Return True
        End If
        If Not Integer.TryParse(txt.Text, i) Then
          err.SetError(ctr, "Invalid number format")
          Return False
        End If
        If i < 0 Then
          err.SetError(ctr, "Negative number is not allowed")
          Return False
        End If
        err.SetError(ctr, String.Empty)
        Return True
      Case 3
        Return MyBase.ValidateControl(ctr, Number, err)
    End Select
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        RemoveZeros = DirectCast(DirectCast(ctr, FlowLayoutPanel).Controls(0), RadioButton).Checked
      Case 2
        Dim str As String = DirectCast(ctr, TextBox).Text
        If String.IsNullOrWhiteSpace(str) Then FlankingZeroCount = Nothing _
          Else FlankingZeroCount = Integer.Parse(str)
      Case 3
        MyBase.ReadValue(ctr, Number)
    End Select
  End Sub
End Class
