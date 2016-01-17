Imports System.Collections.Generic
Imports System.Collections.Specialized

Namespace Flat
	<Serializable()> _
	Public Class BusinessRules
		Implements IBusinessRules

		Private Structure BusinessRuleInfo
			Public MaxLength As Integer
			Public Required As Boolean
			Public Tooltip As String
			Public LabelText As String
			Public MinValue As String
			Public MaxValue As String
			Public ComplexRules As List(Of ComplexRule)
			Public Mask As String
			Public RegularExpression As String
			Public DefaultText As String
		End Structure

		Private _BusinessRules As New Dictionary(Of String, BusinessRuleInfo)

		Public ReadOnly Property ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadWriteBusinessRules.ComplexRules
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).ComplexRules
				Else
					Return EmptyComplexRules
				End If
			End Get
		End Property

		Public ReadOnly Property Properties() As Dictionary(Of String, List(Of ComplexRule)).KeyCollection Implements IReadOnlyBusinessRules.Properties
			Get
				Throw New NotSupportedException("BusinessRules.Flat.BusinessRules does not support the Properties property")
			End Get
		End Property

		Public Property LabelText(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.LabelText
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).LabelText
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property MaxLength(ByVal propertyName As String) As Integer Implements IReadWriteBusinessRules.MaxLength
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).MaxLength
				Else
					Return Integer.MaxValue
				End If
			End Get
			Set(ByVal value As Integer)

			End Set
		End Property

		Public Property MaxValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MaxValue
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).MaxValue
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property MinValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MinValue
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).MaxValue
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property Required(ByVal propertyName As String) As Boolean Implements IReadWriteBusinessRules.Required
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).Required
				Else
					Return False
				End If
			End Get
			Set(ByVal value As Boolean)

			End Set
		End Property

		Public Property Tooltip(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.Tooltip
			Get
				If _BusinessRules.ContainsKey(propertyName) Then
					Return _BusinessRules(propertyName).Tooltip
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property Mask(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.Mask
			Get
				If _BusinessRules.ContainsKey(PropertyName) Then
					Return _BusinessRules(PropertyName).Mask
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property RegularExpression(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.RegularExpression
			Get
				If _BusinessRules.ContainsKey(PropertyName) Then
					Return _BusinessRules(PropertyName).RegularExpression
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

		Public Property DefaultText(ByVal PropertyName As String) As String Implements IReadWriteBusinessRules.DefaultText
			Get
				If _BusinessRules.ContainsKey(PropertyName) Then
					Return _BusinessRules(PropertyName).DefaultText
				Else
					Return ""
				End If
			End Get
			Set(ByVal value As String)

			End Set
		End Property

#Region " IReadOnlyBusinessRules"
		Public ReadOnly Property ReadOnly_ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadOnlyBusinessRules.ComplexRules
			Get
				Return ComplexRules(propertyName)
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
