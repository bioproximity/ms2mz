Public Class ConfigurationSet

  Public Enum OutputFormats
    mzML
    mzXML
    mz5
    mgf
    text
    ms2
    cms2
  End Enum

  Private _Filters As Collection(Of Filter) = New Collection(Of Filter)


  Public Property OutputFormat As OutputFormats = OutputFormats.mzML

  Public Property BinaryPrecision64bit As Boolean = True
  Public Property MzValuesPrecision64bit As Boolean = True
  Public Property IntensityValuesPrecision64bit As Boolean

  Public Property NoIndex As Boolean
  Public Property Zlib As Boolean
  Public Property Gzip As Boolean
  Public Property Merge As Boolean
  Public Property Verbose As Boolean = True

  Public Property OutputPath As String
  Public Property ContactFile As String

  Public ReadOnly Property Filters As Collection(Of Filter)
    Get
      Return _Filters
    End Get
  End Property


  Public Shared ReadOnly Property OutputFormatList() As IEnumerable
    Get
      Static FormatList() As KeyValuePair(Of OutputFormats, String) = New KeyValuePair(Of OutputFormats, String)() { _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.mzML, "mzML"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.mzXML, "mzXML"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.mz5, "mz5"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.mgf, "mgf"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.text, "text"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.ms2, "ms2"), _
             New KeyValuePair(Of OutputFormats, String)(OutputFormats.cms2, "cms2")}
      Return FormatList
    End Get
  End Property


  Public Function ToArguments() As String
    Dim str As StringBuilder = New StringBuilder()
    If OutputFormat <> OutputFormats.mzML Then _
      str.Append(" --" & DirectCast(OutputFormatList(CInt(OutputFormat)), KeyValuePair(Of OutputFormats, String)).Value)
    If Not String.IsNullOrWhiteSpace(OutputPath) Then str.Append(" -o """ & OutputPath & """")
    If Not BinaryPrecision64bit Then str.Append(" --32")
    If Not MzValuesPrecision64bit Then str.Append(" --mz32")
    If IntensityValuesPrecision64bit Then str.Append(" --inten64")
    If NoIndex Then str.Append(" --noindex")
    If Zlib Then str.Append(" -z")
    If Gzip Then str.Append(" -g")
    If Merge Then str.Append(" --merge")
    If Verbose Then str.Append(" -v")
    If Not String.IsNullOrWhiteSpace(ContactFile) Then str.Append(" -i """ & ContactFile & """")
    For Each f As Filter In Filters
      str.Append(" --filter """ & f.ToString() & """")
    Next

    Return str.ToString()
  End Function


  Public Sub ToFile(ByVal writer As TextWriter)
    If OutputFormat <> OutputFormats.mzML Then _
      writer.WriteLine(DirectCast(OutputFormatList(CInt(OutputFormat)), KeyValuePair(Of OutputFormats, String)).Value & "=true")
    If Not String.IsNullOrWhiteSpace(OutputPath) Then writer.WriteLine("outdir=""" & OutputPath & """")
    If Not BinaryPrecision64bit Then writer.WriteLine("32=true")
    If Not MzValuesPrecision64bit Then writer.WriteLine("mz32=true")
    If IntensityValuesPrecision64bit Then writer.WriteLine("inten64=true")
    If NoIndex Then writer.WriteLine("noindex=true")
    If Zlib Then writer.WriteLine("zlib=true")
    If Gzip Then writer.WriteLine("gzip=true")
    If Merge Then writer.WriteLine("merge=true")
    If Verbose Then writer.WriteLine("verbose=true")
    If Not String.IsNullOrWhiteSpace(ContactFile) Then writer.WriteLine("contactInfo=""" & ContactFile & """")
    For Each f As Filter In Filters
      writer.WriteLine("Filter=""" & f.ToString() & """")
    Next
  End Sub


  Public Shared Function Load(ByVal reader As StreamReader) As ConfigurationSet
    Const cstrInvalidFormat As String = "Invalid file format at line "
    Dim config As ConfigurationSet = New ConfigurationSet()
    Dim str, strOption, strValue As String
    Dim iLineCount, i As Integer
    Dim f As Filter = Nothing

    config.Verbose = False
    Do While Not reader.EndOfStream
      iLineCount += 1
      str = reader.ReadLine()
      If String.IsNullOrWhiteSpace(str) Then Continue Do
      i = str.IndexOf("="c)
      If i = -1 Then Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
      strOption = str.Substring(0, i)
      strValue = str.Substring(i + 1)
      Select Case strOption.ToUpper()
        Case DirectCast(OutputFormatList(CInt(OutputFormats.mzML)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() <> "TRUE" Then Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.mzXML)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.mzXML _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.mz5)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.mz5 _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.mgf)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.mgf _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.text)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.text _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.ms2)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.ms2 _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case DirectCast(OutputFormatList(CInt(OutputFormats.cms2)), KeyValuePair(Of OutputFormats, String)).Value.ToUpper()
          If strValue.ToUpper() = "TRUE" Then config.OutputFormat = OutputFormats.cms2 _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())

        Case "64"
          If strValue.ToUpper() <> "TRUE" Then Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "32"
          If strValue.ToUpper() = "TRUE" Then config.BinaryPrecision64bit = False _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "MZ64"
          If strValue.ToUpper() <> "TRUE" Then Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "MZ32"
          If strValue.ToUpper() = "TRUE" Then config.MzValuesPrecision64bit = False _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "INTEN32"
          If strValue.ToUpper() <> "TRUE" Then Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "INTEN64"
          If strValue.ToUpper() = "TRUE" Then config.IntensityValuesPrecision64bit = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())

        Case "NOINDEX"
          If strValue.ToUpper() = "TRUE" Then config.NoIndex = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "ZLIB"
          If strValue.ToUpper() = "TRUE" Then config.Zlib = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "GZIP"
          If strValue.ToUpper() = "TRUE" Then config.Gzip = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "MERGE"
          If strValue.ToUpper() = "TRUE" Then config.Merge = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
        Case "VERBOSE"
          If strValue.ToUpper() = "TRUE" Then config.Verbose = True _
            Else Throw New Exception(cstrInvalidFormat & iLineCount.ToString())

        Case "OUTDIR"
          config.OutputPath = strValue.Trim(""""c)
        Case "CONTACTINFO"
          config.ContactFile = strValue.Trim(""""c)

        Case "FILTER"
          If Filter.TryParse(strValue.Trim(""""c), f) Then
            config.Filters.Add(f)
          Else
            Throw New Exception(cstrInvalidFormat & iLineCount.ToString())
          End If
      End Select
    Loop
    Return config
  End Function
End Class
