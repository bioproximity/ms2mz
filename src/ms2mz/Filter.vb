Public MustInherit Class Filter

  Implements ICloneable

  Public Shared FilterNames() As String = {IndexFilter.cName, MsLevelFilter.cName, PrecursorRecalculationFilter.cName,
                                           PrecursorRefineFilter.cName, PeakPickingFilter.cName, ScanNumberFilter.cName,
                                           ScanEventFilter.cName, ScanTimeFilter.cName, SortByScanTimeFilter.cName,
                                           StripIonTrapFilter.cName, MetadataFixerFilter.cName, TitleMakerFilter.cName,
                                           ThresholdFilter.cName, MzWindowFilter.cName, MzPrecursorsFilter.cName,
                                           DefaultArrayLengthFilter.cName, ZeroSamplesFilter.cName, MS2DenoiseFilter.cName,
                                           MS2DeisotopeFilter.cName, ETDFilter.cName, ChargeStatePredictorFilter.cName,
                                           ActivationFilter.cName, AnalyzerFilter.cName, PolarityFilter.cName}

  Public Shared Function CreateFilter(ByVal FilterType As String) As Filter
    Select Case FilterType.ToUpper()
      Case IndexFilter.cName.ToUpper()
        Return New IndexFilter()
      Case MsLevelFilter.cName.ToUpper()
        Return New MsLevelFilter()
      Case PrecursorRecalculationFilter.cName.ToUpper()
        Return New PrecursorRecalculationFilter()
      Case PrecursorRefineFilter.cName.ToUpper()
        Return New PrecursorRefineFilter()
      Case PeakPickingFilter.cName.ToUpper()
        Return New PeakPickingFilter()
      Case ScanNumberFilter.cName.ToUpper()
        Return New ScanNumberFilter()
      Case ScanEventFilter.cName.ToUpper()
        Return New ScanEventFilter()
      Case ScanTimeFilter.cName.ToUpper()
        Return New ScanTimeFilter()
      Case SortByScanTimeFilter.cName.ToUpper()
        Return New SortByScanTimeFilter()
      Case StripIonTrapFilter.cName.ToUpper()
        Return New StripIonTrapFilter()
      Case MetadataFixerFilter.cName.ToUpper()
        Return New MetadataFixerFilter()
      Case TitleMakerFilter.cName.ToUpper()
        Return New TitleMakerFilter()
      Case ThresholdFilter.cName.ToUpper()
        Return New ThresholdFilter()
      Case MzWindowFilter.cName.ToUpper()
        Return New MzWindowFilter()
      Case MzPrecursorsFilter.cName.ToUpper()
        Return New MzPrecursorsFilter()
      Case DefaultArrayLengthFilter.cName.ToUpper()
        Return New DefaultArrayLengthFilter()
      Case ZeroSamplesFilter.cName.ToUpper()
        Return New ZeroSamplesFilter()
      Case MS2DenoiseFilter.cName.ToUpper()
        Return New MS2DenoiseFilter()
      Case MS2DeisotopeFilter.cName.ToUpper()
        Return New MS2DeisotopeFilter()
      Case ETDFilter.cName.ToUpper()
        Return New ETDFilter()
      Case ChargeStatePredictorFilter.cName.ToUpper()
        Return New ChargeStatePredictorFilter()
      Case ActivationFilter.cName.ToUpper()
        Return New ActivationFilter()
      Case AnalyzerFilter.cName.ToUpper()
        Return New AnalyzerFilter()
      Case PolarityFilter.cName.ToUpper()
        Return New PolarityFilter()
      Case Else
        Return Nothing
    End Select
  End Function


  Public Shared Function TryParse(ByVal Input As String, ByRef Result As Filter) As Boolean
    Dim astr() As String
    astr = Input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
    Result = CreateFilter(astr(0))
    If Result Is Nothing Then Return False
    Try
      Result.Load(astr)
    Catch
      Result = Nothing
      Return False
    End Try
    Return True
  End Function

  Public MustOverride ReadOnly Property Name As String

  Protected MustOverride Sub Load(ByVal Arguments() As String)
  Public MustOverride Function GetControlsNumber() As Integer
  Public MustOverride Function CreateLabel(ByVal Number As Integer) As Control
  Public MustOverride Function CreateControl(ByVal Number As Integer) As Control
  Public MustOverride Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
  Public MustOverride Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)

  Public Function Clone() As Object Implements System.ICloneable.Clone
    Return Me.MemberwiseClone()
  End Function
