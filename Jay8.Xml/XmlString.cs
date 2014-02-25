using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using Jay8.Xml.Util;

namespace Jay8.Xml
{
	public class XmlString:XmlBase
	{
		public XmlString (XObject obj)
			:base (obj)
		{
			if (obj is XElement) 
			{
				_value = ((XElement)obj).Value;
			} 
			else if (obj is XAttribute) 
			{
				_value = ((XAttribute)obj).Value;
			}
		}

		private string _value;

		public string Value
		{
			get 
			{
				return _value;
			}
		}
	}
}

