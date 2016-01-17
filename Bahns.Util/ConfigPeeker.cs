using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

public static class ConfigPeeker
{
	private static XmlDocument config = new XmlDocument();

	static ConfigPeeker()
	{
		config.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
	}

	public static XmlNode Node(string xpath)
	{
		return config.SelectSingleNode(xpath);
	}

	public static XmlNodeList Nodes(string xpath)
	{
		return config.SelectNodes(xpath);
	}

	public static string Value(string xpath)
	{
		XmlNode node = Node(xpath);
		return node != null ? node.InnerXml : "";
	}

	/// <summary>
	/// Converts the value to a dictionary.  The entries must be delimited
	/// by semi-colons, key and value must be delimiated by an equals sign.
	/// For example: "key1=value1;key2=value2;key3=value3;"
	/// The final semi-colon is optional.
	/// </summary>
	/// <param name="xpath"></param>
	/// <returns></returns>
	public static Dictionary<string, string> ValueAsDict(string xpath)
	{
		string[] entries = Value(xpath).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		Dictionary<string, string> dict = new Dictionary<string, string>();
		foreach (string entry in entries)
		{
			string[] keyvalue = entry.Split('=');
			dict[keyvalue[0]] = keyvalue[1];
		}
		return dict;
	}

	public static string Value(string xpath, string key)
	{
		Dictionary<string, string> dict = ValueAsDict(xpath);
		if (dict.ContainsKey(key))
			return dict[key];
		return "";
	}

	public static string DbServerAndName(string xpath)
	{
		Dictionary<string, string> dbSettings = ConfigPeeker.ValueAsDict(xpath);

		if (dbSettings.Count == 0)
			return "";

		string server = dbSettings["Server"];
		if (server == "")
			server = dbSettings["Data Source"];

		string name = dbSettings["Database"];
		if (name == "")
			name = dbSettings["Initial Catalog"];

		return server + "\\" + name;
	}
}