End Class


Public Class PrecursorRecalculationFilter
  Inherits Filter

  Friend Const cName As String = "precursorRecalculation"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class PrecursorRefineFilter
  Inherits Filter

  Friend Const cName As String = "precursorRefine"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class SortByScanTimeFilter
  Inherits Filter

  Friend Const cName As String = "sortByScanTime"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class StripIonTrapFilter
  Inherits Filter


  Friend Const cName As String = "stripIT"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class MetadataFixerFilter
  Inherits Filter


  Friend Const cName As String = "metadataFixer"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class MS2DeisotopeFilter
  Inherits Filter


  Friend Const cName As String = "MS2Deisotope"

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length > 1 Then Throw New Exception()
  End Sub

  Public Overrides Function ToString() As String
    Return cName
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 0
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Return Nothing
  End Function

  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Return True
  End Function

  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
  End Sub
End Class


Public Class ActivationFilter
  Inherits Filter


  Friend Const cName As String = "activation"

  Private _precursor As String = String.Empty

  Public Shared PrecursorTypes() As String = New String() {"ETD", "CID", "SA", "HCD", "BIRD", "ECD", "IRMPD", "PD", "PSD", "PQD", "SID", "SORI"}

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 2 Then Throw New Exception()
    Precursor = Arguments(1)
  End Sub


  Public Property Precursor As String
    Get
      Return _precursor
    End Get
    Set(ByVal value As String)
      value = value.ToUpper()
      If (Not String.IsNullOrWhiteSpace(value)) AndAlso Not PrecursorTypes.Contains(value) Then Throw New Exception()
      _precursor = value
    End Set
  End Property


  Public Overrides Function ToString() As String
    Return cName & " " & _precursor
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.Text = "Activation"
    lbl.TabIndex = 2 * Number
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim cmb As ComboBox = New ComboBox()
    cmb.DropDownStyle = ComboBoxStyle.DropDownList
    cmb.Margin = New Padding(3, 3, 20, 3)
    cmb.Tag = "Precursor activation type"
    cmb.TabIndex = 2 * Number + 1
    cmb.Items.Add(String.Empty)
    cmb.Items.AddRange(PrecursorTypes)
    cmb.Width = 60
    cmb.SelectedItem = _precursor
    Return cmb
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim cmb As ComboBox = DirectCast(ctr, ComboBox)
    If cmb.SelectedIndex = 0 Then
      err.SetError(ctr, "Activation type is required")
      Return False
    Else
      err.SetError(ctr, String.Empty)
      Return True
    End If
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    _precursor = CStr(DirectCast(ctr, ComboBox).SelectedItem)
  End Sub
End Class


Public Class AnalyzerFilter
  Inherits Filter


  Friend Const cName As String = "analyzer"

  Private _analyzer As String = String.Empty

  Public Shared AnalyzerTypes() As String = New String() {"quad", "orbi", "FT", "IT", "TOF"}

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 2 Then Throw New Exception()
    Analyzer = Arguments(1)
  End Sub


  Public Property Analyzer As String
    Get
      Return _analyzer
    End Get
    Set(ByVal value As String)
      If (Not String.IsNullOrWhiteSpace(value)) AndAlso Not AnalyzerTypes.Contains(value, New CIComparer(Of String)) Then Throw New Exception()
      _analyzer = value
    End Set
  End Property


  Public Overrides Function ToString() As String
    Return cName & " " & _analyzer
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.Text = "Analyzer"
    lbl.TabIndex = 2 * Number
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim cmb As ComboBox = New ComboBox()
    cmb.DropDownStyle = ComboBoxStyle.DropDownList
    cmb.Margin = New Padding(3, 3, 20, 3)
    cmb.Tag = "Mass analyzer type"
    cmb.TabIndex = 2 * Number + 1
    cmb.Items.Add(String.Empty)
    cmb.Items.AddRange(AnalyzerTypes)
    cmb.Width = 60
    cmb.SelectedItem = _analyzer
    Return cmb
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim cmb As ComboBox = DirectCast(ctr, ComboBox)
    If cmb.SelectedIndex = 0 Then
      err.SetError(ctr, "Mass analyzer type is required")
      Return False
    Else
      err.SetError(ctr, String.Empty)
      Return True
    End If
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    _analyzer = CStr(DirectCast(ctr, ComboBox).SelectedItem)
  End Sub

  Private Class CIComparer(Of T)
    Implements IEqualityComparer(Of T)

    Public Function Equals1(x As T, y As T) As Boolean Implements IEqualityComparer(Of T).Equals
      Return CaseInsensitiveComparer.Default.Compare(x, y) = 0
    End Function

    Public Function GetHashCode1(obj As T) As Integer Implements IEqualityComparer(Of T).GetHashCode
      Return obj.ToString().ToLower().GetHashCode()
    End Function
  End Class
