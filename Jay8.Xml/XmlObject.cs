using System;
using System.Xml.Linq;
using System.Collections.Generic;
using Jay8.Xml.Util;

namespace Jay8.Xml
{
	public class XmlObject:XmlBase
	{
		public XmlObject (XElement element)
			:base (element)
		{
			_properties = new Dictionary<string, XmlBase> ();
			ExtractData (element);
		}

		private Dictionary<string, XmlBase> _properties;

		public List<string> GetPropertyNames()
		{
			List<string> propertyNames = new List<string> ();
			foreach (string propertyName in _properties.Keys) {
				propertyNames.Add (propertyName);
			}
			return propertyNames;
		}

		public List<XmlBase> GetProperties()
		{
			List<XmlBase> properties = new List<XmlBase> ();
			foreach (XmlBase property in _properties.Values) {
				properties.Add (property);
			}
			return properties;
		}

		private void ExtractData(XElement element)
		{
			foreach (XElement childElement in element.Elements()) 
			{
				if (!childElement.HasElements && !childElement.HasAttributes) 
				{
					_properties [StringUtil.CapitalizeWord (childElement.Name.LocalName)] = new XmlString (childElement);
				} 
				if (childElement.HasElements) 
				{
					_properties [StringUtil.CapitalizeWord (childElement.Name.LocalName)] = new XmlObject (childElement);
				}
			}
			if (element.HasAttributes) 
			{
				foreach(XAttribute attribute in element.Attributes())
				{
					_properties [StringUtil.CapitalizeWord (attribute.Name.LocalName)] = new XmlString (attribute);
				}
			}
		}
			
	}
}

