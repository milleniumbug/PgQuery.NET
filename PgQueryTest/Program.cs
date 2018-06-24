using System;
using System.Text;
using PgQueryLib.Native;

namespace PgQueryTest
{
	class Program
	{
		static unsafe string StringFromUTF8NTS(byte* input)
		{
			int len = 0;
			byte* it = input;
			while(*it++ != 0) ++len;
			return Encoding.UTF8.GetString(input, len);
		}

		static unsafe void Main(string[] args)
		{
			string s = "SELECT * FROM lol;";
			fixed (byte* b = Encoding.UTF8.GetBytes(s))
			{
				PgQueryParseResult res = default;
				try
				{
					res = PgQuery.Parse(b);
					Console.WriteLine(StringFromUTF8NTS(res.parse_tree));
				}
				finally
				{
					PgQuery.FreeParse(res);
				}
			}
		}
	}
}