End Class


Public Class PolarityFilter
  Inherits Filter


  Friend Const cName As String = "polarity"

  Private _polarity As String = String.Empty

  Public Shared PolarityTypes() As String = New String() {"positive", "negative"}

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property

  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 2 Then Throw New Exception()
    If Arguments(1) = "+" Then Arguments(1) = "positive" ' synonims checking
    If Arguments(1) = "-" Then Arguments(1) = "negative"
    Polarity = Arguments(1)
  End Sub


  Public Property Polarity As String
    Get
      Return _polarity
    End Get
    Set(ByVal value As String)
      value = value.ToLower()
      If (Not String.IsNullOrWhiteSpace(value)) AndAlso Not PolarityTypes.Contains(value) Then Throw New Exception()
      _polarity = value
    End Set
  End Property


  Public Overrides Function ToString() As String
    Return cName & " " & _polarity
  End Function

  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.Text = "Polarity"
    lbl.TabIndex = 2 * Number
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim cmb As ComboBox = New ComboBox()
    cmb.DropDownStyle = ComboBoxStyle.DropDownList
    cmb.Margin = New Padding(3, 3, 20, 3)
    cmb.Tag = "Scan polarity"
    cmb.TabIndex = 2 * Number + 1
    cmb.Items.Add(String.Empty)
    cmb.Items.AddRange(PolarityTypes)
    cmb.Width = 60
    cmb.SelectedItem = _polarity
    Return cmb
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim cmb As ComboBox = DirectCast(ctr, ComboBox)
    If cmb.SelectedIndex = 0 Then
      err.SetError(ctr, "Scan polarity is required")
      Return False
    Else
      err.SetError(ctr, String.Empty)
      Return True
    End If
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    _polarity = CStr(DirectCast(ctr, ComboBox).SelectedItem)
  End Sub
End Class


