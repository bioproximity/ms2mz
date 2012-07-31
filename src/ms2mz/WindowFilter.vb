Public MustInherit Class DWindowFilter
  Inherits Filter

  Protected dLowBound, dHighBound As Double


  Protected Overrides Sub Load(ByVal Arguments() As String)
    Dim m As Match
    Dim d As Double
    If Arguments.Length = 1 Then Throw New Exception()
    Dim str As String = String.Join(String.Empty, Arguments, 1, Arguments.Length - 1)
    Dim aMatches As MatchCollection = Regex.Matches(str, "\[(.+),(.+)\]")
    If aMatches.Count <> 1 Then Throw New Exception()
    m = aMatches(0)
    If m.Groups.Count <> 3 Then Throw New Exception()
    If Not Double.TryParse(m.Groups(1).Value, d) Then Throw New Exception()
    dLowBound = d
    If Not Double.TryParse(m.Groups(2).Value, d) Then Throw New Exception()
    dHighBound = d
  End Sub


  Public Overrides Function ToString() As String
    Return Name & " [" & dLowBound.ToString() & "," & dHighBound.ToString() & "]"
  End Function


  Public Overrides Function GetControlsNumber() As Integer
    Return 2
  End Function


  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = New Label()
    lbl.AutoSize = True
    lbl.TabIndex = 2 * Number
    Return lbl
  End Function


  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim txt As TextBox = New TextBox()
    txt.Margin = New Padding(3, 3, 20, 3)
    txt.TabIndex = 2 * Number + 1
    txt.Width = 80
    txt.TextAlign = HorizontalAlignment.Right
    If Number = 1 Then
      txt.Text = dLowBound.ToString()
    Else
      txt.Text = dHighBound.ToString()
    End If
    Return txt
  End Function


  Public Overrides Sub ReadValue(ByVal ctr As Control, ByVal Number As Integer)
    Dim d As Double = Double.Parse(DirectCast(ctr, TextBox).Text)
    If Number = 1 Then dLowBound = d Else dHighBound = d
  End Sub
End Class


Public Class ScanTimeFilter
  Inherits DWindowFilter


  Friend Const cName As String = "scanTime"

  Public Property ScanTimeLow As Double
    Get
      Return dLowBound
    End Get
    Set(ByVal value As Double)
      dLowBound = value
    End Set
  End Property

  Public Property ScanTimeHigh As Double
    Get
      Return dHighBound
    End Get
    Set(ByVal value As Double)
      dHighBound = value
    End Set
  End Property


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = DirectCast(MyBase.CreateLabel(Number), Label)
    If Number = 1 Then lbl.Text = "scanTimeLow" Else lbl.Text = "scanTimeHigh"
    Return lbl
  End Function


  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim txt As TextBox = DirectCast(MyBase.CreateControl(Number), TextBox)
    If Number = 1 Then
      txt.Tag = "Scan time lower bound, e.g. 5, 0.2, 34.7"
    Else
      txt.Tag = "Scan time upper bound, e.g. 7, .8, 11.23"
    End If
    Return txt
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim d As Double
    Dim txt As TextBox = DirectCast(ctr, TextBox)
    If String.IsNullOrWhiteSpace(txt.Text) Then
      err.SetError(ctr, "Scan time is required")
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
  End Function
End Class


Public Class MzWindowFilter
  Inherits DWindowFilter


  Friend Const cName As String = "mzWindow"

  Public Property mzLow As Double
    Get
      Return dLowBound
    End Get
    Set(ByVal value As Double)
      dLowBound = value
    End Set
  End Property

  Public Property mzHigh As Double
    Get
      Return dHighBound
    End Get
    Set(ByVal value As Double)
      dHighBound = value
    End Set
  End Property


  Public Overrides ReadOnly Property Name As String
    Get
      Return cName
    End Get
  End Property


  Public Overrides Function CreateLabel(ByVal Number As Integer) As Control
    Dim lbl As Label = DirectCast(MyBase.CreateLabel(Number), Label)
    If Number = 1 Then lbl.Text = "mzLow" Else lbl.Text = "mzHigh"
    Return lbl
  End Function


  Public Overrides Function CreateControl(ByVal Number As Integer) As Control
    Dim txt As TextBox = DirectCast(MyBase.CreateControl(Number), TextBox)
    If Number = 1 Then
      txt.Tag = "Mz window lower bound, e.g. 8, 21.3, 1e3"
    Else
      txt.Tag = "Mz window upper bound, e.g. 11, .4, 1e4"
    End If
    Return txt
  End Function


  Public Overrides Function ValidateControl(ByVal ctr As Control, ByVal Number As Integer, ByVal err As ErrorProvider) As Boolean
    Dim d As Double
    Dim txt As TextBox = DirectCast(ctr, TextBox)
    If String.IsNullOrWhiteSpace(txt.Text) Then
      err.SetError(ctr, "Mz value is required")
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
  End Function
End Class
