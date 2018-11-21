using System;

namespace petShikongParser
{
	public class 进化路线
	{
		public string petID
		{
			get;
			set;
		}

		public string AI
		{
			get;
			set;
		}

		public string BI
		{
			get;
			set;
		}

		public string AP
		{
			get;
			set;
		}

		public string BP
		{
			get;
			set;
		}

		public string ALV
		{
			get;
			set;
		}

		public string BLV
		{
			get;
			set;
		}

		public string AN
		{
			get
			{
				bool flag = this.AI == null || this.AI.Equals("-1");
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					result = new 数据处理().取指定宠物类型(this.AI).宠物名字;
				}
				return result;
			}
			set
			{
			}
		}

		public string BN
		{
			get
			{
				bool flag = this.BI == null || this.BI.Equals("-1");
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					result = new 数据处理().取指定宠物类型(this.BI).宠物名字;
				}
				return result;
			}
			set
			{
			}
		}

		public string APN
		{
			get
			{
				bool flag = this.AP == null;
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					result = new 数据处理().取指定道具类型(this.AP).道具名字;
				}
				return result;
			}
			set
			{
			}
		}

		public string BPN
		{
			get
			{
				bool flag = this.BP == null;
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					result = new 数据处理().取指定道具类型(this.BP).道具名字;
				}
				return result;
			}
			set
			{
			}
		}

		public string PN
		{
			get
			{
				bool flag = this.petID == null;
				string result;
				if (flag)
				{
					result = "";
				}
				else
				{
					result = new 数据处理().取指定宠物类型(this.petID).宠物名字;
				}
				return result;
			}
			set
			{
			}
		}
	}
}