Public Class ETDFilter
  Inherits Filter

  Friend Const cName As String = "ETDFilter"

  Public Property RemovePrecursor As Boolean = True
  Public Property RemoveChargeReduced As Boolean = True
  Public Property RemoveNeutralLoss As Boolean = True
  Public Property BlanketRemoval As Boolean = True

  Public Property MatchingTolerance As Double = 3.1

  Private _unit As String = "MZ"

  Public Shared ToleranceUnits() As String = New String() {"PPM", "MZ"}

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Protected Overrides Sub Load(ByVal Arguments() As String)
    Dim Phase As Integer = 0
    Dim iArg As Integer = 1
    Dim b As Boolean
    If Arguments.Length > 7 Then Throw New Exception()
    Do While iArg < Arguments.Length
      Select Case Phase
        Case 0
          If Boolean.TryParse(Arguments(iArg), b) Then
            Select Case iArg
              Case 1
                RemovePrecursor = b
              Case 2
                RemoveChargeReduced = b
              Case 3
                RemoveNeutralLoss = b
              Case 4
                BlanketRemoval = b
                Phase = 1
            End Select
            iArg += 1
          Else
            Phase = 1
          End If
        Case 1
          If Double.TryParse(Arguments(iArg), _MatchingTolerance) Then
            iArg += 1
            Phase = 2
          Else
            Throw New Exception()
          End If
        Case 2
          Unit = Arguments(iArg)
          iArg += 1
          Phase = 3
          If Arguments.Length > iArg Then Throw New Exception()
      End Select
    Loop
    If Phase = 2 Then Throw New Exception()
  End Sub


  Public Property Unit As String
    Get
      Return _unit
    End Get
    Set(ByVal value As String)
      value = value.ToUpper()
      If Not ToleranceUnits.Contains(value) Then Throw New Exception()
      _unit = value
    End Set
  End Property


  Public Overrides Function ToString() As String
    Dim str As String = String.Empty
    If Not BlanketRemoval Then str = " false"
    If (Not RemoveNeutralLoss) Or Not String.IsNullOrEmpty(str) Then str = " " & RemoveNeutralLoss.ToString().ToLower() & str
    If (Not RemoveChargeReduced) Or Not String.IsNullOrEmpty(str) Then str = " " & RemoveChargeReduced.ToString().ToLower() & str
    If (Not RemovePrecursor) Or Not String.IsNullOrEmpty(str) Then str = " " & RemovePrecursor.ToString().ToLower() & str
    If MatchingTolerance <> 3.1 Or Unit <> "MZ" Then str &= " " & MatchingTolerance.ToString() & " " & Unit
    Return cName & str
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 3
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Filter options"
      Case 2 : lbl.Text = "Tolerance"
      Case 3 : lbl.Text = "Unit"
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
        Dim chk As CheckBox = New CheckBox()
        chk.TabIndex = 0
        chk.Size = New Size(150, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Remove precursor"
        chk.Tag = "Removes precursors"
        chk.Checked = RemovePrecursor
        pan.Controls.Add(chk)
        chk = New CheckBox()
        chk.TabIndex = 1
        chk.Size = New Size(150, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Remove charge reduced"
        chk.Tag = "Removes charge reduced"
        chk.Checked = RemoveChargeReduced
        pan.Controls.Add(chk)
        chk = New CheckBox()
        chk.TabIndex = 2
        chk.Size = New Size(150, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Remove neutral loss"
        chk.Tag = "Removes neutral loss"
        chk.Checked = RemoveNeutralLoss
        pan.Controls.Add(chk)
        chk = New CheckBox()
        chk.TabIndex = 3
        chk.Size = New Size(150, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Blanket removal"
        chk.Tag = "Removes blanket"
        chk.Checked = BlanketRemoval
        pan.Controls.Add(chk)
        Return pan
      Case 2
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 80
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Matching tolerance value, default is 3.1"
        txt.Text = MatchingTolerance.ToString()
        Return txt
      Case 3
        Dim cmb As ComboBox = New ComboBox()
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.Margin = New Padding(3, 3, 20, 3)
        cmb.Tag = "Matching tolerance unit, default is MZ"
        cmb.TabIndex = 2 * Number + 1
        cmb.Items.AddRange(ToleranceUnits)
        cmb.Width = 60
        cmb.SelectedItem = Unit
        Return cmb
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim d As Double
    If Number = 2 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If (Not String.IsNullOrWhiteSpace(txt.Text)) AndAlso Not Double.TryParse(txt.Text, d) Then
        err.SetError(ctr, "Invalid number format")
        Return False
      End If
      If d < 0 Then
        err.SetError(ctr, "Negative number is not allowed")
        Return False
      End If
    End If
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        RemovePrecursor = DirectCast(ctr.Controls(0), CheckBox).Checked
        RemoveChargeReduced = DirectCast(ctr.Controls(1), CheckBox).Checked
        RemoveNeutralLoss = DirectCast(ctr.Controls(2), CheckBox).Checked
        BlanketRemoval = DirectCast(ctr.Controls(3), CheckBox).Checked
      Case 2
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then MatchingTolerance = 3.1 _
          Else MatchingTolerance = Double.Parse(txt.Text)
      Case 3
        Unit = CStr(DirectCast(ctr, ComboBox).SelectedItem)
    End Select
  End Sub
End Class


Public Class ChargeStatePredictorFilter
  Inherits Filter

  Friend Const cName As String = "chargeStatePredictor"

  Public Property OverrideExistingCharge As Boolean = True

  Public Property MaxMultipleCharge As Integer = 3

  Public Property MinMultipleCharge As Integer = 2

  Public Property SingleChargeFractionTIC As Double = 0.9

  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 5 Then Throw New Exception()
    If Not Boolean.TryParse(Arguments(1), OverrideExistingCharge) Then Throw New Exception()
    If Not Integer.TryParse(Arguments(2), MaxMultipleCharge) Then Throw New Exception()
    If Not Integer.TryParse(Arguments(3), MinMultipleCharge) Then Throw New Exception()
    If Not Double.TryParse(Arguments(4), SingleChargeFractionTIC) Then Throw New Exception()
  End Sub


  Public Overrides Function ToString() As String
    Return String.Format("{0} {1} {2} {3} {4:f}", cName, OverrideExistingCharge.ToString().ToLower(), MaxMultipleCharge, MinMultipleCharge, _
                         SingleChargeFractionTIC)
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 4
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = ""
      Case 2 : lbl.Text = "Max. multiple charge"
      Case 3 : lbl.Text = "Min. multiple charge"
      Case 4 : lbl.Text = "Single charge fraction TIC"
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
      Select Number
      Case 1
        Dim chk As CheckBox = New CheckBox()
        chk.TabIndex = 2 * Number + 1
        chk.Size = New Size(150, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Override existing charge"
        chk.Tag = "Overrides spectra's existing charge state(s) with predicted ones"
        chk.Checked = OverrideExistingCharge
        Return chk
      Case 2
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 100
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Maximum multiple charge state to be predicted"
        txt.Text = MaxMultipleCharge.ToString()
        Return txt
      Case 3
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 100
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Minimum multiple charge state to be predicted"
        txt.Text = MinMultipleCharge.ToString()
        Return txt
      Case 4
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 130
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "When the %TIC below the precursor m/z is less than this value, the spectrum is predicted as singly charged"
        txt.Text = SingleChargeFractionTIC.ToString()
        Return txt
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim d As Double
    Dim i As Integer
    If Number = 2 Or Number = 3 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If String.IsNullOrWhiteSpace(txt.Text) Then
        err.SetError(ctr, "Integer value required")
        Return False
      End If
      If Not Integer.TryParse(txt.Text, i) Then
        err.SetError(ctr, "Invalid number format")
        Return False
      End If
      If i < 0 Then
        err.SetError(ctr, "Negative number is not allowed")
        Return False
      End If
    ElseIf Number = 4 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If String.IsNullOrWhiteSpace(txt.Text) Then
        err.SetError(ctr, "Fixed-point value required")
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
    End If
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        OverrideExistingCharge = DirectCast(ctr, CheckBox).Checked
      Case 2
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then MaxMultipleCharge = 3 _
          Else MaxMultipleCharge = Integer.Parse(txt.Text)
      Case 3
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then MinMultipleCharge = 2 _
          Else MinMultipleCharge = Integer.Parse(txt.Text)
      Case 4
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then SingleChargeFractionTIC = 0.9 _
          Else SingleChargeFractionTIC = Double.Parse(txt.Text)
    End Select
  End Sub
End Class


Public Class MS2DenoiseFilter
  Inherits Filter

  Friend Const cName As String = "MS2Denoise"

  Public Property NumPeaks As Integer = 6

  Public Property WindowWidth As Integer = 30

  Public Property MultichargeRelaxation As Boolean = True


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 4 Then Throw New Exception()
    If Not Integer.TryParse(Arguments(1), NumPeaks) Then Throw New Exception()
    If Not Integer.TryParse(Arguments(2), WindowWidth) Then Throw New Exception()
    If Not Boolean.TryParse(Arguments(3), MultichargeRelaxation) Then Throw New Exception()
  End Sub


  Public Overrides Function ToString() As String
    Return String.Format("{0} {1} {2} {3}", cName, NumPeaks, WindowWidth, MultichargeRelaxation.ToString().ToLower())
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 3
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Peaks to select in window"
      Case 2 : lbl.Text = "Window width"
      Case 3 : lbl.Text = ""
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Select Case Number
      Case 1
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 130
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Number of peaks to select in window"
        txt.Text = NumPeaks.ToString()
        Return txt
      Case 2
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 70
        txt.TextAlign = HorizontalAlignment.Right
        txt.Tag = "Window width"
        txt.Text = WindowWidth.ToString()
        Return txt
      Case 3
        Dim chk As CheckBox = New CheckBox()
        chk.TabIndex = 2 * Number + 1
        chk.Size = New Size(180, 18)
        chk.Margin = New Padding(0, 0, 10, 0)
        chk.Text = "Multicharge fragment relaxation"
        chk.Tag = "Multicharge fragment relaxation"
        chk.Checked = MultichargeRelaxation
        Return chk
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim d As Double
    Dim i As Integer
    If Number = 1 Or Number = 2 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If String.IsNullOrWhiteSpace(txt.Text) Then
        err.SetError(ctr, "Integer value required")
        Return False
      End If
      If Not Integer.TryParse(txt.Text, i) Then
        err.SetError(ctr, "Invalid number format")
        Return False
      End If
      If i < 0 Then
        err.SetError(ctr, "Negative number is not allowed")
        Return False
      End If
    End If
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then NumPeaks = 6 _
          Else NumPeaks = Integer.Parse(txt.Text)
      Case 2
        Dim txt As TextBox = DirectCast(ctr, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then WindowWidth = 30 _
          Else WindowWidth = Integer.Parse(txt.Text)
      Case 3
        MultichargeRelaxation = DirectCast(ctr, CheckBox).Checked
    End Select
  End Sub
End Class


Public Class TitleMakerFilter
  Inherits Filter

  Friend Const cName As String = "titleMaker"

  Public Property Title As String = "runID:<RunId>,index:<Index>,ID:<Id>,path:<SourcePath>,scan:<ScanNumber>," & _
                  "activation:<ActivationType>,isolation:<IsolationMz>,selectedIon:<SelectedIonMz>,z:<ChargeState>," & _
                  "precursorScan:<PrecursorSpectrumId>,spectrum:<SpectrumType>,MSlevel:<MsLevel>," & _
                  "scanstartmin:<ScanStartTimeInMinutes>,scanstartsec:<ScanStartTimeInSeconds>,BPmz:<BasePeakMz>," & _
                  "BPI:<BasePeakIntensity>,TIC:<TotalIonCurrent>"


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 2 Then Throw New Exception()
    Title = Arguments(1)
  End Sub


  Public Overrides Function ToString() As String
    Return String.Format("{0} {1}", cName, Title)
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Title"
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Select Case Number
      Case 1
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 450
        txt.Height = 80
        txt.Multiline = True
        txt.ScrollBars = ScrollBars.Vertical
        txt.Tag = "Add/replace spectrum title according to user-specified format string; the following keywords are recognized:" & ControlChars.CrLf & _
                  "<RunId> <Index> <Id> <SourcePath> <ScanNumber> <ActivationType> <IsolationMz> <SelectedIonMz> <ChargeState>" & ControlChars.CrLf & _
                  "<PrecursorSpectrumId> <SpectrumType> <MsLevel> <ScanStartTimeInMinutes> <ScanStartTimeInSeconds> <BasePeakMz> " & ControlChars.CrLf & _
                  "<BasePeakIntensity> <TotalIonCurrent>"
        txt.Text = Title
        Return txt
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    If Number = 1 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If String.IsNullOrWhiteSpace(txt.Text) Then
        err.SetError(ctr, "Spectrum title required")
        Return False
      End If
    End If
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        Title = DirectCast(ctr, TextBox).Text
    End Select
  End Sub
End Class


Public Class MzPrecursorsFilter
  Inherits Filter

  Friend Const cName As String = "mzPrecursors"

  Public Property Precursors As String 


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Protected Overrides Sub Load(ByVal Arguments() As String)
    If Arguments.Length <> 2 Then Throw New Exception()
    Precursors = Arguments(1)
  End Sub


  Public Overrides Function ToString() As String
    Return String.Format("{0} {1}", cName, Precursors)
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 1
  End Function

  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Select Case Number
      Case 1 : lbl.Text = "Precursors"
    End Select
    Return lbl
  End Function

  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Select Case Number
      Case 1
        Dim txt As TextBox = New TextBox()
        txt.Margin = New Padding(3, 3, 20, 3)
        txt.TabIndex = 2 * Number + 1
        txt.Width = 200
        txt.Tag = "Number of peaks to select in window"
        txt.Tag = "Precursor list mz1,mz2, ... mzn; zero for no precursor m/z"
        txt.Text = Precursors
        Return txt
      Case Else
        Return Nothing
    End Select
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    If Number = 1 Then
      Dim txt As TextBox = DirectCast(ctr, TextBox)
      If String.IsNullOrWhiteSpace(txt.Text) Then
        err.SetError(ctr, "Precursor list is required")
        Return False
      End If
    End If
    Return True
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Select Case Number
      Case 1
        Precursors = DirectCast(ctr, TextBox).Text
    End Select
  End Sub
End Class
