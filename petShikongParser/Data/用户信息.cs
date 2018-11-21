using System;
using System.ComponentModel;
using System.Linq;

namespace petShikongParser
{
	public class 用户信息
	{
		[DefaultValue(10)]
		public string 金币
		{
			get;
			set;
		}

		public string 名字
		{
			get;
			set;
		}

		public string 仓库容量
		{
			get;
			set;
		}

		public string 战斗时间
		{
			get;
			set;
		}

		public string 创世礼包领取
		{
			get;
			set;
		}

		public string 每日礼包
		{
			get;
			set;
		}

		public string a
		{
			get;
			set;
		}

		public string 宠物1
		{
			get;
			set;
		}

		public string 宠物2
		{
			get;
			set;
		}

		public string 宠物3
		{
			get;
			set;
		}

		public string 主宠物
		{
			get;
			set;
		}

		public string 元宝
		{
			get;
			set;
		}

		public string 刷怪数
		{
			get;
			set;
		}

		public string 已抽取cc
		{
			get;
			set;
		}

		public string 积分道具购买量
		{
			get;
			set;
		}

		public string b
		{
			get;
			set;
		}

		public string c
		{
			get;
			set;
		}

		public string 时之券
		{
			get;
			set;
		}

		public string vip
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 水晶
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 积分
		{
			get;
			set;
		}

		public string 自动战斗次数
		{
			get;
			set;
		}

		public string 地狱层数
		{
			get;
			set;
		}

		public string 宠物数量
		{
			get
			{
				return 数据处理._宠物列表.Count<宠物信息>().ToString();
			}
			set
			{
			}
		}

		public string 主宠名字
		{
			get
			{
				bool flag = this.主宠物 == null;
				string result;
				if (flag)
				{
					result = null;
				}
				else
				{
					宠物信息 宠物信息 = new 数据处理().读取指定宠物(this.主宠物, 数据处理._宠物列表);
					bool flag2 = 宠物信息 == null;
					if (flag2)
					{
						result = null;
					}
					else
					{
						string 宠物名字 = 宠物信息.宠物名字;
						result = 宠物名字;
					}
				}
				return result;
			}
			set
			{
			}
		}
	}
}
