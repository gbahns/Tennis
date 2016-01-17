using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace Bahns.Util
{
	public static class ConfigManager
	{
		public static string BaseFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
		public static string SubFolder = "Config";

		private static void LogSetting(XmlDocument config)
		{
			XmlNode node = config.SelectSingleNode("/configuration/connectionStrings/add[@name='SfgLogging']/@connectionString");
			Console.WriteLine(node != null ? node.InnerXml : "");
		}

		private static string WithSlash(string folder)
		{
			return string.IsNullOrEmpty(folder) ? "" : 
				(folder[folder.Length - 1] == '\\') ? folder : folder + "\\";
		}

		private static string GetConfigFilePath(string name)
		{
			return string.Format("{0}{1}{2}.config", 
				WithSlash(BaseFolder),
				WithSlash(SubFolder),
				name);
		}


		private static XmlDocument GetConfig(string name)
		{
			string path = GetConfigFilePath(name);

			if (!System.IO.File.Exists(path))
				return null;

			XmlDocument xml = new XmlDocument();
			xml.Load(path);
			return xml;
		}

		/// <summary>
		/// 1. read default.config into XmlDocument
		/// 2. read environment.config and apply
		///    a. look for dev.config
		///    b. look for test.config
		///    c. look for prod.config
		///    d. use the first one found, ignore the others
		/// 3. read machinename.config and apply
		/// 4. read instance.config and apply
		/// 5. write resulting XmlDocument out to app.exe.config or web.config
		/// </summary>
		//<xsl:transform version="1.0" 
		//  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
		//  <xsl:template match="/">
		//    <Container>
		//      <xsl:copy-of select="document('product.xml')"/>
		//      <xsl:copy-of select="document('material.xml')"/>        
		//    </Container>
		//  </xsl:template>
		//</xsl:stylesheet>
		public static void MergeConfigFiles()
		{
			MergeConfigFiles(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
		}

		public static void MergeConfigFiles(string outputFile)
		{
				XmlDocument config = GetConfig("main");
				if (config == null)
					throw new FileNotFoundException("Main configuration file not found.", GetConfigFilePath("main"));

				config.PreserveWhitespace = true;
				LogSetting(config);

				XmlNode node = config.SelectSingleNode("/configuration/configMerge");
				ProcessGroupNode(config, node, false);

				node.ParentNode.RemoveChild(node);

				config.Save(outputFile);
				Console.WriteLine();
				Console.WriteLine(config.InnerXml);
		}

		#region Helpers to process merge files specified in main.config
		static string AttrValue(XmlNode node, string attrName)
		{
			XmlAttribute attr = node.Attributes[attrName];
			return attr != null ? attr.Value : "";
		}

		static bool ProcessFileNode(XmlDocument config, XmlNode node)
		{
			if (node == null)
				return false;

			switch (AttrValue(node, "type"))
			{
				case "machine": return MergeConfig(config, Environment.MachineName);
				case "group": return ProcessGroupNode(config, node, true);
				default: return MergeConfig(config, AttrValue(node, "name"));
			}
		}

		static bool ProcessGroupNode(XmlDocument config, XmlNode group, bool firstOnly)
		{
			if (group == null)
				return false;

			XmlNodeList nodes = group.SelectNodes("file");
			foreach (XmlNode node in nodes)
			{
				if (ProcessFileNode(config, node) && firstOnly)
					return true;
			}
			return false;
		}

		private static bool MergeConfig(XmlDocument config, string mergeName)
		{
			XmlDocument merge = GetConfig(mergeName);
			if (merge == null)
			{
				Console.WriteLine("{0} not merged", mergeName);
				return false;
			}

			MergeConfig(config, merge);
			Console.WriteLine("{0} merged", mergeName);
			LogSetting(config);
			return true;
		}

		private static void MergeConfig(XmlDocument config, XmlDocument merge)
		{
			UpdateExistingElementsAndAttribs(merge.ChildNodes, config);
		}
		#endregion

		#region XML Merge Implementation
		/// <summary>
		/// Merge element and attribute values from one xml doc to another.
		/// </summary>
		/// <param name="fromXdoc"></param>
		/// <param name="toXdoc"></param>
		/// <remarks>
		/// Multiple same-named peer elements, are merged in the ordinal order they appear.
		/// </remarks>
		private static void UpdateExistingElementsAndAttribs(XmlNodeList fromNodes, XmlNode toParentNode)
		{
			int iSameElement = 0;
			XmlNode lastElement = null;
			foreach (XmlNode node in fromNodes)
			{
				if (node.NodeType != XmlNodeType.Element)
				{
					continue;
				}

				if (lastElement != null
						&& node.Name == lastElement.Name && node.NamespaceURI == lastElement.NamespaceURI)
				{
					iSameElement++;
				}
				else
				{
					iSameElement = 0;
				}
				lastElement = node;

				XmlNode toNode;
				if (node.Attributes["key"] != null)
				{
					toNode = SelectSingleNodeMatchingNamespaceURI(toParentNode, node, node.Attributes["key"]);
				}
				else if (node.Attributes["name"] != null)
				{
					toNode = SelectSingleNodeMatchingNamespaceURI(toParentNode, node, node.Attributes["name"]);
				}
				else if (node.Attributes["type"] != null)
				{
					toNode = SelectSingleNodeMatchingNamespaceURI(toParentNode, node, node.Attributes["type"]);
				}
				else
				{
					toNode = SelectSingleNodeMatchingNamespaceURI(toParentNode, node, iSameElement);
				}

				if (toNode == null)
				{
					if (node == null)
					{
						throw new ApplicationException("node == null");
					}
					if (node.Name == null)
					{
						throw new ApplicationException("node.Name == null");
					}
					if (toParentNode == null)
					{
						throw new ApplicationException("toParentNode == null");
					}
					if (toParentNode.OwnerDocument == null)
					{
						throw new ApplicationException("toParentNode.OwnerDocument == null");
					}

					Debug.WriteLine("app: " + toParentNode.Name + "/" + node.Name);
					if (node.ParentNode.Name != toParentNode.Name)
					{
						throw new ApplicationException("node.ParentNode.Name != toParentNode.Name: " + node.ParentNode.Name + " !=" + toParentNode.Name);
					}
					try
					{
						toNode = toParentNode.AppendChild(toParentNode.OwnerDocument.CreateElement(node.Name));
					}
					catch (Exception ex)
					{
						throw new ApplicationException("ex during toNode = toParentNode.AppendChild(: " + ex.Message);
					}
				}

				//Copy element content if any
				XmlNode textEl = GetTextElement(node);
				if (textEl != null)
				{
					toNode.InnerText = textEl.InnerText;
				}

				//Copy attribs if any
				foreach (XmlAttribute attrib in node.Attributes)
				{
					XmlAttribute toAttrib = toNode.Attributes[attrib.Name];
					if (toAttrib == null)
					{
						Debug.WriteLine("attr: " + toNode.Name + "@" + attrib.Name);
						toAttrib = toNode.Attributes.Append(toNode.OwnerDocument.CreateAttribute(attrib.Name));
					}
					toAttrib.InnerText = attrib.InnerText;
				}
				((XmlElement)toNode).IsEmpty = !toNode.HasChildNodes; //Ensure no endtag when not needed
				UpdateExistingElementsAndAttribs(node.ChildNodes, toNode);
			}
		}

		private static XmlNode GetTextElement(XmlNode node)
		{
			foreach (XmlNode subNode in node.ChildNodes)
			{
				if (subNode.NodeType == XmlNodeType.Text)
				{
					return subNode;
				}
			}

			return null;
		}

		private static XmlNode SelectSingleNodeMatchingNamespaceURI(XmlNode node, XmlNode nodeName)
		{
			return SelectSingleNodeMatchingNamespaceURI(node, nodeName, null);
		}

		private static XmlNode SelectSingleNodeMatchingNamespaceURI(XmlNode node, XmlNode nodeName, int iSameElement)
		{
			return SelectSingleNodeMatchingNamespaceURI(node, nodeName, null, iSameElement);
		}

		private static XmlNode SelectSingleNodeMatchingNamespaceURI(XmlNode node, XmlNode nodeName, XmlAttribute keyAttrib)
		{
			return SelectSingleNodeMatchingNamespaceURI(node, nodeName, keyAttrib, 0); //, null);
		}

		private static Regex _typeParsePattern = new Regex(@"([^,]+),");

		private static XmlNode SelectSingleNodeMatchingNamespaceURI(XmlNode node, XmlNode nodeName, XmlAttribute keyAttrib, int iSameElement)
		{
			XmlNode matchNode = null;
			int iNodeNameElements = 0 - 1;
			foreach (XmlNode subNode in node.ChildNodes)
			{
				if (subNode.Name != nodeName.Name || subNode.NamespaceURI != nodeName.NamespaceURI)
				{
					continue;
				}

				iNodeNameElements++;

				if (keyAttrib == null)
				{
					if (iNodeNameElements == iSameElement)
					{
						return subNode;
					}
					else
					{
						continue;
					}
				}

				if (subNode.Attributes[keyAttrib.Name] != null &&
						subNode.Attributes[keyAttrib.Name].InnerText == keyAttrib.InnerText)
				{
					matchNode = subNode;
				}
				else if (keyAttrib != null
						&& keyAttrib.Name == "type")
				{
					Match subNodeMatch = _typeParsePattern.Match(subNode.Attributes[keyAttrib.Name].InnerText);
					Match keyAttribMatch = _typeParsePattern.Match(keyAttrib.InnerText);
					if (subNodeMatch.Success && keyAttribMatch.Success
							&& subNodeMatch.Result("$1") == keyAttribMatch.Result("$1"))
					{
						matchNode = subNode; //Have type class match (ignoring assembly-name suffix)
					}
				}
			}

			return matchNode; //return last match if > 1
		}
		#endregion
	}

}
