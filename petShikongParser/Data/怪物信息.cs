using System;

namespace petShikongParser
{
	public class 怪物信息
	{
		public string 怪物名字
		{
			get;
			set;
		}

		public string 序号
		{
			get;
			set;
		}

		public string 掉落道具
		{
			get;
			set;
		}

		public string 怪物成长
		{
			get;
			set;
		}

		public string 怪物五行
		{
			get
			{
				return new 数据处理().取怪物五行(this.序号);
			}
			set
			{
			}
		}

		public string 最大等级
		{
			get;
			set;
		}

		public string 最小等级
		{
			get;
			set;
		}

		public string 最大掉落
		{
			get;
			set;
		}

		public string 经验值
		{
			get;
			set;
		}
	}
}
