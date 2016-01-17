Imports System.Collections.Generic
Imports System.Collections.Specialized

Namespace Dynamic
	<Serializable()> _
	Public Class BusinessRules
		Implements IBusinessRules

#Region " Private Data"
		Private _MaxLengths As New Dictionary(Of String, Integer)
		Private _RequiredFields As New Dictionary(Of String, Boolean)
		Private _ToolTips As New Dictionary(Of String, String)
		Private _LabelText As New Dictionary(Of String, String)
		Private _MinValues As New Dictionary(Of String, String)
		Private _MaxValues As New Dictionary(Of String, String)
		Private _DefaultTexts As New Dictionary(Of String, String)
		Private _Masks As New Dictionary(Of String, String)
		Private _RegularExpressions As New Dictionary(Of String, String)
		Private _ComplexRules As New Dictionary(Of String, List(Of ComplexRule))
#End Region

#Region " System.Object Overrides "
		Public Overrides Function ToString() As String
			Dim s As New System.Text.StringBuilder
			For Each pair As KeyValuePair(Of String, Integer) In _MaxLengths
				s.AppendFormat("{0}.MaxLength = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			For Each pair As KeyValuePair(Of String, Boolean) In _RequiredFields
				s.AppendFormat("{0}.Required = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			For Each pair As KeyValuePair(Of String, String) In _ToolTips
				s.AppendFormat("{0}.Tooltip = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			For Each pair As KeyValuePair(Of String, String) In _LabelText
				s.AppendFormat("{0}.LabelText = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			For Each pair As KeyValuePair(Of String, String) In _MinValues
				s.AppendFormat("{0}.MinValue = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			For Each pair As KeyValuePair(Of String, List(Of ComplexRule)) In _ComplexRules
				s.AppendFormat("{0}.ComplexRules = {1}", pair.Key, pair.Value)
				s.AppendLine()
			Next
			Return s.ToString
		End Function
#End Region

#Region " IReadWriteBusinessRules"
		Public Property MaxLength(ByVal propertyName As String) As Integer Implements IReadWriteBusinessRules.MaxLength
			Get
				If _MaxLengths.ContainsKey(propertyName) Then
					Return _MaxLengths(propertyName)
				Else
					Return Integer.MaxValue
				End If
			End Get
			Set(ByVal value As Integer)
				If value > 0 Then
					_MaxLengths(propertyName) = value
				Else
					_MaxLengths.Remove(propertyName)
				End If
			End Set
		End Property

		Public Property Required(ByVal propertyName As String) As Boolean Implements IReadWriteBusinessRules.Required
			Get
				If _RequiredFields.ContainsKey(propertyName) Then
					Return _RequiredFields(propertyName)
				Else
					Return False
				End If
			End Get
			Set(ByVal value As Boolean)
				If value Then
					_RequiredFields(propertyName) = value
				Else
					_RequiredFields.Remove(propertyName)
				End If
			End Set
		End Property

		Public Property Tooltip(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.Tooltip
			Get
				If _ToolTips.ContainsKey(propertyName) Then
					Return _ToolTips(propertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_ToolTips(propertyName) = value
				Else
					_ToolTips.Remove(propertyName)
				End If
			End Set
		End Property

		Public Property LabelText(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.LabelText
			Get
				If _LabelText.ContainsKey(propertyName) Then
					Return _LabelText(propertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_LabelText(propertyName) = value
				Else
					_LabelText.Remove(propertyName)
				End If
			End Set
		End Property

		Public Property MinValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MinValue
			Get
				If _MinValues.ContainsKey(propertyName) Then
					Return _MinValues(propertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_MinValues(propertyName) = value
				Else
					_MinValues.Remove(propertyName)
				End If
			End Set
		End Property

		Public Property MaxValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MaxValue
			Get
				If _MaxValues.ContainsKey(propertyName) Then
					Return _MaxValues(propertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_MaxValues(propertyName) = value
				Else
					_MaxValues.Remove(propertyName)
				End If
			End Set
		End Property

		'the read/write version of ComplexRules will automatically add a new list of complex rules if not there already
		Public ReadOnly Property ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadWriteBusinessRules.ComplexRules
			Get
				If Not _ComplexRules.ContainsKey(propertyName) Then
					_ComplexRules.Add(propertyName, New List(Of ComplexRule))
				End If
				Return _ComplexRules(propertyName)
			End Get
		End Property

		Public Property Mask(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.Mask
			Get
				If _Masks.ContainsKey(PropertyName) Then
					Return _Masks(PropertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_Masks(PropertyName) = value
				Else
					_Masks.Remove(PropertyName)
				End If
			End Set
		End Property

		Public Property RegularExpression(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.RegularExpression
			Get
				If _RegularExpressions.ContainsKey(PropertyName) Then
					Return _RegularExpressions(PropertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_RegularExpressions(PropertyName) = value
				Else
					_RegularExpressions.Remove(PropertyName)
				End If
			End Set
		End Property

		Public Property DefaultText(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.DefaultText
			Get
				If _DefaultTexts.ContainsKey(PropertyName) Then
					Return _DefaultTexts(PropertyName)
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)
				If value.Length > 0 Then
					_DefaultTexts(PropertyName) = value
				Else
					_DefaultTexts.Remove(PropertyName)
				End If
			End Set
		End Property
#End Region

#Region " IReadOnlyBusinessRules"
		Public ReadOnly Property ReadOnly_ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadOnlyBusinessRules.ComplexRules
			Get
				'the read-only version of ComplexRules will return EmptyComplexRules if none are found
				If _ComplexRules.ContainsKey(propertyName) Then
					Return _ComplexRules(propertyName)
				Else
					Return EmptyComplexRules
				End If
			End Get
		End Property

		Public ReadOnly Property Properties() As Dictionary(Of String, List(Of ComplexRule)).KeyCollection Implements IReadOnlyBusinessRules.Properties
			Get
				Return _ComplexRules.Keys
			End Get
		End Property


		Public ReadOnly Property ReadOnly_LabelText(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.LabelText
			Get
				Return LabelText(propertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_MaxLength(ByVal propertyName As String) As Integer Implements IReadOnlyBusinessRules.MaxLength
			Get
				Return MaxLength(propertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_MaxValue(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.MaxValue
			Get
				Return MaxValue(propertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_MinValue(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.MinValue
			Get
				Return MinValue(propertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_MaxValueInt(ByVal propertyName As String) As Integer Implements IReadOnlyBusinessRules.MaxValueInt
			Get
				Dim value As Int32
				If Int32.TryParse(MaxValue(propertyName), value) Then Return value
				Return Integer.MaxValue
			End Get
		End Property

		Public ReadOnly Property ReadOnly_MinValueInt(ByVal propertyName As String) As Integer Implements IReadOnlyBusinessRules.MinValueInt
			Get
				Dim value As Int32
				If Int32.TryParse(MinValue(propertyName), value) Then Return value
				Return Integer.MinValue
			End Get
		End Property

		Public ReadOnly Property ReadOnly_Required(ByVal propertyName As String) As Boolean Implements IReadOnlyBusinessRules.Required
			Get
				Return Required(propertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_Tooltip(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.Tooltip
			Get
				Return Tooltip(propertyName)
			End Get
		End Property

		'todo: implement Mask property
		Public ReadOnly Property ReadOnly_Mask(ByVal PropertyName As String) As String Implements IReadOnlyBusinessRules.Mask
			Get
				Return Mask(PropertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_DefaultText(ByVal PropertyName As String) As String Implements IReadOnlyBusinessRules.DefaultText
			Get
				Return DefaultText(PropertyName)
			End Get
		End Property

		Public ReadOnly Property ReadOnly_RegularExpression(ByVal PropertyName As String) As String Implements IReadOnlyBusinessRules.RegularExpression
			Get
				Return RegularExpression(PropertyName)
			End Get
		End Property

#End Region

	End Class

End Namespace
