Imports DAV.Library.ExpressionEvaluator
Public Class ReadOnlyPropertyRuleEngine
	Inherits PropertyRuleEngine
	Implements IReadOnlyPropertyRuleEngineInterface
	Private mPropertyErrorString As New System.Collections.Specialized.NameValueCollection

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: New
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	' INPUTS		: Type	System.Type	
	' RETURNS		: System.Void		Short description of output
	'///////////////////////////////////////////////////////////////////////////////
	Public Sub New(ByVal Type As System.Type)
		MyBase.New(Type)
	End Sub

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: ToolTip
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Overloads ReadOnly Property ToolTip(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.ToolTip
		Get
			Return MyBase.ToolTip(PropertyName)
		End Get
	End Property

	Public Overloads ReadOnly Property Required(ByVal PropertyName As String) As Boolean Implements IReadOnlyPropertyRuleEngineInterface.Required
		Get
			Return MyBase.Required(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: MaxLength
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Overloads ReadOnly Property MaxLength(ByVal PropertyName As String) As Integer Implements IReadOnlyPropertyRuleEngineInterface.MaxLength
		Get
			Return MyBase.MaxLength(PropertyName)
		End Get
	End Property
	Public Overloads ReadOnly Property MinLength(ByVal PropertyName As String) As Integer Implements IReadOnlyPropertyRuleEngineInterface.MinLength
		Get
			Return MyBase.MinLength(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: MaxValue
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Overloads ReadOnly Property MaxValue(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.MaxValue
		Get
			Return MyBase.MaxValue(PropertyName)
		End Get
	End Property
	Public Overloads ReadOnly Property MinValue(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.MinValue
		Get
			Return MyBase.MinValue(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: DefaultText
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Overloads ReadOnly Property DefaultText(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.DefaultText
		Get
			Return MyBase.DefaultText(PropertyName)
		End Get
	End Property

	Public Overloads ReadOnly Property Mask(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.Mask
		Get
			Return MyBase.Mask(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: RegularExpressionType
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Overloads ReadOnly Property RegularExpressionType(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.RegularExpressionType
		Get
			Return MyBase.RegularExpressionType(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: Rules
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Overloads ReadOnly Property Rules(ByVal PropertyName As String) As Xml.XmlNodeList Implements IReadOnlyPropertyRuleEngineInterface.Rules
		Get
			Return MyBase.Rules(PropertyName)
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: Properties
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Overloads ReadOnly Property Properties() As Xml.XmlNodeList Implements IReadOnlyPropertyRuleEngineInterface.Properties
		Get
			Return MyBase.Properties()
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: PropertyErrorString
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public ReadOnly Property PropertyErrorString(ByVal PropertyName As String) As String Implements IReadOnlyPropertyRuleEngineInterface.PropertyErrorString
		Get
			If mPropertyErrorString.Item(PropertyName) Is Nothing Then
				Return String.Empty
			Else
				Return mPropertyErrorString.Item(PropertyName)
			End If
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: CheckRule
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	' INPUTS		: oObject	Object	
	'				  PropertyName	String	
	' RETURNS		: Boolean		Short description of output
	'///////////////////////////////////////////////////////////////////////////////
	Public Function CheckRule(ByVal oObject As Object, ByVal PropertyName As String) As Boolean Implements IReadOnlyPropertyRuleEngineInterface.CheckRule
		'Check the rules for the property
		Dim xmlNodeList As Xml.XmlNodeList
		Dim Counter As Integer
		Dim Result As Boolean = True
		Dim ExpressionEvaluator As New DAV.Library.ExpressionEvaluator
		If mPropertyErrorString.Item(PropertyName) Is Nothing Then
			mPropertyErrorString.Add(PropertyName, String.Empty)
		Else
			mPropertyErrorString.Item(PropertyName) = String.Empty
		End If

		xmlNodeList = MyBase.Rules(PropertyName)
		For Counter = 0 To xmlNodeList.Count - 1
			'Check rules one by one and set/append the error if rule fails
			If CType(ExpressionEvaluator.Evaluate(oObject, Replace(xmlNodeList.Item(Counter).Attributes("Expression").Value, "LessThan", " < ")), Boolean) = False Then
				'Rule Failed. Add to error collection
				mPropertyErrorString.Item(PropertyName) = mPropertyErrorString.Item(PropertyName) + xmlNodeList.Item(Counter).Attributes("ErrorMessage").Value + vbCrLf
				Result = False
			End If
		Next
		Return Result
	End Function

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: CheckRules
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	' INPUTS		: oObject	Object	
	' RETURNS		: Boolean		Short description of output
	'///////////////////////////////////////////////////////////////////////////////
	Public Function CheckRules(ByVal oObject As Object) As Boolean Implements IReadOnlyPropertyRuleEngineInterface.CheckRules
		'Check the rules for all the properties in the object
		Dim xmlPropertyNodeList As Xml.XmlNodeList
		Dim xmlNodeList As Xml.XmlNodeList
		Dim PropertyCounter As Integer
		Dim RuleCounter As Integer
		Dim Result As Boolean = True
		Dim ExpressionEvaluator As New DAV.Library.ExpressionEvaluator
		xmlPropertyNodeList = MyBase.Properties
		For PropertyCounter = 0 To xmlPropertyNodeList.Count - 1
			If mPropertyErrorString.Item(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value) Is Nothing Then
				mPropertyErrorString.Add(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value, String.Empty)
			Else
				mPropertyErrorString.Item(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value) = String.Empty
			End If

			xmlNodeList = MyBase.Rules(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value)
			For RuleCounter = 0 To xmlNodeList.Count - 1
				'Check rules one by one and set/append the error if rule fails
				If CType(ExpressionEvaluator.Evaluate(oObject, Replace(xmlNodeList.Item(RuleCounter).Attributes("Expression").Value, "LessThan", " < ")), Boolean) = False Then
					'Rule Failed. Add to error collection
					mPropertyErrorString.Item(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value) = mPropertyErrorString.Item(xmlPropertyNodeList.Item(PropertyCounter).Attributes("Name").Value) + xmlNodeList.Item(RuleCounter).Attributes("ErrorMessage").Value + vbCrLf
					Result = False
				End If
			Next
		Next
		Return Result
	End Function
End Class
