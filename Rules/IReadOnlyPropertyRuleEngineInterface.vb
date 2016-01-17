Friend Interface IReadOnlyPropertyRuleEngineInterface
	Inherits IPropertyRuleEngineInterface
	Shadows ReadOnly Property ToolTip(ByVal PropertyName As String) As String
	Shadows ReadOnly Property Required(ByVal PropertyName As String) As Boolean
	Shadows ReadOnly Property MaxLength(ByVal PropertyName As String) As Integer
	Shadows ReadOnly Property MinLength(ByVal PropertyName As String) As Integer
	Shadows ReadOnly Property MaxValue(ByVal PropertyName As String) As String
	Shadows ReadOnly Property MinValue(ByVal PropertyName As String) As String
	Shadows ReadOnly Property DefaultText(ByVal PropertyName As String) As String
	Shadows ReadOnly Property Mask(ByVal PropertyName As String) As String
	Shadows ReadOnly Property RegularExpressionType(ByVal PropertyName As String) As String
	Shadows ReadOnly Property Rules(ByVal PropertyName As String) As Xml.XmlNodeList
	Shadows ReadOnly Property Properties() As Xml.XmlNodeList
	ReadOnly Property PropertyErrorString(ByVal PropertyName As String) As String
	Function CheckRule(ByVal oObject As Object, ByVal PropertyName As String) As Boolean
	Function CheckRules(ByVal oObject As Object) As Boolean
End Interface
