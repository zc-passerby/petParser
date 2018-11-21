using System;

namespace petShikongParser
{
	public class 道具信息
	{
		public string 道具类型ID
		{
			get;
			set;
		}

		public string 道具序号
		{
			get;
			set;
		}

		public string 道具数量
		{
			get;
			set;
		}

		public string 道具名字
		{
			get
			{
				return new 数据处理().取道具名字(this.道具类型ID);
			}
			set
			{
			}
		}

		public string 道具图标
		{
			get
			{
				return new 数据处理().取道具图标(this.道具类型ID);
			}
			set
			{
			}
		}

		public string 道具位置
		{
			get;
			set;
		}

		public string 道具价格
		{
			get
			{
				return new 数据处理().取道具价格(this.道具类型ID);
			}
			set
			{
			}
		}
	}
}
