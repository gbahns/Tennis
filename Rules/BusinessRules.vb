Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Collections.Generic
'Imports CSLA.Data

Public Module RulesFactory
	Private log As ILog = LogManager.GetLogger(GetType(RulesFactory).ToString())

	<Serializable()> _
	Public Structure ComplexRule
		Public Name As String
		Public Expression As String
		Public Description As String
		Public Sub New(ByVal name As String, ByVal expression As String, ByVal description As String)
			Me.Name = name
			Me.Expression = expression
			Me.Description = description
		End Sub
		Public Function Evaluate(ByVal [Me] As Object) As Boolean
            Try
                Return False
                'todo: get the ExpressionEvaluator over here
                'Return DAV.Library.ExpressionEvaluator.Evaluate([Me], Expression)
            Catch ex As Microsoft.JScript.JScriptException
                log.Error(String.Format("Rule evaluation failed (Me='{0}', Expression='{1}')", [Me], Expression), ex)
                'eat the exception after logging it; otherwise it's caught by databinding, which eats it anyway
                'Throw
            End Try
		End Function
	End Structure

	'called by BusinessBase to load rules for the class the first time they are needed
	'Loader property must be set by by the application code prior to any business objects
	'attempting to load their business rules.
	Public Function GetBusinessRules(ByVal className As String) As IBusinessRules
		log.Debug(String.Format("GetBusinessRules({0})", className))

		If _Loader Is Nothing Then
			Throw New InvalidOperationException("BusinessRules.Loader must be set before calling LoadBusinessRules")
		End If

		If _BusinessRules Is Nothing Then
			_BusinessRules = New System.Collections.Generic.Dictionary(Of String, IBusinessRules)
		End If

		'see if rules for this class have already been loaded
		'note that we search for the key once to see if it's there, and again
		'to actually retrieve the rule.  This is because an exception is
		'thrown if we request the item and it's not found, even though the
		'documention for Dictionary says it will just return nothing.
		If _BusinessRules.ContainsKey(className) Then
			Return _BusinessRules(className)
		End If

		'if rules have not already been loaded, load them now
		Dim rules As IBusinessRules = _Loader.Invoke(className)
		_BusinessRules(className) = rules
		Return rules
	End Function

	Public Delegate Function BusinessRulesLoader(ByVal className As String) As IBusinessRules

	Private _Loader As BusinessRulesLoader

	Public Property Loader() As BusinessRulesLoader
		Get
			Return _Loader
		End Get
		Set(ByVal value As BusinessRulesLoader)
			_Loader = value
		End Set
	End Property

	'cached business rules are stored as a collection of rule collections indexed by class name
	Private _BusinessRules As System.Collections.Generic.Dictionary(Of String, IBusinessRules)

	Private _EmptyComplexRules As New List(Of ComplexRule)
	Public ReadOnly Property EmptyComplexRules() As List(Of ComplexRule)
		Get
			Return _EmptyComplexRules
		End Get
	End Property


End Module

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Interface IReadWriteBusinessRules
	'validation
	Property Required(ByVal propertyName As String) As Boolean
	Property MaxLength(ByVal propertyName As String) As Integer
	Property MinValue(ByVal propertyName As String) As String
	Property MaxValue(ByVal propertyName As String) As String
	Property Mask(ByVal propertyName As String) As String
	Property RegularExpression(ByVal propertyName As String) As String
	ReadOnly Property ComplexRules(ByVal propertyName As String) As List(Of ComplexRule)
	'UI strings
	Property DefaultText(ByVal propertyName As String) As String
	Property LabelText(ByVal propertyName As String) As String
	Property Tooltip(ByVal propertyName As String) As String
End Interface

Public Interface IReadOnlyBusinessRules
	'validation
	ReadOnly Property Required(ByVal propertyName As String) As Boolean
	ReadOnly Property MaxLength(ByVal propertyName As String) As Integer
	ReadOnly Property MinValue(ByVal propertyName As String) As String
	ReadOnly Property MaxValue(ByVal propertyName As String) As String
	ReadOnly Property MinValueInt(ByVal propertyName As String) As Integer
	ReadOnly Property MaxValueInt(ByVal propertyName As String) As Integer
	ReadOnly Property Mask(ByVal propertyName As String) As String
	ReadOnly Property RegularExpression(ByVal propertyName As String) As String
	ReadOnly Property ComplexRules(ByVal propertyName As String) As List(Of ComplexRule)
	ReadOnly Property Properties() As Dictionary(Of String, List(Of ComplexRule)).KeyCollection
	'UI strings
	ReadOnly Property DefaultText(ByVal propertyName As String) As String
	ReadOnly Property LabelText(ByVal propertyName As String) As String
	ReadOnly Property Tooltip(ByVal propertyName As String) As String
End Interface

Public Interface IBusinessRules
	Inherits IReadWriteBusinessRules
	Inherits IReadOnlyBusinessRules
End Interface

<Serializable()> _
Public Class EmptyBusinessRules
	Implements IBusinessRules

#Region " IReadWriteBusinessRules"

	Public ReadOnly Property ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadWriteBusinessRules.ComplexRules
		Get
			Return EmptyComplexRules
		End Get
	End Property

	Public Property LabelText(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.LabelText
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property MaxLength(ByVal propertyName As String) As Integer Implements IReadWriteBusinessRules.MaxLength
		Get
			Return Integer.MaxValue
		End Get
		Set(ByVal value As Integer)

		End Set
	End Property

	Public Property MaxValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MaxValue
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property MinValue(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.MinValue
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property Required(ByVal propertyName As String) As Boolean Implements IReadWriteBusinessRules.Required
		Get
			Return False
		End Get
		Set(ByVal value As Boolean)

		End Set
	End Property

	Public Property Tooltip(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.Tooltip
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property Mask(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.Mask
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property RegularExpression(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.RegularExpression
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

	Public Property DefaultText(ByVal propertyName As String) As String Implements IReadWriteBusinessRules.DefaultText
		Get
			Return ""
		End Get
		Set(ByVal value As String)

		End Set
	End Property

#End Region

#Region " IReadOnlyBusinessRules"
	Public ReadOnly Property ReadOnly_ComplexRules(ByVal propertyName As String) As List(Of ComplexRule) Implements IReadOnlyBusinessRules.ComplexRules
		Get
			Return ComplexRules(propertyName)
		End Get
	End Property

	Public ReadOnly Property Properties() As Dictionary(Of String, List(Of ComplexRule)).KeyCollection Implements IReadOnlyBusinessRules.Properties
		Get
			Throw New NotSupportedException("EmptyBusinessRules does not support the Properties property")
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

	Public ReadOnly Property ReadOnly_Mask(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.Mask
		Get
			Return Mask(propertyName)
		End Get
	End Property

	Public ReadOnly Property ReadOnly_DefaultText(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.DefaultText
		Get
			Return DefaultText(propertyName)
		End Get
	End Property

	Public ReadOnly Property ReadOnly_RegularExpression(ByVal propertyName As String) As String Implements IReadOnlyBusinessRules.RegularExpression
		Get
			Return RegularExpression(propertyName)
		End Get
	End Property

#End Region

End Class


