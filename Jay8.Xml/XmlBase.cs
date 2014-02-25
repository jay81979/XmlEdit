using System;
using System.Xml;
using System.Xml.Linq;
using Jay8.Xml.Util;


namespace Jay8.Xml
{
	public abstract class XmlBase
	{
		public XmlBase (XObject obj)
		{
			if (obj is XElement) 
			{
				_realName = ((XElement)obj).Name.LocalName;
			} 
			else if (obj is XAttribute) 
			{
				_realName = ((XAttribute)obj).Name.LocalName;
			}
			_name = StringUtil.CapitalizeWord (_realName);
		}

		private string _name;
		private string _realName;

		public string Name
		{
			get 
			{
				return _name;
			}
		}

		public string RealName
		{
			get 
			{
				return _realName;
			}
		}

	}
}

