using NUnit.Framework;
using System;
using System.IO;

namespace Jay8.Xml
{
	[TestFixture ()]
	public class Test
	{
		private XmlAnalyser xmlAnalyser;

		[SetUp ()]
		public void Setup ()
		{

		}

		[TearDown ()]
		public void TearDown ()
		{
			xmlAnalyser = null;
		}

		[Test ()]
		public void TestValidCategory ()
		{
			xmlAnalyser = new XmlAnalyser(string.Format("{0}/{1}/{2}", Directory.GetCurrentDirectory (), "Xml", "Category.xml"));
			Assert.AreEqual ("Category", xmlAnalyser.Entity.Name);
			Assert.AreEqual ("category", xmlAnalyser.Entity.RealName);
			Assert.AreEqual (2, xmlAnalyser.Entity.GetPropertyNames ().Count);
			Assert.AreEqual ("Name", xmlAnalyser.Entity.GetPropertyNames()[0]);
			Assert.AreEqual ("Id", xmlAnalyser.Entity.GetPropertyNames()[1]);
			Assert.AreEqual (2, xmlAnalyser.Entity.GetProperties ().Count);
			XmlString stringObj1 = (XmlString)xmlAnalyser.Entity.GetProperties () [0];
			Assert.AreEqual ("Name", stringObj1.Name);
			Assert.AreEqual ("name", stringObj1.RealName);
			Assert.AreEqual ("Category 1", stringObj1.Value);
			XmlString stringObj2 = (XmlString)xmlAnalyser.Entity.GetProperties () [1];
			Assert.AreEqual ("Id", stringObj2.Name);
			Assert.AreEqual ("id", stringObj2.RealName);
			Assert.AreEqual ("category1", stringObj2.Value);
		}

		[Test ()]
		[ExpectedException("System.Xml.XmlException")]
		public void TestInvalidCategoryXml ()
		{
			xmlAnalyser = new XmlAnalyser(string.Format("{0}/{1}/{2}", Directory.GetCurrentDirectory (), "Xml", "CategoryBroken.xml"));
			Assert.IsNull (xmlAnalyser.Entity);
		}
	}
}

