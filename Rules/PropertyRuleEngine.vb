Public Class PropertyRuleEngine
	Implements IPropertyRuleEngineInterface
	Private mXMLDocument As Xml.XmlDocument
	Private mType As System.String

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
		mType = Type.ToString
		mXMLDocument = New Xml.XmlDocument
		mXMLDocument.LoadXml(My.Resources.ResourceManager.GetString(Type.ToString))
	End Sub

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: New
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	' INPUTS		: XMLDocument	System.Xml.XmlDocument	
	' RETURNS		: System.Void		Short description of output
	'///////////////////////////////////////////////////////////////////////////////
	Public Sub New(ByVal XMLDocument As Xml.XmlDocument)
		mXMLDocument = XMLDocument
		mType = mXMLDocument.Name
	End Sub

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: ToolTip
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Property ToolTip(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.ToolTip

		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/ToolTip").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/ToolTip").ChildNodes.Item(0).Value = value
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: Required
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Property Required(ByVal PropertyName As String) As Boolean Implements IPropertyRuleEngineInterface.Required
		Get
			Return CBool(mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/Required").ChildNodes.Item(0).Value)
		End Get
		Set(ByVal value As Boolean)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/Required").ChildNodes.Item(0).Value = value.ToString
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: MaxLength
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Property MaxLength(ByVal PropertyName As String) As Integer Implements IPropertyRuleEngineInterface.MaxLength
		Get
			Return CInt(mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MaxLength").ChildNodes.Item(0).Value)
		End Get
		Set(ByVal value As Integer)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MaxLength").ChildNodes.Item(0).Value = value.ToString
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property
	Public Property MinLength(ByVal PropertyName As String) As Integer Implements IPropertyRuleEngineInterface.MinLength
		Get
			Return CInt(mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MinLength").ChildNodes.Item(0).Value)
		End Get
		Set(ByVal value As Integer)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MinLength").ChildNodes.Item(0).Value = value.ToString
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: MaxValue
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Property MaxValue(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.MaxValue
		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MaxValue").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MaxValue").ChildNodes.Item(0).Value = value
			mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property
	Public Property MinValue(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.MinValue
		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MinValue").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/MinValue").ChildNodes.Item(0).Value = value
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: DefaultText
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////	
	Public Property DefaultText(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.DefaultText
		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/DefaultText").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/DefaultText").ChildNodes.Item(0).Value = value
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	Public Property Mask(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.Mask
		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/Mask").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/Mask").ChildNodes.Item(0).Value = value
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: RegularExpressionType
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public Property RegularExpressionType(ByVal PropertyName As String) As String Implements IPropertyRuleEngineInterface.RegularExpressionType
		Get
			Return mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/RegularExpressionType").ChildNodes.Item(0).Value
		End Get
		Set(ByVal value As String)
			mXMLDocument.SelectSingleNode("/" + mType + "/Property[@Name =""" + PropertyName + """]/Definition/RegularExpressionType").ChildNodes.Item(0).Value = value
			'mXMLDocument.Save("RulesDirectory/" + mType + ".xml")
		End Set
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: Rules
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public ReadOnly Property Rules(ByVal PropertyName As String) As Xml.XmlNodeList Implements IPropertyRuleEngineInterface.Rules
		Get
			Return mXMLDocument.SelectNodes("/" + mType + "/Property[@Name =""" + PropertyName + """]/Rules/Rule")
		End Get
	End Property

	'///////////////////////////////////////////////////////////////////////////////
	' NAME			: Properties
	' AUTHOR		: Parag J. (paragj@smartcomtech.com)
	' CREATED		: 11/22/2004
	' DESCRIPTION	: Short description of this method.
	' NOTES			: 
	'///////////////////////////////////////////////////////////////////////////////
	Public ReadOnly Property Properties() As Xml.XmlNodeList Implements IPropertyRuleEngineInterface.Properties
		Get
			Return mXMLDocument.SelectNodes("/" + mType + "/Property")
		End Get
	End Property
End Class
