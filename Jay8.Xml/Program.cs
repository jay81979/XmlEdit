using System;
using System.IO;

namespace Jay8.Xml
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			XmlAnalyser xmlAnalyser = new XmlAnalyser(string.Format("{0}/{1}/{2}", Directory.GetCurrentDirectory (), "Xml", "CategoryBroken.xml"));
		}
	}
}
