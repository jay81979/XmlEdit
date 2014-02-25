using System;

namespace Jay8.Xml.Util
{
	public class StringUtil
	{
		public static string CapitalizeWord(string word)
		{
			if (string.IsNullOrEmpty(word))
			{
				return string.Empty;
			}
			word = word.ToLower ();
			return char.ToUpper(word[0]) + word.Substring(1);
		}
	}
}

