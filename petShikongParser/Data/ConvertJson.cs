using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace petShikongParser
{
	public class ConvertJson
	{
		public string getMallsJSON(List<商店道具信息> 道具)
		{
			string text = "[";
			foreach (商店道具信息 current in 道具)
			{
				text += "{";
				text = text + "\"商品序号\":\"" + current.商品序号 + "\",";
				text = text + "\"道具名字\":\"" + current.道具名字 + "\",";
				text = text + "\"道具图标\":\"" + current.道具图标 + "\",";
				text = text + "\"货币类型\":\"" + current.货币类型 + "\",";
				text = text + "\"商品价格\":\"" + current.商品价格 + "\",";
				text = text + "\"商品序号\":\"" + current.商品序号 + "\",";
				text += "}";
				text += ",";
			}
			text += "]";
			while (text.IndexOf(",}") != -1)
			{
				text = text.Replace(",}", "}");
			}
			text = text.Replace(",]", "]");
			return text;
		}

		public string getPropJSON(List<道具信息> 道具)
		{
			数据处理.临时道具类型 = new 数据处理().读取所有道具类型();
			string text = "[";
			foreach (道具信息 current in 道具)
			{
				text += "{";
				text = text + "\"道具价格\":\"" + current.道具价格 + "\",";
				text = text + "\"道具类型ID\":\"" + current.道具类型ID + "\",";
				text = text + "\"道具名字\":\"" + current.道具名字 + "\",";
				text = text + "\"道具数量\":\"" + current.道具数量 + "\",";
				text = text + "\"道具图标\":\"" + current.道具图标 + "\",";
				text = text + "\"道具位置\":\"" + current.道具位置 + "\",";
				text = text + "\"道具序号\":\"" + current.道具序号 + "\",";
				text += "}";
				text += ",";
			}
			text += "]";
			while (text.IndexOf(",}") != -1)
			{
				text = text.Replace(",}", "}");
			}
			text = text.Replace(",]", "]");
			数据处理.临时道具类型 = null;
			return text;
		}

		public string getpetJSON(List<宠物信息> 宠物, bool 面板)
		{
			数据处理.临时宠物类型 = new 数据处理().读取宠物类型();
			string text = "[";
			foreach (宠物信息 current in 宠物)
			{
				text += "{";
				text = text + "\"宠物序号\":\"" + current.宠物序号 + "\",";
				text = text + "\"形象\":\"" + current.形象 + "\",";
				text = text + "\"当前经验\":\"" + current.当前经验 + "\",";
				text = text + "\"等级\":\"" + current.等级 + "\",";
				text = text + "\"五行\":\"" + current.五行 + "\",";
				text = text + "\"生命\":\"" + current.生命 + "\",";
				text = text + "\"魔法\":\"" + current.魔法 + "\",";
				text = text + "\"抵消\":\"" + current.抵消 + "\",";
				text = text + "\"加深\":\"" + current.加深 + "\",";
				text = text + "\"吸血\":\"" + current.吸血 + "\",";
				text = text + "\"攻击\":\"" + current.攻击 + "\",";
				text = text + "\"防御\":\"" + current.防御 + "\",";
				text = text + "\"速度\":\"" + current.速度 + "\",";
				text = text + "\"状态\":\"" + current.状态 + "\",";
				text = text + "\"闪避\":\"" + current.闪避 + "\",";
				text = text + "\"宠物名字\":\"" + current.宠物名字 + "\",";
				text = text + "\"位置\":\"" + current.位置 + "\",";
				text = text + "\"成长\":\"" + current.成长 + "\",";
				text = text + "\"命中\":\"" + current.命中 + "\",";
				text = text + "\"最大生命\":\"" + current.最大生命 + "\",";
				text = text + "\"最大魔法\":\"" + current.最大魔法 + "\",";
				text = text + "\"已进化次数\":\"" + current.已进化次数 + "\",";
				text = text + "\"技能列表\":\"" + current.技能列表 + "\",";
				if (面板)
				{
					text = text + "\"技能显示\":\"" + current.技能显示 + "\",";
				}
				text += "}";
				text += ",";
			}
			text += "]";
			while (text.IndexOf(",}") != -1)
			{
				text = text.Replace(",}", "}");
			}
			text = text.Replace(",]", "]");
			数据处理.临时宠物类型 = null;
			return text;
		}

		public string getZBJSON(List<装备信息> 装备)
		{
			string text = "[";
			foreach (装备信息 current in 装备)
			{
				text += "{";
				text = text + "\"cID\":\"" + current.cID + "\",";
				text = text + "\"ICO\":\"" + current.ICO + "\",";
				text = text + "\"ID\":\"" + current.ID + "\",";
				text = text + "\"Name\":\"" + current.Name + "\",";
				text = text + "\"类ID\":\"" + current.类ID + "\",";
				text = text + "\"类型\":\"" + current.类型 + "\",";
				text = text + "\"强化\":\"" + current.强化 + "\",";
				text += "}";
				text += ",";
			}
			text += "]";
			while (text.IndexOf(",}") != -1)
			{
				text = text.Replace(",}", "}");
			}
			text = text.Replace(",]", "]");
			return text;
		}

		public string getUserJSON(用户信息 信息)
		{
			string str = "";
			str += "{";
			str = str + "\"a\":\"" + 信息.a + "\",";
			str = str + "\"b\":\"" + 信息.b + "\",";
			str = str + "\"c\":\"" + 信息.c + "\",";
			str = str + "\"vip\":\"" + 信息.vip + "\",";
			str = str + "\"仓库容量\":\"" + 信息.仓库容量 + "\",";
			str = str + "\"宠物1\":\"" + 信息.宠物1 + "\",";
			str = str + "\"宠物2\":\"" + 信息.宠物2 + "\",";
			str = str + "\"宠物3\":\"" + 信息.宠物3 + "\",";
			str = str + "\"宠物数量\":\"" + 信息.宠物数量 + "\",";
			str = str + "\"创世礼包领取\":\"" + 信息.创世礼包领取 + "\",";
			str = str + "\"地狱层数\":\"" + 信息.地狱层数 + "\",";
			str = str + "\"积分\":\"" + 信息.积分 + "\",";
			str = str + "\"金币\":\"" + 信息.金币 + "\",";
			str = str + "\"每日礼包\":\"" + 信息.每日礼包 + "\",";
			str = str + "\"名字\":\"" + 信息.名字 + "\",";
			str = str + "\"刷怪数\":\"" + 信息.刷怪数 + "\",";
			str = str + "\"水晶\":\"" + 信息.水晶 + "\",";
			str = str + "\"元宝\":\"" + 信息.元宝 + "\",";
			str = str + "\"战斗时间\":\"" + 信息.战斗时间 + "\",";
			str = str + "\"主宠名字\":\"" + 信息.主宠名字 + "\",";
			str = str + "\"主宠物\":\"" + 信息.主宠物 + "\",";
			str = str + "\"自动战斗次数\":\"" + 信息.自动战斗次数 + "\",";
			str = str + "\"时之券\":\"" + 信息.时之券 + "\"";
			return str + "}";
		}

		public string DataTableJsone(DataTable dt)
		{
			bool flag = dt == null || dt.Rows.Count == 0;
			string result;
			if (flag)
			{
				result = "[]";
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("{\"data\":[");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					stringBuilder.Append("{");
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						bool flag2 = dt.Columns[j].ColumnName != "Row";
						if (flag2)
						{
							stringBuilder.Append("\"");
							stringBuilder.Append(dt.Columns[j].ColumnName);
							stringBuilder.Append("\":\"");
							string text = dt.Rows[i][j].ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim();
							bool flag3 = dt.Columns[j].DataType.FullName == "System.DateTime";
							if (flag3)
							{
								stringBuilder.Append((text.Length == 0) ? text : Convert.ToDateTime(text).ToString("yyyy-MM-dd HH:mm:ss"));
							}
							else
							{
								stringBuilder.Append(text);
							}
							stringBuilder.Append("\",");
						}
					}
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					stringBuilder.Append("},");
				}
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
				stringBuilder.Append("]}");
				result = stringBuilder.ToString();
			}
			return result;
		}

		public string MessageInfo(string str)
		{
			string result;
			try
			{
				string text = "{\"data\":{\"Message\":\"" + str + "\"}}";
				result = text;
			}
			catch (Exception var_2_1D)
			{
				throw;
			}
			return result;
		}

		public string ListToJSON(List<string> List, string NodeName)
		{
			string text = "[";
			foreach (string current in List)
			{
				string str = string.Concat(new string[]
				{
					"{\"",
					NodeName,
					"\":\"",
					current,
					"\"},"
				});
				text += str;
			}
			text += "]";
			text = text.Replace("},]", "}]");
			return text;
		}

		public string StrToJSON(string str)
		{
			string text = "{";
			string[] array = str.Split(new char[]
			{
				','
			});
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new char[]
				{
					':'
				});
				bool flag = array3.Length == 2;
				if (flag)
				{
					string str2 = string.Concat(new string[]
					{
						"\"",
						array3[0],
						"\":\"",
						array3[1],
						"\","
					});
					text += str2;
				}
			}
			text += "}";
			return text.Replace(",}", "}");
		}

		public string JsonContent(string Url)
		{
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
				string text = streamReader.ReadToEnd();
				result = text;
			}
			catch (Exception var_5_3C)
			{
				throw;
			}
			return result;
		}
	}
}
