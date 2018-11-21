using System;
using System.ComponentModel;

namespace petShikongParser
{
	public class task
	{
		public string Type
		{
			get;
			set;
		}

		public string Num
		{
			get;
			set;
		}

		public string ID
		{
			get;
			set;
		}

		[DefaultValue(0)]
		public string inNum
		{
			get;
			set;
		}
	}
}
