using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace petShikongParser
{
	public class 宠物信息
	{
		public string 指定五行;

		public string 抵消;

		public string 加深;

		public string 吸魔;

		public string 吸血;

		public bool 地狱之门;

		public string 自定义宠物名字;

		public bool 宠物素材
		{
			get;
			set;
		}

		public bool 是否水平翻转
		{
			get;
			set;
		}

		public string 宠物序号
		{
			get;
			set;
		}

		public string 形象
		{
			get;
			set;
		}

		public string 当前经验
		{
			get;
			set;
		}

		public string 等级
		{
			get
			{
				bool flag = this.宠物序号 == null;
				string result;
				if (flag)
				{
					result = this.当前经验;
				}
				else
				{
					result = new 数据处理().取等级(Convert.ToInt64(this.当前经验)).ToString();
				}
				return result;
			}
			set
			{
			}
		}

		public string 五行
		{
			get
			{
				bool flag = this.地狱之门;
				string result;
				if (flag)
				{
					result = "魔";
				}
				else
				{
					bool flag2 = this.宠物序号 != null;
					if (flag2)
					{
						bool flag3 = this.指定五行 != null;
						if (flag3)
						{
							result = this.指定五行;
						}
						else
						{
							result = new 数据处理().取指定宠物类型(this.形象).系别;
						}
					}
					else
					{
						bool flag4 = this.指定五行 != null;
						if (flag4)
						{
							result = this.指定五行;
						}
						else
						{
							result = new 数据处理().取怪物五行(this.形象);
						}
					}
				}
				return result;
			}
			set
			{
			}
		}

		[DefaultValue(10)]
		public string 生命
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 魔法
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 最大生命
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 最大魔法
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 攻击
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 防御
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 闪避
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 速度
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 状态
		{
			get;
			set;
		}

		[DefaultValue(0)]
		public string 被抽取
		{
			get;
			set;
		}

		[DefaultValue(0)]
		public string 已转化总额
		{
			get;
			set;
		}

		public string 宠物名字
		{
			get
			{
				bool flag = this.宠物序号 != null;
				string result;
				if (flag)
				{
					bool flag2 = this.自定义宠物名字 != null;
					if (flag2)
					{
						result = this.自定义宠物名字;
					}
					else
					{
						result = new 数据处理().取指定宠物类型(this.形象).宠物名字;
					}
				}
				else
				{
					bool flag3 = this.地狱之门;
					if (flag3)
					{
						result = "魔化的" + new 数据处理().取怪物名字(this.形象);
					}
					else
					{
						bool flag4 = this.自定义宠物名字 != null;
						if (flag4)
						{
							result = this.自定义宠物名字;
						}
						else
						{
							result = new 数据处理().取怪物名字(this.形象);
						}
					}
				}
				return result;
			}
			set
			{
			}
		}

		public string 位置
		{
			get;
			set;
		}

		public string 成长
		{
			get;
			set;
		}

		[DefaultValue(10)]
		public string 命中
		{
			get;
			set;
		}

		public string 已进化次数
		{
			get;
			set;
		}

		[DefaultValue("")]
		public string 技能列表
		{
			get;
			set;
		}

		public string 技能显示
		{
			get
			{
				bool flag = this.技能列表 != null;
				string result;
				if (flag)
				{
					string text = "";
					foreach (技能信息 current in this.信息)
					{
						bool flag2 = current.信息 != null;
						if (flag2)
						{
							text = string.Concat(new string[]
							{
								text,
								",",
								current.信息.技能名字,
								"|",
								current.技能等级,
								"|",
								current.技能序号,
								"|",
								current.信息.耗蓝量,
								"|",
								current.信息.BUFF
							});
						}
					}
					result = text;
				}
				else
				{
					result = "";
				}
				return result;
			}
			set
			{
			}
		}

		public List<技能信息> 信息
		{
			get
			{
				bool flag = this.技能列表 != null && this.技能列表.Length > 0;
				List<技能信息> result;
				if (flag)
				{
					string[] array = this.技能列表.Split(new char[]
					{
						','
					});
					List<技能信息> list = new List<技能信息>();
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						string[] array3 = text.Split(new char[]
						{
							'|'
						});
						bool flag2 = array3.Length >= 2;
						if (flag2)
						{
							list.Add(new 技能信息
							{
								技能等级 = array3[2],
								技能序号 = array3[1]
							});
						}
					}
					result = list;
				}
				else
				{
					result = new List<技能信息>();
				}
				return result;
			}
			set
			{
			}
		}
	}
}
