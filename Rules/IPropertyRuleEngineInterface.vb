Friend Interface IPropertyRuleEngineInterface
	Property ToolTip(ByVal PropertyName As String) As String
	Property Required(ByVal PropertyName As String) As Boolean
	Property MaxLength(ByVal PropertyName As String) As Integer
	Property MinLength(ByVal PropertyName As String) As Integer
	Property MaxValue(ByVal PropertyName As String) As String
	Property MinValue(ByVal PropertyName As String) As String
	Property DefaultText(ByVal PropertyName As String) As String
	Property Mask(ByVal PropertyName As String) As String
	Property RegularExpressionType(ByVal PropertyName As String) As String
	ReadOnly Property Rules(ByVal PropertyName As String) As Xml.XmlNodeList
	ReadOnly Property Properties() As Xml.XmlNodeList
End Interface