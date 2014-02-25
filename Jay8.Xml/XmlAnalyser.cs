using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Jay8.Xml
{
	public class XmlAnalyser
	{
	
		private string _xmlFileName;
		private XDocument _xDocument;
		private XmlObject _entity;

		public XmlAnalyser (string xmlFileName)
		{
			_xmlFileName = xmlFileName;

			_xDocument = XDocument.Load(_xmlFileName);
			using(IEnumerator<XElement> iterator = _xDocument.Root.Elements().GetEnumerator())
			{
				iterator.MoveNext();
				_entity = new XmlObject(iterator.Current);
			}
		}

		public XmlObject Entity
		{
			get 
			{
				return _entity;
			}
		}
	}
}

