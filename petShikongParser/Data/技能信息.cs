using System;

namespace petShikongParser
{
	public class 技能信息
	{
		public string 技能序号
		{
			get;
			set;
		}

		public string 技能等级
		{
			get;
			set;
		}

		public 技能配置 信息
		{
			get
			{
				return new 数据处理().取指定技能配置(this.技能序号);
			}
			set
			{
			}
		}
	}
}
