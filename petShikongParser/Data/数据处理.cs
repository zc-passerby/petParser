using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace petShikongParser
{
	public class 数据处理
	{
		public static string 宠物存档路径1 = "PageMain\\petInfo.dat";

		public static string 用户存档路径1 = "PageMain\\userInfo.dat";

		public static string 道具存档路径1 = "PageMain\\propInfo.dat";

		public static string 宠物仓库缓存路径 = "PageMain\\Pasture_test.html";

		public static string 宠物定义配置路径 = "PageMain\\petInfoTable.dat";

		public static string 道具定义配置路径 = "PageMain\\propTable.dat";

		public static string 道具脚本配置路径 = "PageMain\\propTable\\";

		public static string 装备定义配置路径 = "PageMain\\propTable\\_0\\";

		public static string 任务定义配置路径 = "PageMain\\task";

		public static string 装备类型表配置路径 = "PageMain\\propTable\\_0\\_0.dat";

		public static string 地图定义配置路径 = "PageMain\\map\\";

		public static string 怪物类型定义配置路径 = "PageMain\\pet_01.dat";

		public static string 等级定义配置路径 = "PageMain\\petLvTable.dat";

		public static string 套装定义配置路径 = "PageMain\\propTable\\_0\\_1\\";

		public static string 技能定义配置路径 = "PageMain\\propTable\\_0\\_1\\_2\\_2.dat";

		public static string 神秘商店_元宝道具配置路径 = "PageMain\\Malls\\_01.dat";

		public static string 神秘商店_水晶道具配置路径 = "PageMain\\Malls\\_02.dat";

		public static string 普通商店_金币道具配置路径 = "PageMain\\Malls\\_03.dat";

		public static string 积分商店_积分道具配置路径 = "PageMain\\Malls\\_04.dat";

		public static string 进化配置 = "PageMain\\petInfoTable_a.dat";

		public static string 合成配置 = "PageMain\\petInfoTable_b.dat";

		public static string 总存档路径 = "PageMain\\Main.dat";

		public static double 存档版本号 = 0.6;

		public static string 存档密钥 = "qiqiwan.2016.2017.2018.2020.2021.2022";

		public static string 哈希 = "1CEF18F79C700A0C8128B8599D0B9506";

		public static List<宠物信息> _宠物列表 = new List<宠物信息>();

		public static List<宠物类型> _宠物类型 = null;

		public static List<道具类型> _道具类型 = null;

		public static List<道具信息> _玩家道具 = new List<道具信息>();

		public static List<怪物类型> _怪物类型 = null;

		public static List<装备信息> _装备列表 = new List<装备信息>();

		public static List<long> _等级经验 = new List<long>();

		public static List<商店道具信息> _神秘商店_元宝道具 = new List<商店道具信息>();

		public static List<商店道具信息> _神秘商店_水晶道具 = new List<商店道具信息>();

		public static List<商店道具信息> _普通商店_金币道具 = new List<商店道具信息>();

		public static List<商店道具信息> _积分商店_积分道具 = new List<商店道具信息>();

		public static parserMain _游戏窗口;

		public static string 玩家KEY = null;

		public ConvertJson jsonTo = new ConvertJson();

		public static bool 初始化 = true;

		public static Random 随机数产生器 = new Random();

		public static List<宠物类型> 临时宠物类型 = null;

		public static List<道具类型> 临时道具类型 = null;

		public static string 存档Hash;

		public static string 程序路径 = Environment.CurrentDirectory.ToString();

		public static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

		public static bool z = false;

		public static 用户信息 _用户存档;

		public static List<任务信息> _已领任务;

		public static List<技能配置> _技能列表 = new List<技能配置>();

		public static int 取人工概率数(int 最小, int 最大)
		{
			string text = RC4.DecryptRC4wq("5BD4918FA094AC182195BD3087C93D48EF271C599D6716E8AB0C23579CCA04BF2370CE474254C74DDA9FF5E406EAFA7EB62F920E2E42A82A6ADD8BAF9AD2F1BE122D1310D50C3586CF72A52949EBCDB055E11FA41854257A8687A5D85F98634E8BF4F614B526F57D0B8C62A406E129", 数据处理.存档密钥);
			text = text.Replace("\r\n", "|");
			text = text.Replace("\t", ",");
			string[] array = text.Split(new char[]
			{
				'|'
			});
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num = 0;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new char[]
				{
					','
				});
				list2.Add(array3[0]);
				list.Add(array3[1]);
				num += Convert.ToInt32(array3[1]);
			}
			int num2 = 数据处理.随机数产生器.Next(1, num * 20 + 1);
			num2 %= num;
			bool flag = num2 == 0;
			if (flag)
			{
				num2 = num;
			}
			int num3 = 0;
			int result;
			for (int j = 1; j <= array.Length; j++)
			{
				num3 += Convert.ToInt32(list[j - 1]);
				bool flag2 = num3 >= num2;
				if (flag2)
				{
					double value = (double)(最大 - 最小) * Convert.ToDouble(list2[j - 1]) / (double)array.Length;
					result = 最小 + (int)Math.Round(value, MidpointRounding.AwayFromZero);
					return result;
				}
			}
			result = 0;
			return result;
		}

		public static int GetRandomSeed()
		{
			byte[] array = new byte[4];
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			rNGCryptoServiceProvider.GetBytes(array);
			return BitConverter.ToInt32(array, 0);
		}

		public static int gdsjs(int min, int max)
		{
			long ticks = DateTime.Now.Ticks;
			Random random = new Random((int)(ticks & (long)((ulong)1)) | (int)(ticks >> 32));
			int[] array = new int[6];
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					Thread.Sleep(10);
					array[j] = random.Next(min, max);
					for (int k = 0; k < j; k++)
					{
						bool flag = array[j] == array[k];
						if (flag)
						{
							array[j] = random.Next(min, max);
						}
					}
				}
			}
			return array[数据处理.随机数产生器.Next(0, 6)];
		}

		public void 保存文件(string text, string name)
		{
			bool flag = name.IndexOf("Main.dat") != -1;
			if (flag)
			{
				bool flag2 = !File.Exists(数据处理.总存档路径);
				if (flag2)
				{
					File.WriteAllText(name, text, Encoding.UTF8);
				}
				File.Copy(name, "PageMain\\backups\\_Main.back", true);
				File.WriteAllText(name + "_bank", text, Encoding.UTF8);
				File.Delete(name);
				File.Move(name + "_bank", name);
				数据处理.存档Hash = 数据处理.GetFileHash(name);
			}
			else
			{
				File.WriteAllText(name, text, Encoding.UTF8);
			}
		}

		public static double 取浮点(string 浮点配置)
		{
			return Convert.ToDouble(RC4.DecryptRC4wq(浮点配置, 数据处理.存档密钥));
		}

		public static int 取整数(string 浮点配置)
		{
			return Convert.ToInt32(RC4.DecryptRC4wq(浮点配置, 数据处理.存档密钥));
		}

		public bool 验证Hash(bool 不验证宠物)
		{
			bool flag = new 数据处理().读取文件(Environment.CurrentDirectory.ToString() + "/pageMain/Main/main.txt").Equals("1");
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				string fileHash = 数据处理.GetFileHash(Environment.CurrentDirectory.ToString() + "\\PageMain\\Content\\resources\\styles\\images\\4ie\\lld\\css\\select\\sese\\css.css");
				bool flag2 = fileHash != 数据处理.哈希;
				if (flag2)
				{
					result = false;
				}
				else
				{
					string text = new 数据处理().读取文件(Environment.CurrentDirectory.ToString() + "\\PageMain\\Content\\resources\\styles\\images\\4ie\\lld\\css\\select\\sese\\css.css", true);
					string[] array = text.Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None);
					string[] array2 = array;
					int i = 0;
					while (i < array2.Length)
					{
						string text2 = array2[i];
						if (!不验证宠物)
						{
							goto IL_DD;
						}
						bool flag3 = text2.ToLower().IndexOf(".gif") != -1;
						if (!flag3)
						{
							goto IL_DD;
						}
						IL_132:
						i++;
						continue;
						IL_DD:
						string fileHash2 = 数据处理.GetFileHash(Environment.CurrentDirectory.ToString() + text2.Split(new char[]
						{
							'|'
						})[0]);
						bool flag4 = !fileHash2.Equals(text2.Split(new char[]
						{
							'|'
						})[1]);
						if (flag4)
						{
							result = false;
							return result;
						}
						goto IL_132;
					}
					result = true;
				}
			}
			return result;
		}

		public static string GetFileHash(string filePath)
		{
			bool flag = !File.Exists(filePath);
			string result;
			if (flag)
			{
				result = "-1";
			}
			else
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					result = BitConverter.ToString(数据处理.md5.ComputeHash(fileStream)).Replace("-", "");
				}
			}
			return result;
		}

		public static string GetStringHash(string str)
		{
			return BitConverter.ToString(数据处理.md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
		}

		public List<怪物类型> 取怪物类型列表()
		{
			bool flag = 数据处理._怪物类型 != null;
			List<怪物类型> result;
			if (flag)
			{
				result = 数据处理._怪物类型;
			}
			else
			{
				数据处理._怪物类型 = new List<怪物类型>();
				string text = this.读取文件(数据处理.怪物类型定义配置路径);
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				List<怪物类型> list = new List<怪物类型>();
				string[] array = text.Split(new string[]
				{
					"\r\n"
				}, StringSplitOptions.None);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					string[] array3 = text2.Split(new char[]
					{
						'，'
					});
					list.Add(new 怪物类型
					{
						怪物序号 = array3[0],
						对应的宠物序号 = array3[1],
						怪物名字 = array3[2],
						怪物五行 = array3[3]
					});
				}
				数据处理._怪物类型 = list;
				result = list;
			}
			return result;
		}

		public 怪物类型 取指定怪物类型(string 怪物序号)
		{
			List<怪物类型> list = this.取怪物类型列表();
			怪物类型 result;
			foreach (怪物类型 current in list)
			{
				bool flag = current.怪物序号.Equals(怪物序号);
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public void 宠物死亡(string 宠物序号)
		{
			List<宠物信息> list = new List<宠物信息>();
			list = this.读取宠物列表_(false);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].宠物序号.Equals(宠物序号);
				if (flag)
				{
					list[i].生命 = "0";
					break;
				}
			}
		}

		public void 宠物加血(string 宠物序号, string hp)
		{
			List<宠物信息> list = new List<宠物信息>();
			list = this.读取宠物列表_(false);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].宠物序号.Equals(宠物序号);
				if (flag)
				{
					list[i].生命 = (Convert.ToInt32(list[i].生命) + Convert.ToInt32(hp)).ToString();
					bool flag2 = Convert.ToInt32(list[i].生命) > Convert.ToInt32(list[i].最大生命);
					if (flag2)
					{
						list[i].生命 = list[i].最大生命;
					}
					break;
				}
			}
		}

		public void 宠物满血(string 宠物序号)
		{
			List<宠物信息> list = new List<宠物信息>();
			list = this.读取宠物列表_(false);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].宠物序号.Equals(宠物序号);
				if (flag)
				{
					list[i].生命 = list[i].最大生命;
					break;
				}
			}
		}

		public List<怪物信息> 取指定地图怪物列表(string 地图ID)
		{
			string name = 数据处理.地图定义配置路径 + "_" + 地图ID + "pet_.data";
			string text = this.读取文件(name);
			bool flag = text == null;
			List<怪物信息> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				List<怪物信息> list = JsonConvert.DeserializeObject<List<怪物信息>>(text);
				result = list;
			}
			return result;
		}

		public 宠物信息 取地狱之门怪物()
		{
			List<怪物类型> list = this.取怪物类型列表();
			用户信息 用户信息 = new 数据处理().读取用户信息_();
			int index = 数据处理.随机数产生器.Next(0, list.Count - 1);
			怪物信息 怪物信息 = new 怪物信息();
			怪物信息.掉落道具 = "2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016092501|2016101701|2016101701|2016092903|2016092903|2016100403|2016100403|2016092505|2016092505|2016100803|2016100803|10000|10000|2017050301";
			long num = 1L;
			bool flag = RC4.是否为数值(用户信息.地狱层数);
			if (flag)
			{
				num = Convert.ToInt64(用户信息.地狱层数);
			}
			怪物信息.序号 = list[index].怪物序号;
			怪物信息.怪物五行 = "魔";
			地图信息 地图信息 = new 地图信息();
			bool flag2 = num <= 100L && num >= 0L;
			if (flag2)
			{
				bool flag3 = (num + 1L) % 100L == 0L;
				if (flag3)
				{
					怪物信息.最大掉落 = "5";
					怪物信息.怪物成长 = (num * 50L + 100L).ToString();
					地图信息.最大元宝 = "160";
					地图信息.最小元宝 = "40";
					地图信息.最大金币 = "100000";
					地图信息.最小金币 = "1200";
					地图信息.掉落道具 = "10000|10000|10000|2016092501|2016101701";
					地图信息.最小掉落 = "0";
					地图信息.最大掉落 = "2";
					怪物信息.经验值 = "100000000";
				}
				else
				{
					bool flag4 = (num + 1L) % 50L == 0L;
					if (flag4)
					{
						怪物信息.最大掉落 = "5";
						怪物信息.怪物成长 = (num * 30L + 100L).ToString();
						地图信息.最大元宝 = "80";
						地图信息.最小元宝 = "40";
						地图信息.最大金币 = "100000";
						地图信息.最小金币 = "1200";
						地图信息.掉落道具 = "10000|2016092501|2016101701";
						地图信息.最小掉落 = "0";
						地图信息.最大掉落 = "2";
						怪物信息.经验值 = "100000000";
					}
					else
					{
						bool flag5 = (num + 1L) % 10L == 0L;
						if (flag5)
						{
							怪物信息.最大掉落 = "5";
							怪物信息.怪物成长 = (num * 22L + 100L).ToString();
							地图信息.最大元宝 = "28";
							地图信息.最小元宝 = "20";
							地图信息.最大金币 = "100000";
							地图信息.最小金币 = "1200";
							地图信息.掉落道具 = "10000|2016092501|2016101701";
							地图信息.最小掉落 = "0";
							地图信息.最大掉落 = "2";
							怪物信息.经验值 = "100000000";
						}
						else
						{
							bool flag6 = (num + 1L) % 5L == 0L;
							if (flag6)
							{
								怪物信息.最大掉落 = "5";
								怪物信息.怪物成长 = (num * 15L + 100L).ToString();
								地图信息.最大元宝 = "16";
								地图信息.最小元宝 = "8";
								地图信息.最大金币 = "100000";
								地图信息.最小金币 = "1200";
								地图信息.掉落道具 = "10000|2016092501";
								地图信息.最小掉落 = "0";
								地图信息.最大掉落 = "2";
								怪物信息.经验值 = "10000000";
							}
							else
							{
								怪物信息.最大掉落 = "2";
								怪物信息.怪物成长 = ((num + 1L) * 10L + 100L).ToString();
								地图信息.最大元宝 = "12";
								地图信息.最小元宝 = "8";
								地图信息.最大金币 = "100000";
								地图信息.最小金币 = "1200";
								地图信息.掉落道具 = "无";
								怪物信息.经验值 = "5000000";
							}
						}
					}
				}
			}
			else
			{
				bool flag7 = num <= 999L && num > 100L;
				if (flag7)
				{
					bool flag8 = (num + 1L) % 100L == 0L;
					if (flag8)
					{
						怪物信息.最大掉落 = "5";
						怪物信息.怪物成长 = (num * 55L + 100L).ToString();
						地图信息.最大元宝 = "160";
						地图信息.最小元宝 = "40";
						地图信息.最大金币 = "100000";
						地图信息.最小金币 = "1200";
						地图信息.掉落道具 = "10000|10000|10000|2016092501|2016101701";
						地图信息.最小掉落 = "1";
						地图信息.最大掉落 = "3";
						怪物信息.经验值 = "100000000";
					}
					else
					{
						bool flag9 = (num + 1L) % 50L == 0L;
						if (flag9)
						{
							怪物信息.最大掉落 = "5";
							怪物信息.怪物成长 = (num * 33L + 100L).ToString();
							地图信息.最大元宝 = "80";
							地图信息.最小元宝 = "40";
							地图信息.最大金币 = "100000";
							地图信息.最小金币 = "1200";
							地图信息.掉落道具 = "10000|2016092501|2016101701";
							地图信息.最小掉落 = "0";
							地图信息.最大掉落 = "3";
							怪物信息.经验值 = "100000000";
						}
						else
						{
							bool flag10 = (num + 1L) % 10L == 0L;
							if (flag10)
							{
								怪物信息.最大掉落 = "5";
								怪物信息.怪物成长 = (num * 24L + 100L).ToString();
								地图信息.最大元宝 = "28";
								地图信息.最小元宝 = "20";
								地图信息.最大金币 = "100000";
								地图信息.最小金币 = "1200";
								地图信息.掉落道具 = "10000|2016092501|2016101701";
								地图信息.最小掉落 = "0";
								地图信息.最大掉落 = "2";
								怪物信息.经验值 = "100000000";
							}
							else
							{
								bool flag11 = (num + 1L) % 5L == 0L;
								if (flag11)
								{
									怪物信息.最大掉落 = "5";
									怪物信息.怪物成长 = (num * 17L + 100L).ToString();
									地图信息.最大元宝 = "16";
									地图信息.最小元宝 = "8";
									地图信息.最大金币 = "100000";
									地图信息.最小金币 = "1200";
									地图信息.掉落道具 = "10000|2016092501";
									地图信息.最小掉落 = "0";
									地图信息.最大掉落 = "2";
									怪物信息.经验值 = "10000000";
								}
								else
								{
									怪物信息.最大掉落 = "2";
									怪物信息.怪物成长 = ((num + 1L) * 11L + 100L).ToString();
									地图信息.最大元宝 = Math.Round(12.0 * (Math.Log10((double)(-1L * num + 1100L)) - 2.0)).ToString();
									地图信息.最小元宝 = Math.Round(8.0 * (Math.Log10((double)(-1L * num + 1100L)) - 2.0)).ToString();
									地图信息.最大金币 = Math.Round(100000.0 * (Math.Log10((double)(-1L * num + 1100L)) - 2.0)).ToString();
									地图信息.最小金币 = Math.Round(1200.0 * (Math.Log10((double)(-1L * num + 1100L)) - 2.0)).ToString();
									地图信息.掉落道具 = "无";
									怪物信息.经验值 = "5000000";
								}
							}
						}
					}
				}
				else
				{
					bool flag12 = num > 999L;
					if (flag12)
					{
						bool flag13 = (num + 1L) % 100L == 0L;
						if (flag13)
						{
							怪物信息.最大掉落 = "5";
							怪物信息.怪物成长 = (num * 110L + 100L).ToString();
							地图信息.最大元宝 = "160";
							地图信息.最小元宝 = "40";
							地图信息.最大金币 = "100000";
							地图信息.最小金币 = "1200";
							地图信息.掉落道具 = "2017050301";
							地图信息.最小掉落 = "1";
							地图信息.最大掉落 = "3";
							怪物信息.经验值 = "100000000";
						}
						else
						{
							bool flag14 = (num + 1L) % 50L == 0L;
							if (flag14)
							{
								怪物信息.最大掉落 = "5";
								怪物信息.怪物成长 = (num * 66L + 100L).ToString();
								地图信息.最大元宝 = "80";
								地图信息.最小元宝 = "40";
								地图信息.最大金币 = "100000";
								地图信息.最小金币 = "1200";
								地图信息.掉落道具 = "2017050301|10000";
								地图信息.最小掉落 = "1";
								地图信息.最大掉落 = "3";
								怪物信息.经验值 = "100000000";
							}
							else
							{
								bool flag15 = (num + 1L) % 10L == 0L;
								if (flag15)
								{
									怪物信息.最大掉落 = "5";
									怪物信息.怪物成长 = (num * 48L + 100L).ToString();
									地图信息.最大元宝 = "28";
									地图信息.最小元宝 = "20";
									地图信息.最大金币 = "100000";
									地图信息.最小金币 = "1200";
									地图信息.掉落道具 = "2017050301|10000|2016101701";
									地图信息.最小掉落 = "1";
									地图信息.最大掉落 = "3";
									怪物信息.经验值 = "100000000";
								}
								else
								{
									bool flag16 = (num + 1L) % 5L == 0L;
									if (flag16)
									{
										怪物信息.最大掉落 = "5";
										怪物信息.怪物成长 = (num * 33L + 100L).ToString();
										地图信息.最大元宝 = "16";
										地图信息.最小元宝 = "8";
										地图信息.最大金币 = "100000";
										地图信息.最小金币 = "1200";
										地图信息.掉落道具 = "10000|2016092501|2016101701|2017050301";
										地图信息.最小掉落 = "1";
										地图信息.最大掉落 = "2";
										怪物信息.经验值 = "10000000";
									}
									else
									{
										怪物信息.最大掉落 = "2";
										怪物信息.怪物成长 = ((num + 1L) * 22L + 100L).ToString();
										地图信息.最大金币 = "1";
										地图信息.最小金币 = "0";
										地图信息.最大元宝 = "1";
										地图信息.最小元宝 = "0";
										地图信息.掉落道具 = "无";
										怪物信息.经验值 = "5000000";
									}
								}
							}
						}
					}
				}
			}
			怪物信息.怪物成长 = (Convert.ToDouble(怪物信息.怪物成长) + (double)num + (double)num).ToString();
			bool flag17 = Convert.ToInt64(怪物信息.怪物成长) < -1000L;
			if (flag17)
			{
				怪物信息.怪物成长 = 9223372036854775807L.ToString();
			}
			宠物信息 宠物信息 = new 宠物信息();
			战斗处理.怪物信息 = 怪物信息;
			战斗处理.地狱之门 = 地图信息;
			宠物信息.地狱之门 = true;
			宠物信息.宠物名字 = 怪物信息.怪物名字;
			宠物信息.形象 = 怪物信息.序号;
			宠物信息.五行 = 怪物信息.怪物五行;
			宠物信息 = this.设置默认属性(宠物信息);
			宠物信息.成长 = 怪物信息.怪物成长;
			宠物信息.当前经验 = num + 350.ToString();
			bool flag18 = Convert.ToInt32(宠物信息.当前经验) > 600;
			if (flag18)
			{
				宠物信息.当前经验 = 600.ToString();
			}
			宠物信息 = 宠物属性计算.计算宠物属性(宠物信息);
			宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) * 10L).ToString();
			宠物信息.最大生命 = (Convert.ToInt64(宠物信息.最大生命) * 10L).ToString();
			return 宠物信息;
		}

		public 怪物信息 取指定地图怪物列表(string 地图ID, string 怪物序号)
		{
			string name = 数据处理.地图定义配置路径 + "_" + 地图ID + "pet_.data";
			string text = this.读取文件(name);
			text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
			List<怪物信息> list = JsonConvert.DeserializeObject<List<怪物信息>>(text);
			怪物信息 怪物信息 = null;
			怪物信息 result;
			foreach (怪物信息 current in list)
			{
				bool flag = current.序号.Equals(怪物序号);
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = 怪物信息;
			return result;
		}

		public 地图信息 取地图信息(string 地图ID)
		{
			string name = 数据处理.地图定义配置路径 + "_" + 地图ID + "map_.data";
			string text = this.读取文件(name);
			bool flag = text == null;
			地图信息 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				地图信息 地图信息 = JsonConvert.DeserializeObject<地图信息>(text);
				result = 地图信息;
			}
			return result;
		}

		public bool 进入战斗(宠物信息 怪物, 宠物信息 宠物, string 地图)
		{
			战斗处理.startTime = this.取系统时间();
			战斗处理.宠物 = 宠物;
			战斗处理.怪物 = 怪物;
			战斗处理.地图 = 地图;
			return true;
		}

		public double 取系统时间()
		{
			DateTime dateTime = DateTime.Now.ToLocalTime();
			DateTime value = new DateTime(1970, 1, 1);
			return dateTime.Subtract(value).TotalMilliseconds;
		}

		public string getTime_()
		{
			return DateTime.Now.ToLocalTime().ToString("yyyyMdHmm");
		}

		public 宠物信息 取随机怪物(List<怪物信息> 怪物, int index)
		{
			List<怪物信息> list = new List<怪物信息>();
			foreach (怪物信息 current in 怪物)
			{
				for (int i = 0; i < 10; i++)
				{
					list.Add(null);
				}
			}
			Random random = 数据处理.随机数产生器;
			foreach (怪物信息 current2 in 怪物)
			{
				for (int j = 0; j < 10; j++)
				{
					int index2 = random.Next(0, list.Count);
					while (list[index2] != null)
					{
						index2 = random.Next(0, list.Count);
					}
					list[index2] = current2;
				}
			}
			bool flag = index == -1;
			怪物信息 怪物信息;
			if (flag)
			{
				int index3 = random.Next(0, list.Count);
				怪物信息 = list[index3];
			}
			else
			{
				怪物信息 = 怪物[index];
			}
			宠物信息 宠物信息 = this.设置默认属性(new 宠物信息
			{
				自定义宠物名字 = 怪物信息.怪物名字,
				形象 = 怪物信息.序号,
				指定五行 = 怪物信息.怪物五行
			});
			宠物信息.成长 = 怪物信息.怪物成长;
			bool flag2 = Convert.ToInt32(怪物信息.最小等级) > Convert.ToInt32(怪物信息.最大等级);
			if (flag2)
			{
				string 最小等级 = 怪物信息.最小等级;
				怪物信息.最小等级 = 怪物信息.最大等级;
				怪物信息.最大等级 = 最小等级;
			}
			string 当前经验 = 数据处理.随机数产生器.Next(Convert.ToInt32(怪物信息.最小等级), Convert.ToInt32(怪物信息.最大等级)).ToString();
			宠物信息.当前经验 = 当前经验;
			return 宠物属性计算.计算宠物属性(宠物信息);
		}

		public DateTime 取网络时间()
		{
			DateTime result;
			try
			{
				string text = "http://120.24.160.228:8088/rand.asp";
				text = this.jsonTo.JsonContent(text);
				bool flag = text == null;
				if (flag)
				{
					result = DateTime.Parse("2000/1/1");
				}
				else
				{
					result = DateTime.Parse(text);
				}
			}
			catch
			{
				result = DateTime.Parse("2000/1/1");
			}
			return result;
		}

		public string 取经验(int j)
		{
			bool flag = j > 数据处理._等级经验.Count<long>();
			if (flag)
			{
				j = 数据处理._等级经验.Count<long>();
			}
			bool flag2 = j <= 1;
			string result;
			if (flag2)
			{
				result = j.ToString();
			}
			else
			{
				result = 数据处理._等级经验[j - 1].ToString();
			}
			return result;
		}

		public string 取经验_(int j)
		{
			bool flag = j >= 数据处理._等级经验.Count<long>();
			if (flag)
			{
				j = 数据处理._等级经验.Count<long>();
			}
			bool flag2 = j <= 1;
			string result;
			if (flag2)
			{
				result = j.ToString();
			}
			else
			{
				result = (数据处理._等级经验[j - 1] - 数据处理._等级经验[j - 2]).ToString();
			}
			return result;
		}

		public string 取怪物名字(string 怪物序号)
		{
			this.取怪物类型列表();
			string result;
			foreach (怪物类型 current in 数据处理._怪物类型)
			{
				bool flag = current.怪物序号.Equals(怪物序号);
				if (flag)
				{
					result = current.怪物名字;
					return result;
				}
			}
			result = "Null";
			return result;
		}

		public string 取怪物五行(string 怪物序号)
		{
			this.取怪物类型列表();
			string result;
			foreach (怪物类型 current in 数据处理._怪物类型)
			{
				bool flag = current.怪物序号.Equals(怪物序号);
				if (flag)
				{
					result = current.怪物五行;
					return result;
				}
			}
			result = "Null";
			return result;
		}

		public List<商店道具信息> 取商店列表(int 商店类型)
		{
			bool flag = 商店类型 == 0;
			List<商店道具信息> result;
			if (flag)
			{
				string text = this.读取文件(数据处理.神秘商店_元宝道具配置路径);
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				数据处理._神秘商店_元宝道具 = JsonConvert.DeserializeObject<List<商店道具信息>>(text);
				数据处理._神秘商店_元宝道具 = this.置商店道具名字(数据处理._神秘商店_元宝道具);
				result = 数据处理._神秘商店_元宝道具;
			}
			else
			{
				bool flag2 = 商店类型 == 1;
				if (flag2)
				{
					string text = this.读取文件(数据处理.神秘商店_水晶道具配置路径);
					text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
					数据处理._神秘商店_水晶道具 = JsonConvert.DeserializeObject<List<商店道具信息>>(text);
					数据处理._神秘商店_水晶道具 = this.置商店道具名字(数据处理._神秘商店_水晶道具);
					result = 数据处理._神秘商店_水晶道具;
				}
				else
				{
					bool flag3 = 商店类型 == 2;
					if (flag3)
					{
						string text = this.读取文件(数据处理.普通商店_金币道具配置路径);
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
						数据处理._普通商店_金币道具 = JsonConvert.DeserializeObject<List<商店道具信息>>(text);
						数据处理._普通商店_金币道具 = this.置商店道具名字(数据处理._普通商店_金币道具);
						result = 数据处理._普通商店_金币道具;
					}
					else
					{
						bool flag4 = 商店类型 == 3;
						if (flag4)
						{
							string text = this.读取文件(数据处理.积分商店_积分道具配置路径);
							text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
							数据处理._积分商店_积分道具 = JsonConvert.DeserializeObject<List<商店道具信息>>(text);
							数据处理._积分商店_积分道具 = this.置商店道具名字(数据处理._积分商店_积分道具);
							result = 数据处理._积分商店_积分道具;
						}
						else
						{
							result = null;
						}
					}
				}
			}
			return result;
		}

		public List<商店道具信息> 置商店道具名字(List<商店道具信息> 商店道具列表)
		{
			for (int i = 0; i < 商店道具列表.Count; i++)
			{
				bool flag = 商店道具列表[i].道具名字 == null;
				if (flag)
				{
					商店道具列表[i].道具名字 = this.取道具名字(商店道具列表[i].商品序号);
					商店道具列表[i].道具图标 = this.取道具图标(商店道具列表[i].商品序号);
				}
			}
			return 商店道具列表;
		}

		public void 加载等级配置()
		{
			string text = this.读取文件(数据处理.等级定义配置路径);
			text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
			string[] array = text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
			long num = 0L;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string value = array2[i];
				num += Convert.ToInt64(value);
				数据处理._等级经验.Add(num);
			}
		}

		public int 取等级(long 经验值)
		{
			int result;
			for (int i = 0; i < 数据处理._等级经验.Count; i++)
			{
				bool flag = 经验值 < 数据处理._等级经验[i];
				if (flag)
				{
					result = i + 1;
					return result;
				}
			}
			result = 数据处理._等级经验.Count;
			return result;
		}

		public 宠物信息 设置默认属性(宠物信息 宠物)
		{
			bool flag = 宠物.五行.Equals("神");
			if (flag)
			{
				宠物.防御 = "1400";
				宠物.攻击 = "2000";
				宠物.命中 = "3000";
				宠物.魔法 = "1000";
				宠物.最大魔法 = "1000";
				宠物.最大生命 = "3000";
				宠物.生命 = "3000";
				宠物.速度 = "500";
				宠物.成长 = "35.5";
				宠物.闪避 = "1400";
			}
			else
			{
				bool flag2 = 宠物.五行.Equals("神圣");
				if (flag2)
				{
					宠物.防御 = "1500";
					宠物.攻击 = "2100";
					宠物.命中 = "3000";
					宠物.魔法 = "1000";
					宠物.最大魔法 = "1000";
					宠物.最大生命 = "4000";
					宠物.生命 = "4000";
					宠物.速度 = "5000";
					宠物.成长 = "35.5";
					宠物.闪避 = "1500";
				}
				else
				{
					bool flag3 = 宠物.五行.Equals("魔");
					if (flag3)
					{
						宠物.防御 = "1500";
						宠物.攻击 = "2100";
						宠物.命中 = "3500";
						宠物.魔法 = "1000";
						宠物.最大魔法 = "1000";
						宠物.最大生命 = "4000";
						宠物.生命 = "4000";
						宠物.速度 = "5000";
						宠物.成长 = "35.5";
						宠物.闪避 = "1500";
					}
					else
					{
						宠物.防御 = "100";
						宠物.攻击 = "150";
						宠物.命中 = "250";
						宠物.魔法 = "100";
						宠物.最大魔法 = "100";
						宠物.最大生命 = "300";
						宠物.生命 = "300";
						宠物.速度 = "500";
						宠物.闪避 = "100";
						宠物.成长 = "1.3";
					}
				}
			}
			宠物.已进化次数 = "0";
			return 宠物;
		}

		public List<道具类型> 读取所有道具类型()
		{
			bool flag = 数据处理.临时道具类型 != null;
			List<道具类型> 道具类型;
			if (flag)
			{
				道具类型 = 数据处理.临时道具类型;
			}
			else
			{
				bool flag2 = 数据处理._道具类型 != null;
				if (flag2)
				{
					道具类型 = 数据处理._道具类型;
				}
				else
				{
					string text = this.读取文件(数据处理.道具定义配置路径);
					bool flag3 = text == null;
					if (flag3)
					{
						数据处理._道具类型 = new List<道具类型>();
						道具类型 = 数据处理._道具类型;
					}
					else
					{
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
						数据处理._道具类型 = JsonConvert.DeserializeObject<List<道具类型>>(text);
						道具类型 = 数据处理._道具类型;
					}
				}
			}
			return 道具类型;
		}

		public List<装备类型> 取装备记录表()
		{
			List<装备类型> list = new List<装备类型>();
			DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory.ToString() + "\\" + 数据处理.装备定义配置路径);
			FileInfo[] files = directoryInfo.GetFiles();
			List<文件验证> list2 = new List<文件验证>();
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				bool flag = fileInfo.Extension.Equals(".dat");
				if (flag)
				{
					string value = RC4.DecryptRC4wq(this.读取文件(new 文件验证
					{
						特征 = 数据处理.GetFileHash(fileInfo.FullName),
						文件名 = 数据处理.装备定义配置路径 + fileInfo.Name
					}.文件名), 数据处理.存档密钥);
					装备类型 item = JsonConvert.DeserializeObject<装备类型>(value);
					list.Add(item);
				}
			}
			return list;
		}

		public List<string> 取地图列表()
		{
			List<string> list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory.ToString() + "\\" + 数据处理.地图定义配置路径);
			FileInfo[] files = directoryInfo.GetFiles();
			List<文件验证> list2 = new List<文件验证>();
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				bool flag = fileInfo.Extension.Equals(".data");
				if (flag)
				{
					文件验证 文件验证 = new 文件验证();
					文件验证.特征 = 数据处理.GetFileHash(fileInfo.FullName);
					文件验证.文件名 = 数据处理.地图定义配置路径 + fileInfo.Name;
					bool flag2 = fileInfo.Name.IndexOf("map") != -1;
					if (flag2)
					{
						string str = this.读取文件(文件验证.文件名);
						string value = RC4.DecryptRC4wq(str, 数据处理.存档密钥);
						地图信息 地图信息 = JsonConvert.DeserializeObject<地图信息>(value);
						list.Add(地图信息.地图ID);
					}
				}
			}
			return list;
		}

		public List<装备信息> 取指定宠物的装备(string 宠物序号, List<装备信息> 所有装备)
		{
			bool flag = 宠物序号 == null;
			List<装备信息> result;
			if (flag)
			{
				result = new List<装备信息>();
			}
			else
			{
				List<装备信息> list = new List<装备信息>();
				bool flag2 = 所有装备 == null;
				if (flag2)
				{
					所有装备 = this.取玩家所有装备();
				}
				foreach (装备信息 current in 所有装备)
				{
					bool flag3 = current.cID == 宠物序号;
					if (flag3)
					{
						list.Add(current);
					}
				}
				result = list;
			}
			return result;
		}

		public List<装备信息> 取未佩戴的装备()
		{
			this.取玩家所有装备();
			List<装备信息> list = new List<装备信息>();
			foreach (装备信息 current in 数据处理._装备列表)
			{
				bool flag = current.cID == null || current.cID == "Null" || current.cID.Length <= 0;
				if (flag)
				{
					list.Add(current);
				}
			}
			return list;
		}

		public 装备信息 取指定装备(string 装备ID, bool 强制)
		{
			bool flag = !强制;
			if (flag)
			{
				this.取玩家所有装备();
			}
			装备信息 result;
			foreach (装备信息 current in 数据处理._装备列表)
			{
				bool flag2 = current.ID == 装备ID;
				if (flag2)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public 装备类型 取指定装备类型(string 装备ID)
		{
			string text = RC4.DecryptRC4wq(this.读取文件(数据处理.装备定义配置路径 + 装备ID + ".dat"), 数据处理.存档密钥);
			装备类型 result = new 装备类型();
			bool flag = text != null;
			if (flag)
			{
				result = JsonConvert.DeserializeObject<装备类型>(text);
			}
			return result;
		}

		public List<装备信息> 取玩家所有装备()
		{
			bool flag = 数据处理._装备列表.Count != 0 && 数据处理.z;
			List<装备信息> result;
			if (flag)
			{
				result = 数据处理._装备列表;
			}
			else
			{
				string text = this.getStr();
				bool flag2 = text == null;
				if (flag2)
				{
					result = new List<装备信息>();
				}
				else
				{
					string[] array = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					text = array[4];
					bool flag3 = text != null && text != "";
					if (flag3)
					{
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(4));
						text = this.解压道具JSON(text);
						try
						{
							数据处理._装备列表 = JsonConvert.DeserializeObject<List<装备信息>>(text);
						}
						catch
						{
							result = 数据处理._装备列表;
							return result;
						}
					}
					result = 数据处理._装备列表;
				}
			}
			return result;
		}

		public bool 增加道具存档_(道具信息 道具)
		{
			this.取玩家所有道具_();
			道具.道具类型ID = 道具.道具类型ID.Replace(" ", "");
			this.读取所有道具类型();
			bool flag = 数据处理._玩家道具.Count > 100;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = false;
				for (int i = 0; i < 数据处理._玩家道具.Count; i++)
				{
					bool flag3 = 数据处理._玩家道具[i].道具类型ID.Equals(道具.道具类型ID);
					if (flag3)
					{
						道具.道具序号 = 数据处理._玩家道具[i].道具序号;
						道具.道具数量 = (Convert.ToInt32(数据处理._玩家道具[i].道具数量) + Convert.ToInt32(道具.道具数量)).ToString();
						数据处理._玩家道具[i] = 道具;
						flag2 = true;
					}
				}
				bool flag4 = !flag2;
				if (flag4)
				{
					foreach (道具类型 current in 数据处理._道具类型)
					{
						bool flag5 = current.道具序号.Equals(道具.道具类型ID);
						if (flag5)
						{
							道具.道具图标 = current.道具图标;
							道具.道具序号 = this.生成玩家道具序号().ToString();
							break;
						}
					}
					数据处理._玩家道具.Add(道具);
				}
				bool flag6 = 道具.道具序号 == null;
				if (flag6)
				{
					result = false;
				}
				else
				{
					bool flag7 = 道具.道具类型ID == null;
					if (flag7)
					{
						result = false;
					}
					else
					{
						this.保存玩家道具存档(数据处理._玩家道具);
						result = true;
					}
				}
			}
			return result;
		}

		public int 生成玩家道具序号()
		{
			int num = 0;
			bool flag = true;
			while (flag)
			{
				flag = false;
				num++;
				foreach (道具信息 current in 数据处理._玩家道具)
				{
					bool flag2 = current.道具序号.Equals(num.ToString());
					if (flag2)
					{
						flag = true;
						break;
					}
				}
			}
			return num;
		}

		public List<道具信息> 取玩家所有道具()
		{
			return new List<道具信息>();
		}

		public List<道具信息> 取玩家所有道具_()
		{
			bool flag = 数据处理._玩家道具.Count != 0 && 数据处理.z;
			List<道具信息> result;
			if (flag)
			{
				result = 数据处理._玩家道具;
			}
			else
			{
				string text = this.getStr();
				bool flag2 = text == null;
				if (flag2)
				{
					result = new List<道具信息>();
				}
				else
				{
					string[] array = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					text = array[1];
					bool flag3 = text != null && text != "";
					if (flag3)
					{
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(1));
						text = this.解压道具JSON(text);
						try
						{
							数据处理._玩家道具 = JsonConvert.DeserializeObject<List<道具信息>>(text);
						}
						catch
						{
							result = 数据处理._玩家道具;
							return result;
						}
					}
					IEnumerable<道具信息> arg_D2_0 = 数据处理._玩家道具;
					Func<道具信息, string> arg_D2_1;
// 					if ((arg_D2_1 = 数据处理.<>c.<>9__100_0) == null)
// 					{
// 						arg_D2_1 = (数据处理.<>c.<>9__100_0 = new Func<道具信息, string>(数据处理.<>c.<>9.<取玩家所有道具_>b__100_0));
// 					}
// 					数据处理._玩家道具 = arg_D2_0.OrderBy(arg_D2_1).ToList<道具信息>();
					result = 数据处理._玩家道具;
				}
			}
			return result;
		}

		public bool 指定道具放入仓库(string 道具序号)
		{
			bool flag = this.取玩家道具_指定位置(道具属性类型.仓库).Count >= 100;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.取玩家所有道具_();
				for (int i = 0; i < 数据处理._玩家道具.Count; i++)
				{
					bool flag2 = 数据处理._玩家道具[i].道具序号.Equals(道具序号);
					if (flag2)
					{
						数据处理._玩家道具[i].道具位置 = 道具属性类型.仓库.ToString();
					}
				}
				this.保存玩家道具存档(数据处理._玩家道具);
				result = true;
			}
			return result;
		}

		public bool 指定道具放入背包(string 道具序号)
		{
			bool flag = this.取玩家道具_指定位置(道具属性类型.背包).Count >= 120;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.取玩家所有道具_();
				for (int i = 0; i < 数据处理._玩家道具.Count; i++)
				{
					bool flag2 = 数据处理._玩家道具[i].道具序号.Equals(道具序号);
					if (flag2)
					{
						数据处理._玩家道具[i].道具位置 = 道具属性类型.背包.ToString();
					}
				}
				this.保存玩家道具存档(数据处理._玩家道具);
				result = true;
			}
			return result;
		}

		public List<道具信息> 取玩家道具_指定位置(int 位置)
		{
			this.取玩家所有道具_();
			List<道具信息> list = new List<道具信息>();
			for (int i = 0; i < 数据处理._玩家道具.Count; i++)
			{
				bool flag = 数据处理._玩家道具[i].道具位置.Equals(位置.ToString());
				if (flag)
				{
					list.Add(数据处理._玩家道具[i]);
				}
			}
			return list;
		}

		public List<道具信息> 取玩家道具_指定位置(List<道具信息> 道具列表, int 位置)
		{
			List<道具信息> list = new List<道具信息>();
			for (int i = 0; i < 道具列表.Count; i++)
			{
				bool flag = 道具列表[i].道具位置.Equals(位置.ToString());
				if (flag)
				{
					list.Add(道具列表[i]);
				}
			}
			return list;
		}

		public List<道具信息> 取所有捕捉球()
		{
			this.取玩家所有道具_();
			List<道具信息> list = new List<道具信息>();
			for (int i = 0; i < 数据处理._玩家道具.Count; i++)
			{
				bool flag = 数据处理._玩家道具[i].道具名字.IndexOf("捕捉球") != -1 && 数据处理._玩家道具[i].道具图标 != "12";
				if (flag)
				{
					list.Add(数据处理._玩家道具[i]);
				}
			}
			return list;
		}

		public 道具具体信息 读取道具脚本(string 道具类型序号)
		{
			string text = this.读取文件(数据处理.道具脚本配置路径 + 道具类型序号 + ".data");
			道具具体信息 道具具体信息 = new 道具具体信息();
			bool flag = text != "";
			道具具体信息 result;
			if (flag)
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				道具具体信息 = JsonConvert.DeserializeObject<道具具体信息>(text);
				result = 道具具体信息;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string 读取道具说明(string 道具类型序号)
		{
			string text = this.读取文件(数据处理.道具脚本配置路径 + 道具类型序号 + ".data");
			道具具体信息 道具具体信息 = new 道具具体信息();
			bool flag = text != "";
			string result;
			if (flag)
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				道具具体信息 = JsonConvert.DeserializeObject<道具具体信息>(text);
				result = 道具具体信息.道具说明;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string 读取装备说明(string 道具类型序号, string 宠物ID)
		{
			string text = this.读取文件(数据处理.装备定义配置路径 + 道具类型序号 + ".dat");
			装备类型 装备类型 = new 装备类型();
			bool flag = text != "";
			string result;
			if (flag)
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				装备类型 = JsonConvert.DeserializeObject<装备类型>(text);
				string text2 = "";
				text2 = text2 + "<span>" + 装备类型.类型 + "装备(可强化)</span><span style=\"font-size:12px;line-height: 15px;\">";
				bool flag2 = 装备类型.防御 != null && 装备类型.防御 != "" && 装备类型.防御 != "Null";
				if (flag2)
				{
					string text3 = 装备类型.防御;
					bool flag3 = text3.IndexOf(".") != -1;
					if (flag3)
					{
						text3 = (Convert.ToDouble(装备类型.防御) * 100.0).ToString() + "%";
					}
					bool flag4 = 装备类型.主属性 == "防御";
					if (flag4)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>防御 " + text3 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>防御 " + text3 + "</span>";
					}
				}
				bool flag5 = 装备类型.攻击 != null && 装备类型.攻击 != "" && 装备类型.攻击 != "Null";
				if (flag5)
				{
					string text4 = 装备类型.攻击;
					bool flag6 = text4.IndexOf(".") != -1;
					if (flag6)
					{
						text4 = (Convert.ToDouble(text4) * 100.0).ToString() + "%";
					}
					bool flag7 = 装备类型.主属性 == "攻击";
					if (flag7)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>攻击 " + text4 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>攻击 " + text4 + "</span>";
					}
				}
				bool flag8 = 装备类型.魔法 != null && 装备类型.魔法 != "" && 装备类型.魔法 != "Null";
				if (flag8)
				{
					string text5 = 装备类型.魔法;
					bool flag9 = text5.IndexOf(".") != -1;
					if (flag9)
					{
						text5 = (Convert.ToDouble(text5) * 100.0).ToString() + "%";
					}
					bool flag10 = 装备类型.主属性 == "魔法";
					if (flag10)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>魔法 " + text5 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>魔法 " + text5 + "</span>";
					}
				}
				bool flag11 = 装备类型.闪避 != null && 装备类型.闪避 != "" && 装备类型.闪避 != "Null";
				if (flag11)
				{
					string text6 = 装备类型.闪避;
					bool flag12 = text6.IndexOf(".") != -1;
					if (flag12)
					{
						text6 = (Convert.ToDouble(text6) * 100.0).ToString() + "%";
					}
					bool flag13 = 装备类型.主属性 == "闪避";
					if (flag13)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>闪避 " + text6 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>闪避 " + text6 + "</span>";
					}
				}
				bool flag14 = 装备类型.生命 != null && 装备类型.生命 != "" && 装备类型.生命 != "Null";
				if (flag14)
				{
					string text7 = 装备类型.生命;
					bool flag15 = text7.IndexOf(".") != -1;
					if (flag15)
					{
						text7 = (Convert.ToDouble(text7) * 100.0).ToString() + "%";
					}
					bool flag16 = 装备类型.主属性 == "生命";
					if (flag16)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>生命 " + text7 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>生命 " + text7 + "</span>";
					}
				}
				bool flag17 = 装备类型.速度 != null && 装备类型.速度 != "" && 装备类型.速度 != "Null";
				if (flag17)
				{
					string text8 = 装备类型.速度;
					bool flag18 = text8.IndexOf(".") != -1;
					if (flag18)
					{
						text8 = (Convert.ToDouble(text8) * 100.0).ToString() + "%";
					}
					bool flag19 = 装备类型.主属性 == "速度";
					if (flag19)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>速度 " + text8 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>速度 " + text8 + "</span>";
					}
				}
				bool flag20 = 装备类型.命中 != null && 装备类型.命中 != "" && 装备类型.命中 != "Null";
				if (flag20)
				{
					string text9 = 装备类型.命中;
					bool flag21 = text9.IndexOf(".") != -1;
					if (flag21)
					{
						text9 = (Convert.ToDouble(text9) * 100.0).ToString() + "%";
					}
					bool flag22 = 装备类型.主属性 == "命中";
					if (flag22)
					{
						text2 = text2 + "<br/><span style='color:#FEFDFA'>命中 " + text9 + "</span>";
					}
					else
					{
						text2 = text2 + "<br/><span style='color:#0067CB'>命中 " + text9 + "</span>";
					}
				}
				bool flag23 = 装备类型.抵消 != null && 装备类型.抵消 != "" && 装备类型.抵消 != "Null";
				if (flag23)
				{
					text2 = text2 + "<br/><span style='color:#0067CB'>抵消伤害 " + (Convert.ToDouble(装备类型.抵消) * 100.0).ToString() + "%</span>";
				}
				bool flag24 = 装备类型.加深 != null && 装备类型.加深 != "" && 装备类型.加深 != "Null";
				if (flag24)
				{
					text2 = text2 + "<br/><span style='color:#0067CB'>加深伤害 " + (Convert.ToDouble(装备类型.加深) * 100.0).ToString() + "%</span>";
				}
				bool flag25 = 装备类型.吸魔 != null && 装备类型.吸魔 != "" && 装备类型.吸魔 != "Null";
				if (flag25)
				{
					text2 = text2 + "<br/><span style='color:#0067CB'>吸取魔法 " + (Convert.ToDouble(装备类型.吸魔) * 100.0).ToString() + "%</span>";
				}
				bool flag26 = 装备类型.吸血 != null && 装备类型.吸血 != "" && 装备类型.吸血 != "Null";
				if (flag26)
				{
					text2 = text2 + "<br/><span style='color:#0067CB'>吸取生命 " + (Convert.ToDouble(装备类型.吸血) * 100.0).ToString() + "%</span>";
				}
				text2 += "<br/><span style='color:#14FD10'>卡槽(0/1)</span>";
				suits suits = this.取指定套装(装备类型.suitID);
				bool flag27 = suits.套装序号 != null;
				if (flag27)
				{
					List<装备信息> list = null;
					bool flag28 = 宠物ID != null;
					if (flag28)
					{
						list = this.取指定宠物的装备(宠物ID, 数据处理._装备列表);
					}
					int num = -1;
					bool flag29 = 宠物ID != null;
					if (flag29)
					{
						bool flag30 = list != null;
						if (flag30)
						{
							foreach (装备信息 current in list)
							{
								装备类型 装备类型2 = this.取指定装备类型(current.类ID);
								bool flag31 = 装备类型2.suitID != null && 装备类型2.suitID.Equals(装备类型.suitID);
								if (flag31)
								{
									num++;
								}
							}
						}
					}
					text2 = string.Concat(new object[]
					{
						text2,
						"<br/><span style='color:#FED625'>",
						suits.套装名,
						"(",
						num + 1,
						"/",
						suits.装备列表.Count,
						")</span>"
					});
					int num2 = 0;
					foreach (suit current2 in suits.套装属性)
					{
						string text10 = current2.addNump;
						string text11 = "#A8A7A4";
						bool flag32 = text10.IndexOf(".") != -1;
						if (flag32)
						{
							text10 = (Convert.ToDouble(current2.addNump) * 100.0).ToString() + "%";
						}
						bool flag33 = num2 < num;
						if (flag33)
						{
							text11 = "#68da72";
						}
						text2 = string.Concat(new object[]
						{
							text2,
							"<br/><span style='color:",
							text11,
							"'>(",
							num2 + 2,
							")套装：+",
							text10,
							"&nbsp",
							current2.Type,
							"</span>"
						});
						num2++;
					}
				}
				text2 = text2 + "<br/><span style='color:#FEFDFA'>宠物装备:" + 装备类型.说明 + "</span>";
				text2 += "</span>";
				result = text2;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string 取道具图标(string 道具序号)
		{
			this.读取所有道具类型();
			string result;
			foreach (道具类型 current in 数据处理._道具类型)
			{
				bool flag = current.道具序号.Equals(道具序号);
				if (flag)
				{
					result = current.道具图标;
					return result;
				}
			}
			result = "-1";
			return result;
		}

		public string 取道具价格(string 道具序号)
		{
			this.读取所有道具类型();
			string result;
			foreach (道具类型 current in 数据处理._道具类型)
			{
				bool flag = current.道具序号.Equals(道具序号);
				if (flag)
				{
					result = current.道具价格;
					return result;
				}
			}
			result = "-1";
			return result;
		}

		public string 取道具名字(string 道具序号)
		{
			this.读取所有道具类型();
			string result;
			foreach (道具类型 current in 数据处理._道具类型)
			{
				bool flag = current.道具序号.Equals(道具序号);
				if (flag)
				{
					result = current.道具名字;
					return result;
				}
			}
			result = "-1";
			return result;
		}

		public bool 道具类型是否存在(string 道具类型序号)
		{
			this.读取所有道具类型();
			bool result;
			foreach (道具类型 current in 数据处理._道具类型)
			{
				bool flag = current.道具序号.Equals(道具类型序号);
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool 是否拥有道具(string 道具类型序号)
		{
			this.取玩家所有道具_();
			bool result;
			foreach (道具信息 current in 数据处理._玩家道具)
			{
				bool flag = current.道具类型ID.Equals(道具类型序号);
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public List<宠物类型> 取指定系别宠物(string 系别)
		{
			List<宠物类型> list = this.读取宠物类型();
			List<宠物类型> list2 = new List<宠物类型>();
			foreach (宠物类型 current in list)
			{
				bool flag = current.系别.Equals(系别) && current.宠物名字.IndexOf("涅槃兽") == -1;
				if (flag)
				{
					list2.Add(current);
				}
			}
			return list2;
		}

		public List<宠物类型> 取普通宠物()
		{
			List<宠物类型> list = this.读取宠物类型();
			List<宠物类型> list2 = new List<宠物类型>();
			foreach (宠物类型 current in list)
			{
				bool flag = !current.系别.Equals("神") && !current.系别.Equals("神圣");
				if (flag)
				{
					list2.Add(current);
				}
			}
			return list2;
		}

		public void 修改道具(道具信息 道具)
		{
			this.读取所有道具类型();
			for (int i = 0; i < 数据处理._玩家道具.Count; i++)
			{
				bool flag = 数据处理._玩家道具[i].道具序号.Equals(道具.道具序号);
				if (flag)
				{
					数据处理._玩家道具[i] = 道具;
				}
			}
			this.保存玩家道具存档(数据处理._玩家道具);
		}

		public void 删除道具(道具信息 道具)
		{
			this.读取所有道具类型();
			List<道具信息> list = new List<道具信息>();
			for (int i = 0; i < 数据处理._玩家道具.Count; i++)
			{
				bool flag = !数据处理._玩家道具[i].道具序号.Equals(道具.道具序号);
				if (flag)
				{
					list.Add(数据处理._玩家道具[i]);
				}
			}
			this.保存玩家道具存档(list);
		}

		public void 删除道具(string 道具序号)
		{
			this.读取所有道具类型();
			List<道具信息> list = new List<道具信息>();
			for (int i = 0; i < 数据处理._玩家道具.Count; i++)
			{
				bool flag = !数据处理._玩家道具[i].道具序号.Equals(道具序号);
				if (flag)
				{
					list.Add(数据处理._玩家道具[i]);
				}
			}
			this.保存玩家道具存档(list);
		}

		public void 保存玩家道具存档(List<道具信息> 道具)
		{
			数据处理._玩家道具 = 道具;
			string text = this.jsonTo.getPropJSON(道具);
			text = this.压缩道具JSON(text);
			string str = this.getStr();
			string[] array = str.Split(new string[]
			{
				"O4F89"
			}, StringSplitOptions.None);
			array[1] = text;
			text = this.拼接存档(array, true, null);
			this.保存文件(text, 数据处理.总存档路径);
		}

		public string 压缩道具JSON(string json)
		{
			string[] array = new string[]
			{
				"\"},{\"",
				"fg"
			};
			string[] array2 = new string[]
			{
				"\":\"",
				"'"
			};
			string[] array3 = new string[]
			{
				"道具类型ID",
				"ID_"
			};
			string[] array4 = new string[]
			{
				"道具序号",
				"xh"
			};
			string[] array5 = new string[]
			{
				"道具位置",
				"wz"
			};
			string[] array6 = new string[]
			{
				"道具数量",
				"sl"
			};
			json = json.Replace(array3[0], array3[1]);
			json = json.Replace(array4[0], array4[1]);
			json = json.Replace(array5[0], array5[1]);
			json = json.Replace(array6[0], array6[1]);
			json = json.Replace(array[0], array[1]);
			json = json.Replace(array2[0], array2[1]);
			return json;
		}

		public string 解压道具JSON(string json)
		{
			string[] array = new string[]
			{
				"\"},{\"",
				"fg"
			};
			string[] array2 = new string[]
			{
				"\":\"",
				"'"
			};
			string[] array3 = new string[]
			{
				"道具类型ID",
				"ID_"
			};
			string[] array4 = new string[]
			{
				"道具序号",
				"xh"
			};
			string[] array5 = new string[]
			{
				"道具位置",
				"wz"
			};
			string[] array6 = new string[]
			{
				"道具数量",
				"sl"
			};
			json = json.Replace(array3[1], array3[0]);
			json = json.Replace(array4[1], array4[0]);
			json = json.Replace(array5[1], array5[0]);
			json = json.Replace(array6[1], array6[0]);
			json = json.Replace(array[1], array[0]);
			json = json.Replace(array2[1], array2[0]);
			return json;
		}

		public 道具信息 取指定道具(string 道具序号, bool 缓存)
		{
			List<道具信息> list = 数据处理._玩家道具;
			bool flag = !缓存;
			if (flag)
			{
				list = this.取玩家所有道具_();
			}
			道具信息 result;
			foreach (道具信息 current in list)
			{
				bool flag2 = current.道具序号.Equals(道具序号);
				if (flag2)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public 道具信息 取指定道具_按类型(string 道具类型)
		{
			List<道具信息> list = this.取玩家所有道具_();
			道具信息 result;
			foreach (道具信息 current in list)
			{
				bool flag = current.道具类型ID.Equals(道具类型);
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public 道具类型 取指定道具类型(string 道具序号)
		{
			List<道具类型> list = this.读取所有道具类型();
			道具类型 result;
			foreach (道具类型 current in list)
			{
				bool flag = current.道具序号.Equals(道具序号);
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public void 道具使用(string 序号, int 数量)
		{
			道具信息 道具信息 = this.取指定道具(序号, false);
			bool flag = Convert.ToInt32(道具信息.道具数量) <= 数量;
			if (flag)
			{
				this.删除道具(道具信息);
			}
			else
			{
				道具信息.道具数量 = (Convert.ToInt32(道具信息.道具数量) - 数量).ToString();
				this.修改道具(道具信息);
			}
		}

		public void 道具使用_按类型(string 序号, int 数量)
		{
			道具信息 道具信息 = this.取指定道具_按类型(序号);
			bool flag = Convert.ToInt32(道具信息.道具数量) <= 数量;
			if (flag)
			{
				this.删除道具(道具信息);
			}
			else
			{
				道具信息.道具数量 = (Convert.ToInt32(道具信息.道具数量) - 数量).ToString();
				this.修改道具(道具信息);
			}
		}

		public 宠物类型 取指定宠物类型(string 类型序号)
		{
			bool flag = 数据处理.临时宠物类型 != null;
			List<宠物类型> list;
			if (flag)
			{
				list = 数据处理.临时宠物类型;
			}
			else
			{
				list = this.读取宠物类型();
			}
			宠物类型 result;
			foreach (宠物类型 current in list)
			{
				bool flag2 = current.宠物序号.Equals(类型序号);
				if (flag2)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<宠物类型> 读取宠物类型()
		{
			List<宠物类型> result;
			try
			{
				bool flag = 数据处理._宠物类型 != null && 数据处理.z;
				if (flag)
				{
					result = 数据处理._宠物类型;
				}
				else
				{
					string text = this.读取文件(数据处理.宠物定义配置路径);
					text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
					string[] array = text.Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None);
					数据处理._宠物类型 = new List<宠物类型>();
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text2 = array2[i];
						string[] array3 = text2.Split(new char[]
						{
							'，'
						});
						bool flag2 = array3.Length >= 3;
						if (flag2)
						{
							宠物类型 宠物类型 = new 宠物类型();
							宠物类型.宠物名字 = array3[1];
							宠物类型.宠物序号 = array3[0];
							宠物类型.系别 = array3[2];
							宠物类型.默认技能 = new List<string>();
							bool flag3 = array3.Length >= 5;
							if (flag3)
							{
								string[] array4 = array3[4].Split(new char[]
								{
									'|'
								});
								string[] array5 = array4;
								for (int j = 0; j < array5.Length; j++)
								{
									string text3 = array5[j];
									bool flag4 = RC4.是否为数值(text3);
									if (flag4)
									{
										宠物类型.默认技能.Add(text3);
									}
								}
							}
							bool flag5 = array3.Length >= 4;
							if (flag5)
							{
								宠物类型.阶数 = array3[3];
							}
							else
							{
								宠物类型.阶数 = "11";
							}
							数据处理._宠物类型.Add(宠物类型);
						}
					}
					result = 数据处理._宠物类型;
				}
			}
			catch (Exception var_17_192)
			{
				result = new List<宠物类型>();
			}
			return result;
		}

		public string 读取文件(string name)
		{
			bool flag = !File.Exists(name);
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = "";
				using (StreamReader streamReader = new StreamReader(name))
				{
					string str;
					while ((str = streamReader.ReadLine()) != null)
					{
						text += str;
					}
				}
				result = text;
			}
			return result;
		}

		public string 读取文件(string name, bool utf8)
		{
			bool flag = !File.Exists(name);
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = "";
				using (StreamReader streamReader = new StreamReader(name))
				{
					text = streamReader.ReadToEnd();
				}
				result = text;
			}
			return result;
		}

		public List<宠物信息> 读取宠物列表_(bool 强制更新)
		{
			bool flag = !强制更新;
			if (flag)
			{
			}
			bool flag2 = 数据处理._宠物列表.Count != 0 && 数据处理.z;
			List<宠物信息> result;
			if (flag2)
			{
				result = 数据处理._宠物列表;
			}
			else
			{
				string text = this.getStr();
				bool flag3 = text == null;
				if (flag3)
				{
					result = new List<宠物信息>();
				}
				else
				{
					string[] array = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					text = array[2];
					List<宠物信息> list = new List<宠物信息>();
					bool flag4 = text != null && text != "";
					if (flag4)
					{
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(2));
						text = this.解压宠物JSON(text);
						text = text.Replace("\"\"", "\"0\"");
						list = JsonConvert.DeserializeObject<List<宠物信息>>(text, new JsonSerializerSettings
						{
							DefaultValueHandling = DefaultValueHandling.Include,
							NullValueHandling = NullValueHandling.Ignore
						});
					}
					数据处理._宠物列表 = list;
					result = list;
				}
			}
			return result;
		}

		public string 压缩宠物JSON(string json)
		{
			string[] array = new string[]
			{
				"宠物序号",
				"id"
			};
			string[] array2 = new string[]
			{
				"形象",
				"xx"
			};
			string[] array3 = new string[]
			{
				"等级",
				"dj"
			};
			string[] array4 = new string[]
			{
				"五行",
				"wx"
			};
			string[] array5 = new string[]
			{
				"生命",
				"sm"
			};
			string[] array6 = new string[]
			{
				"魔法",
				"mf"
			};
			string[] array7 = new string[]
			{
				"当前经验",
				"jy"
			};
			string[] array8 = new string[]
			{
				"最大生命",
				"sm1"
			};
			string[] array9 = new string[]
			{
				"最大魔法",
				"mf1"
			};
			string[] array10 = new string[]
			{
				"攻击",
				"gj"
			};
			string[] array11 = new string[]
			{
				"防御",
				"fy"
			};
			string[] array12 = new string[]
			{
				"闪避",
				"sb"
			};
			string[] array13 = new string[]
			{
				"速度",
				"sd"
			};
			string[] array14 = new string[]
			{
				"状态",
				"zt"
			};
			string[] array15 = new string[]
			{
				"宠物名字",
				"mz"
			};
			string[] array16 = new string[]
			{
				"位置",
				"wz"
			};
			string[] array17 = new string[]
			{
				"成长",
				"cz"
			};
			string[] array18 = new string[]
			{
				"命中",
				"mz1"
			};
			string[] array19 = new string[]
			{
				"\"},{\"",
				"fg"
			};
			string[] array20 = new string[]
			{
				"\":\"",
				"'"
			};
			json = json.Replace(array[0], array[1]);
			json = json.Replace(array2[0], array2[1]);
			json = json.Replace(array3[0], array3[1]);
			json = json.Replace(array4[0], array4[1]);
			json = json.Replace(array8[0], array8[1]);
			json = json.Replace(array9[0], array9[1]);
			json = json.Replace(array5[0], array5[1]);
			json = json.Replace(array6[0], array6[1]);
			json = json.Replace(array10[0], array10[1]);
			json = json.Replace(array11[0], array11[1]);
			json = json.Replace(array12[0], array12[1]);
			json = json.Replace(array13[0], array13[1]);
			json = json.Replace(array14[0], array14[1]);
			json = json.Replace(array15[0], array15[1]);
			json = json.Replace(array16[0], array16[1]);
			json = json.Replace(array17[0], array17[1]);
			json = json.Replace(array18[0], array18[1]);
			json = json.Replace(array7[0], array7[1]);
			json = json.Replace(array19[0], array19[1]);
			json = json.Replace(array20[0], array20[1]);
			return json;
		}

		public string 解压宠物JSON(string json)
		{
			string[] array = new string[]
			{
				"\"},{\"",
				"fg"
			};
			string[] array2 = new string[]
			{
				"宠物序号",
				"id"
			};
			string[] array3 = new string[]
			{
				"形象",
				"xx"
			};
			string[] array4 = new string[]
			{
				"等级",
				"dj"
			};
			string[] array5 = new string[]
			{
				"当前经验",
				"jy"
			};
			string[] array6 = new string[]
			{
				"五行",
				"wx"
			};
			string[] array7 = new string[]
			{
				"生命",
				"sm"
			};
			string[] array8 = new string[]
			{
				"魔法",
				"mf"
			};
			string[] array9 = new string[]
			{
				"最大生命",
				"sm1"
			};
			string[] array10 = new string[]
			{
				"最大魔法",
				"mf1"
			};
			string[] array11 = new string[]
			{
				"攻击",
				"gj"
			};
			string[] array12 = new string[]
			{
				"防御",
				"fy"
			};
			string[] array13 = new string[]
			{
				"闪避",
				"sb"
			};
			string[] array14 = new string[]
			{
				"速度",
				"sd"
			};
			string[] array15 = new string[]
			{
				"状态",
				"zt"
			};
			string[] array16 = new string[]
			{
				"宠物名字",
				"mz"
			};
			string[] array17 = new string[]
			{
				"位置",
				"wz"
			};
			string[] array18 = new string[]
			{
				"成长",
				"cz"
			};
			string[] array19 = new string[]
			{
				"命中",
				"mz1"
			};
			string[] array20 = new string[]
			{
				"\":\"",
				"'"
			};
			json = json.Replace(array[1], array[0]);
			json = json.Replace(array20[1], array20[0]);
			json = json.Replace(array2[1], array2[0]);
			json = json.Replace(array3[1], array3[0]);
			json = json.Replace(array4[1], array4[0]);
			json = json.Replace(array6[1], array6[0]);
			json = json.Replace(array9[1], array9[0]);
			json = json.Replace(array10[1], array10[0]);
			json = json.Replace(array7[1], array7[0]);
			json = json.Replace(array8[1], array8[0]);
			json = json.Replace(array19[1], array19[0]);
			json = json.Replace(array11[1], array11[0]);
			json = json.Replace(array12[1], array12[0]);
			json = json.Replace(array13[1], array13[0]);
			json = json.Replace(array14[1], array14[0]);
			json = json.Replace(array15[1], array15[0]);
			json = json.Replace(array16[1], array16[0]);
			json = json.Replace(array17[1], array17[0]);
			json = json.Replace(array18[1], array18[0]);
			json = json.Replace(array5[1], array5[0]);
			return json;
		}

		public 用户信息 读取用户信息()
		{
			return new 用户信息
			{
				名字 = "购买修改器,有没有想过作者的感受?",
				刷怪数 = "你手中用出去的每一分钱都在为你想看到的世界投票."
			};
		}

		public 用户信息 读取用户信息_()
		{
			bool flag = 数据处理._用户存档 != null && 数据处理.z;
			用户信息 result;
			if (flag)
			{
				result = 数据处理._用户存档;
			}
			else
			{
				string text = this.getStr();
				bool flag2 = text == null;
				if (flag2)
				{
					result = new 用户信息();
				}
				else
				{
					string[] array = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					text = array[0];
					text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(0));
					用户信息 用户信息 = new 用户信息();
					bool flag3 = text != null && text != "";
					if (flag3)
					{
						用户信息 = JsonConvert.DeserializeObject<用户信息>(text);
						bool flag4 = 用户信息.金币.IndexOf("-") != -1;
						if (flag4)
						{
							用户信息.金币 = 2147483647.ToString();
						}
					}
					result = 用户信息;
				}
			}
			return result;
		}

		public 宠物信息 读取指定宠物(string 宠物序号, List<宠物信息> 宠物列表)
		{
			宠物信息 宠物信息 = new 宠物信息();
			bool flag = 宠物列表 == null;
			if (flag)
			{
				宠物列表 = this.读取宠物列表_(false);
			}
			宠物信息 result;
			foreach (宠物信息 current in 宠物列表)
			{
				bool flag2 = current.宠物序号.Equals(宠物序号);
				if (flag2)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<宠物信息> 读取背包宠物()
		{
			List<宠物信息> list = new List<宠物信息>();
			用户信息 用户信息 = this.读取用户信息_();
			bool flag = 用户信息.宠物1 != null && 用户信息.宠物1 != "Null";
			if (flag)
			{
				宠物信息 宠物信息 = this.读取指定宠物(用户信息.宠物1, null);
				bool flag2 = 宠物信息 != null;
				if (flag2)
				{
					list.Add(宠物信息);
				}
			}
			bool flag3 = 用户信息.宠物2 != null && 用户信息.宠物2 != "Null";
			if (flag3)
			{
				宠物信息 宠物信息2 = this.读取指定宠物(用户信息.宠物2, null);
				bool flag4 = 宠物信息2 != null;
				if (flag4)
				{
					list.Add(宠物信息2);
				}
			}
			bool flag5 = 用户信息.宠物3 != null && 用户信息.宠物3 != "Null";
			if (flag5)
			{
				宠物信息 宠物信息3 = this.读取指定宠物(用户信息.宠物3, null);
				bool flag6 = 宠物信息3 != null;
				if (flag6)
				{
					list.Add(宠物信息3);
				}
			}
			foreach (宠物信息 current in list)
			{
				current.状态 = "1";
				bool flag7 = current.宠物序号 == 用户信息.主宠物;
				if (flag7)
				{
					current.状态 = "0";
				}
			}
			return list;
		}

		public bool 保存宠物存档(List<宠物信息> 宠物列表, bool 强制更新)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			bool result;
			try
			{
				bool flag = 宠物列表 == null;
				if (flag)
				{
					result = false;
				}
				else
				{
					this.读取宠物列表_(false);
					数据处理._宠物列表 = 宠物列表;
					string text = this.jsonTo.getpetJSON(宠物列表, false);
					string str = this.getStr();
					string[] array = str.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					array[2] = text;
					text = this.拼接存档(array, true, null);
					this.保存文件(text, 数据处理.总存档路径);
					stopwatch.Stop();
					Console.WriteLine("Total：" + stopwatch.ElapsedMilliseconds + "ms");
					result = true;
				}
			}
			catch (Exception var_6_A2)
			{
				result = false;
			}
			return result;
		}

		public bool 更新指定宠物存档(string 宠物序号, 宠物信息 宠物)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			List<宠物信息> list = this.读取宠物列表_(false);
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].宠物序号.Equals(宠物序号);
				if (flag)
				{
					list[i] = 宠物;
				}
			}
			bool result = this.保存宠物存档(list, false);
			stopwatch.Stop();
			Console.WriteLine("Total：" + stopwatch.ElapsedMilliseconds + "ms");
			return result;
		}

		public bool 修改宠物属性(string 宠物序号, int 属性类型, long 属性增幅)
		{
			宠物信息 宠物信息 = this.读取指定宠物(宠物序号, null);
			bool flag = 属性类型 == 宠物属性类型.当前经验;
			if (flag)
			{
				bool flag2 = !RC4.是否为数值(宠物信息.当前经验);
				if (flag2)
				{
					宠物信息.当前经验 = "0";
				}
				宠物信息.当前经验 = (Convert.ToInt64(宠物信息.当前经验) + 属性增幅).ToString();
				bool flag3 = Convert.ToInt64(宠物信息.当前经验) < -100000000L;
				if (flag3)
				{
					宠物信息.当前经验 = 2147483647.ToString();
				}
			}
			else
			{
				bool flag4 = 属性类型 == 宠物属性类型.防御;
				if (flag4)
				{
					bool flag5 = !RC4.是否为数值(宠物信息.防御);
					if (flag5)
					{
						宠物信息.防御 = "0";
					}
					宠物信息 expr_B7 = 宠物信息;
					expr_B7.防御 += ((long)Convert.ToInt32(宠物信息.防御) + 属性增幅).ToString();
				}
				else
				{
					bool flag6 = 属性类型 == 宠物属性类型.攻击;
					if (flag6)
					{
						bool flag7 = !RC4.是否为数值(宠物信息.攻击);
						if (flag7)
						{
							宠物信息.攻击 = "0";
						}
						宠物信息 expr_114 = 宠物信息;
						expr_114.攻击 += ((long)Convert.ToInt32(宠物信息.攻击) + 属性增幅).ToString();
					}
					else
					{
						bool flag8 = 属性类型 == 宠物属性类型.魔法;
						if (flag8)
						{
							bool flag9 = !RC4.是否为数值(宠物信息.魔法);
							if (flag9)
							{
								宠物信息.魔法 = "0";
							}
							宠物信息 expr_171 = 宠物信息;
							expr_171.魔法 += ((long)Convert.ToInt32(宠物信息.魔法) + 属性增幅).ToString();
						}
						else
						{
							bool flag10 = 属性类型 == 宠物属性类型.闪避;
							if (flag10)
							{
								bool flag11 = !RC4.是否为数值(宠物信息.闪避);
								if (flag11)
								{
									宠物信息.闪避 = "0";
								}
								宠物信息 expr_1CF = 宠物信息;
								expr_1CF.闪避 += ((long)Convert.ToInt32(宠物信息.闪避) + 属性增幅).ToString();
							}
							else
							{
								bool flag12 = 属性类型 == 宠物属性类型.生命;
								if (flag12)
								{
									bool flag13 = !RC4.是否为数值(宠物信息.生命);
									if (flag13)
									{
										宠物信息.生命 = "0";
									}
									宠物信息 expr_22D = 宠物信息;
									expr_22D.生命 += ((long)Convert.ToInt32(宠物信息.生命) + 属性增幅).ToString();
								}
								else
								{
									bool flag14 = 属性类型 == 宠物属性类型.速度;
									if (flag14)
									{
										bool flag15 = !RC4.是否为数值(宠物信息.速度);
										if (flag15)
										{
											宠物信息.速度 = "0";
										}
										宠物信息 expr_28B = 宠物信息;
										expr_28B.速度 += ((long)Convert.ToInt32(宠物信息.速度) + 属性增幅).ToString();
									}
									else
									{
										bool flag16 = 属性类型 == 宠物属性类型.最大魔法;
										if (flag16)
										{
											bool flag17 = !RC4.是否为数值(宠物信息.最大魔法);
											if (flag17)
											{
												宠物信息.最大魔法 = "0";
											}
											宠物信息 expr_2E9 = 宠物信息;
											expr_2E9.最大魔法 += ((long)Convert.ToInt32(宠物信息.最大魔法) + 属性增幅).ToString();
										}
										else
										{
											bool flag18 = 属性类型 == 宠物属性类型.最大生命;
											if (flag18)
											{
												bool flag19 = !RC4.是否为数值(宠物信息.最大生命);
												if (flag19)
												{
													宠物信息.最大生命 = "0";
												}
												宠物信息 expr_347 = 宠物信息;
												expr_347.最大生命 += ((long)Convert.ToInt32(宠物信息.最大生命) + 属性增幅).ToString();
											}
											else
											{
												bool flag20 = 属性类型 == 宠物属性类型.等级;
												if (flag20)
												{
													bool flag21 = !RC4.是否为数值(宠物信息.当前经验);
													if (flag21)
													{
														宠物信息.当前经验 = "0";
													}
													宠物信息.当前经验 = (Convert.ToInt64(宠物信息.当前经验) + 7777L * 属性增幅).ToString();
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return this.更新指定宠物存档(宠物序号, 宠物信息);
		}

		public bool 修改宠物属性(string 宠物序号, int 属性类型, double 属性增幅)
		{
			宠物信息 宠物信息 = this.读取指定宠物(宠物序号, null);
			bool flag = 属性类型 == 宠物属性类型.成长;
			bool result;
			if (flag)
			{
				宠物信息.成长 = (Convert.ToDouble(宠物信息.成长) + 属性增幅).ToString();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public string getKey(int 下标)
		{
			string text = this.读取文件(数据处理.总存档路径);
			bool flag = text == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string text2 = "";
				bool flag2 = text.IndexOf("9527OA") != -1;
				if (flag2)
				{
					string[] array = text.Split(new string[]
					{
						"9527OA"
					}, StringSplitOptions.None);
					text = array[0];
					text2 = array[1];
				}
				string[] array2 = text.Split(new string[]
				{
					"O4F89"
				}, StringSplitOptions.None);
				bool flag3 = array2.Length > 下标;
				if (flag3)
				{
					string[] array3 = array2[下标].Split(new string[]
					{
						"O19A87"
					}, StringSplitOptions.None);
					bool flag4 = array3.Length != 2;
					if (flag4)
					{
						result = "";
						return result;
					}
					text2 = array3[1];
				}
				result = text2;
			}
			return result;
		}

		public string getHash()
		{
			string text = this.读取文件(数据处理.总存档路径);
			bool flag = text == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				string text2 = "";
				bool flag2 = text.IndexOf("9527OA") != -1;
				if (flag2)
				{
					string[] array = text.Split(new string[]
					{
						"9527OA"
					}, StringSplitOptions.None);
					text = array[0];
					text2 = array[1];
				}
				result = text2;
			}
			return result;
		}

		public string getStr()
		{
			string fileHash = 数据处理.GetFileHash(数据处理.总存档路径);
			string text = this.读取文件(数据处理.总存档路径);
			bool flag = text == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = text.IndexOf("9527OA") != -1;
				if (flag2)
				{
					string[] array = text.Split(new string[]
					{
						"9527OA"
					}, StringSplitOptions.None);
					text = array[0];
					bool flag3 = !this.getHash().Equals(RC4.EncryptRC4wq(数据处理.GetStringHash(text), 数据处理.存档密钥 + "MaskSB"));
					if (flag3)
					{
						Environment.Exit(0);
						result = null;
						return result;
					}
					string text2 = array[1];
				}
				result = text;
			}
			return result;
		}

		public string 拼接存档(string[] 存档组, bool 密钥, string 存档版本)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			if (密钥)
			{
				text4 = 数据处理.随机数产生器.Next(10000000, 99000000).ToString();
				text4 = RC4.EncryptRC4wq(text4, 数据处理.存档密钥);
			}
			for (int i = 0; i < 存档组.Length; i++)
			{
				bool flag = 存档组[i].IndexOf("{") != -1 || 存档组[i].IndexOf("[") != -1;
				if (flag)
				{
					存档组[i] = RC4.EncryptRC4wq(存档组[i], 数据处理.存档密钥 + text4) + "O19A87" + text4;
				}
			}
			bool flag2 = 存档版本 == null;
			if (flag2)
			{
				存档版本 = RC4.EncryptRC4wq(数据处理.存档版本号.ToString(), 数据处理.存档密钥 + text4) + "O19A87" + text4;
			}
			bool flag3 = 存档组.Length >= 5;
			if (flag3)
			{
				text = 存档组[4];
			}
			bool flag4 = 存档组.Length >= 6;
			if (flag4)
			{
				text2 = 存档组[5];
			}
			bool flag5 = 存档组.Length >= 7;
			if (flag5)
			{
				text3 = 存档组[6];
			}
			string text5 = string.Concat(new string[]
			{
				存档组[0],
				"O4F89",
				存档组[1],
				"O4F89",
				存档组[2],
				"O4F89",
				存档版本,
				"O4F89",
				text,
				"O4F89",
				text2,
				"O4F89",
				text3
			});
			string stringHash = 数据处理.GetStringHash(text5);
			return text5 + "9527OA" + RC4.EncryptRC4wq(stringHash, 数据处理.存档密钥 + "MaskSB");
		}

		public string 获取存档版本号()
		{
			bool flag = !File.Exists(数据处理.总存档路径);
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string text = "";
				using (StreamReader streamReader = new StreamReader(数据处理.总存档路径))
				{
					string str;
					while ((str = streamReader.ReadLine()) != null)
					{
						text += str;
					}
				}
				bool flag2 = text == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					string text2 = text;
					string str2 = "";
					bool flag3 = text2.IndexOf("9527OA") != -1;
					if (flag3)
					{
						string[] array = text2.Split(new string[]
						{
							"9527OA"
						}, StringSplitOptions.None);
						text2 = array[0];
						str2 = array[1];
					}
					string[] array2 = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					bool flag4 = array2.Length > 3;
					if (flag4)
					{
						str2 = array2[3].Split(new string[]
						{
							"O19A87"
						}, StringSplitOptions.None)[1];
					}
					text = RC4.DecryptRC4wq(array2[3], 数据处理.存档密钥 + str2);
					result = text;
				}
			}
			return result;
		}

		public List<宠物信息> 取仓库内的宠物()
		{
			List<宠物信息> list = this.读取宠物列表_(false);
			List<宠物信息> list2 = new List<宠物信息>();
			用户信息 用户信息 = this.读取用户信息_();
			foreach (宠物信息 current in list)
			{
				bool flag = current.宠物序号 != 用户信息.宠物1 && current.宠物序号 != 用户信息.宠物2 && current.宠物序号 != 用户信息.宠物3 && current.宠物序号 != 用户信息.主宠物;
				if (flag)
				{
					list2.Add(current);
				}
			}
			this.写宠物仓库缓存(list2);
			return list2;
		}

		public bool 写宠物仓库缓存(List<宠物信息> 宠物列表)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string text = this.读取文件(Environment.CurrentDirectory.ToString() + "\\PageMain\\Pasture.html", true);
			string text2 = this.jsonTo.getpetJSON(宠物列表, false);
			text2 = text2.Replace("\"", "\\\"");
			text = text.Replace("%load%", text2);
			this.保存文件(text, 数据处理.宠物仓库缓存路径);
			Console.WriteLine("保存仓库耗时:" + stopwatch.ElapsedMilliseconds + "ms");
			return true;
		}

		public string 增加宠物_(宠物信息 宠物)
		{
			List<宠物信息> list = this.读取宠物列表_(false);
			bool flag = list.Count >= 61;
			string result;
			if (flag)
			{
				result = "-1";
			}
			else
			{
				bool flag2 = list == null;
				if (flag2)
				{
					list = new List<宠物信息>();
				}
				int num = 0;
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				while (this.读取指定宠物(宠物.宠物序号, list) != null)
				{
					num++;
					宠物.宠物序号 = num.ToString();
				}
				stopwatch.Stop();
				Console.WriteLine("自增ID耗时:" + stopwatch.ElapsedMilliseconds + "MS");
				list.Add(宠物);
				bool flag3 = this.保存宠物存档(list, false);
				this.学习默认技能(宠物.宠物序号);
				result = 宠物.宠物序号;
			}
			return result;
		}

		public List<道具信息> 根据图标取道具(string 图标ID)
		{
			List<道具信息> list = this.取玩家所有道具_();
			List<道具信息> list2 = new List<道具信息>();
			foreach (道具信息 current in list)
			{
				bool flag = current.道具图标.Equals(图标ID);
				if (flag)
				{
					list2.Add(current);
				}
			}
			return list2;
		}

		public 副本进度 取地图层数(string 地图ID)
		{
			List<副本进度> list = new List<副本进度>();
			string text = this.getStr();
			bool flag = text == null;
			副本进度 result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string[] array = text.Split(new string[]
				{
					"O4F89"
				}, StringSplitOptions.None);
				text = array[5];
				bool flag2 = text != null && text != "";
				if (flag2)
				{
					text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(5));
					try
					{
						list = JsonConvert.DeserializeObject<List<副本进度>>(text);
						foreach (副本进度 current in list)
						{
							bool flag3 = current.id == 地图ID;
							if (flag3)
							{
								result = current;
								return result;
							}
						}
					}
					catch
					{
						result = null;
						return result;
					}
				}
				result = null;
			}
			return result;
		}

		public List<副本进度> 取进度列表()
		{
			List<副本进度> list = new List<副本进度>();
			string text = this.getStr();
			bool flag = text == null;
			List<副本进度> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string[] array = text.Split(new string[]
				{
					"O4F89"
				}, StringSplitOptions.None);
				text = array[5];
				bool flag2 = text != null && text != "";
				if (flag2)
				{
					text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(5));
					try
					{
						list = JsonConvert.DeserializeObject<List<副本进度>>(text);
						result = list;
						return result;
					}
					catch
					{
						result = new List<副本进度>();
						return result;
					}
				}
				result = new List<副本进度>();
			}
			return result;
		}

		public List<进化路线> 获取所有进化路线()
		{
			string text = this.读取文件(数据处理.进化配置);
			bool flag = text == null || text.Length <= 0;
			List<进化路线> result;
			if (flag)
			{
				result = new List<进化路线>();
			}
			else
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				List<进化路线> list = new List<进化路线>();
				list = JsonConvert.DeserializeObject<List<进化路线>>(text);
				result = list;
			}
			return result;
		}

		public 进化路线 取进化路线(string 宠物ID)
		{
			List<进化路线> list = this.获取所有进化路线();
			string 系别 = this.取指定宠物类型(宠物ID).系别;
			进化路线 result;
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].petID.Equals(宠物ID);
				if (flag)
				{
					bool flag2 = list[i].AI == null || list[i].AI == "0" || list[i].AI == "Null" || list[i].AI.Length == 0;
					if (flag2)
					{
						list[i].AI = 宠物ID;
						bool flag3 = 系别.Equals("神") || 系别.Equals("神圣") || 系别.Equals("魔");
						if (flag3)
						{
							list[i].ALV = "60";
							list[i].AP = "2016110546";
						}
						else
						{
							list[i].ALV = "40";
							list[i].AP = "2016110512";
						}
					}
					bool flag4 = list[i].BI == null || list[i].BI == "0" || list[i].BI == "Null" || list[i].BI.Length == 0;
					if (flag4)
					{
						list[i].BI = 宠物ID;
						bool flag5 = 系别.Equals("神") || 系别.Equals("神圣") || 系别.Equals("魔");
						if (flag5)
						{
							list[i].BLV = "60";
							list[i].BP = "2016110547";
						}
						else
						{
							list[i].BLV = "40";
							list[i].BP = "2016110513";
						}
					}
					result = list[i];
					return result;
				}
			}
			进化路线 进化路线 = new 进化路线();
			进化路线.AI = 宠物ID;
			进化路线.BI = 宠物ID;
			bool flag6 = 系别.Equals("神") || 系别.Equals("神圣") || 系别.Equals("魔");
			if (flag6)
			{
				进化路线.ALV = "60";
				进化路线.AP = "2016110546";
				进化路线.BLV = "60";
				进化路线.BP = "2016110547";
			}
			else
			{
				进化路线.ALV = "40";
				进化路线.AP = "2016110512";
				进化路线.BLV = "40";
				进化路线.BP = "2016110513";
			}
			result = 进化路线;
			return result;
		}

		public List<合成公式> 取所有合成公式()
		{
			string text = this.读取文件(数据处理.合成配置);
			bool flag = text == null || text.Length <= 0;
			List<合成公式> result;
			if (flag)
			{
				result = new List<合成公式>();
			}
			else
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				List<合成公式> list = new List<合成公式>();
				list = JsonConvert.DeserializeObject<List<合成公式>>(text);
				result = list;
			}
			return result;
		}

		public string 取合成公式(宠物信息 主宠, 宠物信息 副宠)
		{
			string text = "";
			List<合成公式> list = this.取所有合成公式();
			string result;
			foreach (合成公式 current in list)
			{
				bool flag = current.AP.Equals(主宠.形象);
				if (flag)
				{
					bool flag2 = current.APC != null && Convert.ToDouble(current.APC) > Convert.ToDouble(主宠.成长);
					if (flag2)
					{
						result = "主宠成长不足！";
						return result;
					}
					bool flag3 = current.APL != null && Convert.ToDouble(current.APL) > Convert.ToDouble(主宠.等级);
					if (flag3)
					{
						result = "主宠等级不足！";
						return result;
					}
					bool flag4 = current.BP != null && current.BP.Equals(副宠.形象);
					if (flag4)
					{
						bool flag5 = current.BPC != null && Convert.ToDouble(current.BPC) > Convert.ToDouble(副宠.成长);
						if (flag5)
						{
							result = "副宠成长不足！";
							return result;
						}
						bool flag6 = current.BPL != null && Convert.ToDouble(current.BPL) > Convert.ToDouble(副宠.等级);
						if (flag6)
						{
							result = "副宠等级不足！";
							return result;
						}
						bool flag7 = current.Yi != null;
						if (flag7)
						{
							text = current.Yi;
						}
						bool flag8 = current.Er != null;
						if (flag8)
						{
							bool flag9 = text.Equals("");
							if (flag9)
							{
								text = current.Er;
							}
							else
							{
								text += "|";
								text += current.Er;
							}
						}
						result = text;
						return result;
					}
					else
					{
						宠物类型 宠物类型 = new 数据处理().取指定宠物类型(副宠.形象);
						bool flag10 = current.BPJS != null && current.BPJS.Equals(宠物类型.阶数);
						if (flag10)
						{
							bool flag11 = current.Yi != null;
							if (flag11)
							{
								text = current.Yi;
							}
							bool flag12 = current.Er != null;
							if (flag12)
							{
								bool flag13 = text.Equals("");
								if (flag13)
								{
									text = current.Er;
								}
								else
								{
									text += "|";
									text += current.Er;
								}
							}
							result = text;
							return result;
						}
						bool flag14 = current.San != null;
						if (flag14)
						{
							result = current.San;
							return result;
						}
						result = null;
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		public List<任务信息> 取所有任务定义()
		{
			string text = this.读取文件(数据处理.任务定义配置路径 + "\\_0.dat");
			List<任务信息> result = new List<任务信息>();
			bool flag = text != null && text.Length > 0;
			if (flag)
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				result = JsonConvert.DeserializeObject<List<任务信息>>(text);
			}
			return result;
		}

		public List<任务信息> 取所有可领取任务()
		{
			string text = this.读取文件(数据处理.任务定义配置路径 + "\\_0.dat");
			List<任务信息> list = this.取玩家已领的任务();
			List<任务信息> list2 = new List<任务信息>();
			List<任务信息> list3 = new List<任务信息>();
			bool flag = text != null && text.Length > 0;
			if (flag)
			{
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				list2 = JsonConvert.DeserializeObject<List<任务信息>>(text);
				foreach (任务信息 current in list2)
				{
					bool flag2 = true;
					bool flag3 = false;
					foreach (任务信息 current2 in list)
					{
						bool flag4 = current.前置任务 != null && current.前置任务.Length > 0 && current.前置任务 != "-1";
						if (flag4)
						{
							bool flag5 = current.前置任务 == current2.任务序号 && current2.已完成 == "0";
							if (flag5)
							{
								flag3 = true;
							}
						}
						bool flag6 = current.任务序号 == current2.任务序号;
						if (flag6)
						{
							flag2 = false;
							break;
						}
					}
					bool flag7 = (current.前置任务 != null && current.前置任务.Length > 0 && current.前置任务 != "-1") & flag2;
					if (flag7)
					{
						flag2 = flag3;
					}
					bool flag8 = flag2;
					if (flag8)
					{
						current.任务目标 = null;
						current.任务奖励 = "";
						current.允许重复 = "";
						list3.Add(current);
					}
				}
			}
			return list3;
		}

		public 任务信息 取指定任务定义(string 序号)
		{
			List<任务信息> list = this.取所有任务定义();
			任务信息 result;
			foreach (任务信息 current in list)
			{
				bool flag = current.任务序号 == 序号;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public bool 增加任务定义(任务信息 任务, string 任务说明)
		{
			List<任务信息> list = this.取所有任务定义();
			bool result;
			foreach (任务信息 current in list)
			{
				bool flag = current.任务序号 == 任务.任务序号;
				if (flag)
				{
					result = false;
					return result;
				}
			}
			this.保存文件(RC4.EncryptRC4wq(任务说明, 数据处理.存档密钥), 数据处理.任务定义配置路径 + "/" + 任务.任务序号 + "_.dat");
			list.Add(任务);
			this.保存任务定义(list);
			result = true;
			return result;
		}

		public string 取任务定义说明(string 任务ID)
		{
			string result;
			try
			{
				string text = this.读取文件(数据处理.任务定义配置路径 + "\\" + 任务ID + "_.dat");
				text = RC4.DecryptRC4wq(text, 数据处理.存档密钥);
				result = text;
			}
			catch
			{
				result = "任务不存在";
			}
			return result;
		}

		public 任务面板 取任务面板(string 任务序号, bool 已接受)
		{
			任务信息 任务信息 = new 任务信息();
			if (已接受)
			{
				任务信息 = this.取指定已领任务(任务序号);
			}
			else
			{
				任务信息 = this.取指定任务定义(任务序号);
			}
			bool flag = 任务信息 == null || 任务信息.任务序号 == null;
			任务面板 result;
			if (flag)
			{
				result = new 任务面板();
			}
			else
			{
				任务面板 任务面板 = new 任务面板();
				任务面板.位置 = 已接受;
				任务面板.任务名字 = 任务信息.任务名;
				任务面板.任务介绍 = this.取任务定义说明(任务序号);
				string text = "";
				string[] array = 任务信息.任务奖励.Split(new char[]
				{
					'|'
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					string[] array3 = text2.Split(new char[]
					{
						','
					});
					bool flag2 = array3.Length == 3;
					if (flag2)
					{
						bool flag3 = array3[0].Equals("道具");
						if (flag3)
						{
							text = string.Concat(new string[]
							{
								text,
								this.取指定道具类型(array3[1]).道具名字,
								" ",
								array3[2],
								"个<br/>"
							});
						}
						else
						{
							bool flag4 = array3[0].Equals("装备");
							if (flag4)
							{
								text = string.Concat(new string[]
								{
									text,
									this.取指定装备类型(array3[1]).名字,
									" ",
									array3[2],
									"个<br/>"
								});
							}
						}
					}
					bool flag5 = array3.Length >= 2;
					if (flag5)
					{
						bool flag6 = array3[0].Equals("金币");
						if (flag6)
						{
							text = text + "金币 " + array3[1] + " 个<br/>";
						}
						else
						{
							bool flag7 = array3[0].Equals("元宝");
							if (flag7)
							{
								text = text + "元宝 " + array3[1] + " 个<br/>";
							}
							else
							{
								bool flag8 = array3[0].Equals("水晶");
								if (flag8)
								{
									text = text + "水晶 " + array3[1] + " 个<br/>";
								}
								else
								{
									bool flag9 = array3[0].Equals("默认技能");
									if (flag9)
									{
										text += "刷新宠物的默认技能(如若没有默认技能或者已经习得技能则不会获得技能)<br/>";
									}
								}
							}
						}
					}
				}
				任务面板.任务奖励 = text;
				string text3 = "";
				List<task> 任务目标 = 任务信息.任务目标;
				try
				{
					foreach (task current in 任务目标)
					{
						bool flag10 = current.Type == "等级";
						if (flag10)
						{
							text3 = text3 + "宠物等级达到 " + current.Num + " 级 <br/>";
						}
						else
						{
							bool flag11 = current.Type == "击杀";
							if (flag11)
							{
								text3 = string.Concat(new string[]
								{
									text3,
									"击杀 ",
									this.取指定怪物类型(current.ID).怪物名字,
									"&nbsp;",
									current.Num,
									"个 <br/>"
								});
							}
							else
							{
								bool flag12 = current.Type == "收集";
								if (flag12)
								{
									text3 = string.Concat(new string[]
									{
										text3,
										"收集 ",
										this.取指定道具类型(current.ID).道具名字,
										"&nbsp;",
										current.Num,
										"个 <br/>"
									});
								}
								else
								{
									bool flag13 = current.Type == "金币";
									if (flag13)
									{
										text3 = text3 + "收集 金币&nbsp;" + current.Num + "个 <br/>";
									}
									else
									{
										bool flag14 = current.Type == "元宝";
										if (flag14)
										{
											text3 = text3 + "收集 元宝&nbsp;" + current.Num + "个 <br/>";
										}
										else
										{
											bool flag15 = current.Type == "水晶";
											if (flag15)
											{
												text3 = text3 + "收集 水晶&nbsp;" + current.Num + "个 <br/>";
											}
											else
											{
												bool flag16 = current.Type == "宠物";
												if (flag16)
												{
													text3 = string.Concat(new string[]
													{
														text3,
														"宠物 ",
														this.取指定宠物类型(current.ID).宠物名字,
														"&nbsp;达到",
														current.Num,
														"CC（任务完成后保留10%）"
													});
												}
												else
												{
													bool flag17 = current.Type == "装备";
													if (flag17)
													{
														text3 = text3 + "收集 " + this.取指定装备类型(current.ID).名字 + "&nbsp;1件 <br/>";
													}
													else
													{
														bool flag18 = current.Type == "时间";
														if (flag18)
														{
															text3 = string.Concat(new string[]
															{
																text3,
																"任务必须在 ",
																current.Num,
																" 之前完成(包含",
																current.Num,
																")<br/>"
															});
														}
														else
														{
															bool flag19 = current.Type == "地狱";
															if (flag19)
															{
																text3 = text3 + "地狱之门达到 " + current.Num + " 层 <br/>";
															}
															else
															{
																bool flag20 = current.Type == "VIP";
																if (flag20)
																{
																	text3 = text3 + "VIP等级达到 " + current.Num + " 级 <br/>";
																}
																else
																{
																	bool flag21 = current.Type == "积分";
																	if (flag21)
																	{
																		text3 = text3 + "VIP积分达到 " + current.Num + " 分 <br/>";
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				catch (Exception var_40_5D9)
				{
				}
				任务面板.任务目标 = text3;
				string text4 = "";
				用户信息 用户信息 = this.读取用户信息_();
				任务信息 任务信息2 = this.取指定已领任务(任务序号);
				int num = 0;
				int num2 = 0;
				foreach (task current2 in 任务目标)
				{
					bool flag22 = current2.Type == "等级";
					if (flag22)
					{
						宠物信息 宠物信息 = this.读取指定宠物(用户信息.主宠物, null);
						text4 = string.Concat(new string[]
						{
							text4,
							"等级达到 (",
							宠物信息.等级,
							"/",
							current2.Num,
							")"
						});
						bool flag23 = Convert.ToInt32(宠物信息.等级) >= Convert.ToInt32(current2.Num);
						if (flag23)
						{
							num2++;
							text4 += " 已完成";
						}
						else
						{
							text4 += " 未完成";
						}
						text4 += "<br/>";
					}
					else
					{
						bool flag24 = current2.Type == "击杀";
						if (flag24)
						{
							bool flag25 = 任务信息2 == null;
							if (flag25)
							{
								text4 = string.Concat(new string[]
								{
									text4,
									"已击杀 ",
									this.取指定怪物类型(current2.ID).怪物名字,
									"&nbsp;(0/",
									current2.Num,
									")"
								});
								text4 += " 未完成";
							}
							else
							{
								bool flag26 = 任务信息2.任务目标[num].inNum == null || 任务信息2.任务目标[num].inNum.Length == 0;
								if (flag26)
								{
									text4 = string.Concat(new string[]
									{
										text4,
										"已击杀 ",
										this.取指定怪物类型(current2.ID).怪物名字,
										"&nbsp;(0/",
										current2.Num,
										")"
									});
								}
								else
								{
									text4 = string.Concat(new string[]
									{
										text4,
										"已击杀 ",
										this.取指定怪物类型(current2.ID).怪物名字,
										"&nbsp;(",
										任务信息2.任务目标[num].inNum,
										"/",
										current2.Num,
										")"
									});
								}
								bool flag27 = Convert.ToInt32(任务信息2.任务目标[num].inNum) >= Convert.ToInt32(current2.Num);
								if (flag27)
								{
									num2++;
									text4 += " 已完成";
								}
								else
								{
									text4 += " 未完成";
								}
							}
							text4 += "<br/>";
						}
						else
						{
							bool flag28 = current2.Type == "收集";
							if (flag28)
							{
								道具信息 道具信息 = this.取指定道具_按类型(current2.ID);
								bool flag29 = 道具信息 == null;
								if (flag29)
								{
									道具信息 = new 道具信息();
									道具信息.道具数量 = "0";
								}
								text4 = string.Concat(new string[]
								{
									text4,
									"已收集 ",
									this.取指定道具类型(current2.ID).道具名字,
									"&nbsp;(",
									道具信息.道具数量,
									"/",
									current2.Num,
									")"
								});
								bool flag30 = Convert.ToInt32(道具信息.道具数量) >= Convert.ToInt32(current2.Num);
								if (flag30)
								{
									num2++;
									text4 += " 已完成";
								}
								else
								{
									text4 += " 未完成";
								}
								text4 += "<br/>";
							}
							else
							{
								bool flag31 = current2.Type == "金币";
								if (flag31)
								{
									text4 = string.Concat(new string[]
									{
										text4,
										"已收集 金币&nbsp;(",
										用户信息.金币,
										"/",
										current2.Num,
										")"
									});
									bool flag32 = Convert.ToInt32(用户信息.金币) >= Convert.ToInt32(current2.Num);
									if (flag32)
									{
										num2++;
										text4 += " 已完成";
									}
									else
									{
										text4 += " 未完成";
									}
									text4 += "<br/>";
								}
								else
								{
									bool flag33 = current2.Type == "元宝";
									if (flag33)
									{
										text4 = string.Concat(new string[]
										{
											text4,
											"已收集 元宝&nbsp;(",
											用户信息.元宝,
											"/",
											current2.Num,
											")"
										});
										bool flag34 = Convert.ToInt32(用户信息.元宝) >= Convert.ToInt32(current2.Num);
										if (flag34)
										{
											num2++;
											text4 += " 已完成";
										}
										else
										{
											text4 += " 未完成";
										}
										text4 += "<br/>";
									}
									else
									{
										bool flag35 = current2.Type == "水晶";
										if (flag35)
										{
											text4 = string.Concat(new string[]
											{
												text4,
												"已收集 水晶&nbsp;(",
												用户信息.水晶,
												"/",
												current2.Num,
												")"
											});
											bool flag36 = Convert.ToInt32(用户信息.水晶) >= Convert.ToInt32(current2.Num);
											if (flag36)
											{
												num2++;
												text4 += " 已完成";
											}
											else
											{
												text4 += " 未完成";
											}
											text4 += "<br/>";
										}
										else
										{
											bool flag37 = current2.Type == "宠物";
											if (flag37)
											{
												text4 = string.Concat(new string[]
												{
													text4,
													"主宠需要为 ",
													this.取指定宠物类型(current2.ID).宠物名字,
													"&nbsp;达到",
													current2.Num,
													"CC "
												});
												宠物信息 宠物信息2 = this.读取指定宠物(用户信息.主宠物, null);
												宠物类型 宠物类型 = this.取指定宠物类型(宠物信息2.形象);
												bool flag38 = 宠物类型.宠物序号 != current2.ID;
												if (flag38)
												{
													text4 += " 未完成";
												}
												else
												{
													bool flag39 = Convert.ToDouble(宠物信息2.成长) >= Convert.ToDouble(current2.Num);
													if (flag39)
													{
														num2++;
														text4 += " 已完成";
													}
													else
													{
														text4 += " 未完成";
													}
												}
												text4 += "<br/>";
											}
											else
											{
												bool flag40 = current2.Type == "地狱";
												if (flag40)
												{
													text4 = text4 + "地狱之门需要达到 " + current2.Num + " 层";
													宠物信息 宠物信息3 = this.读取指定宠物(用户信息.主宠物, null);
													宠物类型 宠物类型2 = this.取指定宠物类型(宠物信息3.形象);
													bool flag41 = Convert.ToInt64(用户信息.地狱层数) / 10L + 1L <= Convert.ToInt64(current2.Num);
													if (flag41)
													{
														text4 += " 未完成";
													}
													else
													{
														num2++;
														text4 += " 已完成";
													}
													text4 += "<br/>";
												}
												else
												{
													bool flag42 = current2.Type == "装备";
													if (flag42)
													{
														List<装备信息> list = this.取未佩戴的装备();
														string text5 = "0";
														foreach (装备信息 current3 in list)
														{
															bool flag43 = current3.类ID == current2.ID;
															if (flag43)
															{
																text5 = "1";
																break;
															}
														}
														text4 = string.Concat(new string[]
														{
															text4,
															"已收集 ",
															this.取指定装备类型(current2.ID).名字,
															"&nbsp;(",
															text5,
															"/1) "
														});
														bool flag44 = text5.Equals("0");
														if (flag44)
														{
															text4 += "未完成";
														}
														else
														{
															num2++;
															text4 += "已完成";
														}
														text4 += "<br/>";
													}
													else
													{
														bool flag45 = current2.Type == "时间";
														if (flag45)
														{
															DateTime t = new 数据处理().取网络时间();
															DateTime t2 = DateTime.Parse(current2.Num);
															bool flag46 = DateTime.Compare(t, t2) <= 0;
															if (flag46)
															{
																num2++;
																text4 = text4 + "任务时限 " + current2.Num + " 已完成<br/>";
															}
															else
															{
																text4 = text4 + "任务时限 " + current2.Num + " 未完成(如果确定已完成请检查网络)<br/>";
															}
															text4 += "<br/>";
														}
														else
														{
															bool flag47 = current2.Type == "VIP";
															if (flag47)
															{
																text4 = string.Concat(new string[]
																{
																	text4,
																	"VIP等级已达到 (",
																	用户信息.vip,
																	"/",
																	current2.Num,
																	") 级"
																});
																bool flag48 = Convert.ToInt16(用户信息.vip) >= Convert.ToInt16(current2.Num);
																if (flag48)
																{
																	num2++;
																	text4 += " 已完成";
																}
																else
																{
																	text4 += " 未完成";
																}
																text4 += "<br/>";
															}
															else
															{
																bool flag49 = current2.Type == "积分";
																if (flag49)
																{
																	text4 = string.Concat(new string[]
																	{
																		text4,
																		"VIP积分已达到 (",
																		用户信息.积分,
																		"/",
																		current2.Num,
																		") 分"
																	});
																	bool flag50 = Convert.ToInt16(用户信息.积分) >= Convert.ToInt16(current2.Num);
																	if (flag50)
																	{
																		num2++;
																		text4 += " 已完成";
																	}
																	else
																	{
																		text4 += " 未完成";
																	}
																	text4 += "<br/>";
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					num++;
				}
				bool flag51 = 任务信息.指定宠物 != null && 任务信息.指定宠物 != "" && 任务信息.指定宠物 != "-1";
				if (flag51)
				{
					宠物类型 宠物类型3 = this.取指定宠物类型(任务信息.指定宠物);
					bool flag52 = false;
					text4 = text4 + "主宠物需要为 " + 宠物类型3.宠物名字;
					text3 = text3 + "主宠物需要为 " + 宠物类型3.宠物名字;
					任务面板.任务目标 = text3;
					宠物信息 宠物信息4 = this.读取指定宠物(用户信息.主宠物, null);
					bool flag53 = 宠物信息4.形象 == 宠物类型3.宠物序号;
					if (flag53)
					{
						flag52 = true;
						text4 += " 已完成";
					}
					else
					{
						text4 += " 未完成";
					}
					text4 += "<br/>";
					bool flag54 = num2 >= 任务目标.Count & flag52;
					if (flag54)
					{
						任务面板.是否完成 = "0";
					}
					else
					{
						任务面板.是否完成 = "1";
					}
				}
				else
				{
					bool flag55 = num2 >= 任务目标.Count;
					if (flag55)
					{
						任务面板.是否完成 = "0";
					}
					else
					{
						任务面板.是否完成 = "1";
					}
				}
				任务面板.任务进度 = text4;
				result = 任务面板;
			}
			return result;
		}

		public void 保存任务定义(List<任务信息> 任务列表)
		{
			string text = JsonConvert.SerializeObject(任务列表);
			text = RC4.EncryptRC4wq(text, 数据处理.存档密钥);
			this.保存文件(text, 数据处理.任务定义配置路径 + "\\_0.dat");
		}

		public void 删除任务定义(string 任务ID)
		{
			List<任务信息> list = this.取所有任务定义();
			List<任务信息> list2 = new List<任务信息>();
			foreach (任务信息 current in list)
			{
				bool flag = current.任务序号 != 任务ID;
				if (flag)
				{
					list2.Add(current);
				}
			}
			this.保存任务定义(list2);
		}

		public List<任务信息> 取玩家已领的任务()
		{
			bool flag = 数据处理._已领任务 != null && 数据处理.z;
			List<任务信息> result;
			if (flag)
			{
				result = 数据处理._已领任务;
			}
			else
			{
				List<任务信息> list = new List<任务信息>();
				string text = this.getStr();
				bool flag2 = text == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					string[] array = text.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
					text = array[6];
					bool flag3 = text != null && text != "";
					if (flag3)
					{
						text = RC4.DecryptRC4wq(text, 数据处理.存档密钥 + this.getKey(6));
						try
						{
							list = JsonConvert.DeserializeObject<List<任务信息>>(text);
							数据处理._已领任务 = list;
							result = list;
							return result;
						}
						catch
						{
							result = new List<任务信息>();
							return result;
						}
					}
					result = new List<任务信息>();
				}
			}
			return result;
		}

		public 任务信息 取指定已领任务(string 序号)
		{
			List<任务信息> list = this.取玩家已领的任务();
			任务信息 result;
			foreach (任务信息 current in list)
			{
				bool flag = current.任务序号 == 序号;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<suits> 取所有套装()
		{
			List<suits> list = new List<suits>();
			DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory.ToString() + "\\" + 数据处理.套装定义配置路径);
			FileInfo[] files = directoryInfo.GetFiles();
			List<文件验证> list2 = new List<文件验证>();
			FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileInfo fileInfo = array[i];
				bool flag = fileInfo.Extension.Equals(".dat");
				if (flag)
				{
					string value = RC4.DecryptRC4wq(this.读取文件(new 文件验证
					{
						特征 = 数据处理.GetFileHash(fileInfo.FullName),
						文件名 = 数据处理.套装定义配置路径 + fileInfo.Name
					}.文件名), 数据处理.存档密钥);
					suits item = JsonConvert.DeserializeObject<suits>(value);
					list.Add(item);
				}
			}
			return list;
		}

		public suits 取指定套装(string 套装ID)
		{
			suits suits = new suits();
			bool flag = !File.Exists(数据处理.套装定义配置路径 + 套装ID + ".dat");
			suits result;
			if (flag)
			{
				result = suits;
			}
			else
			{
				string text = RC4.DecryptRC4wq(this.读取文件(数据处理.套装定义配置路径 + 套装ID + ".dat"), 数据处理.存档密钥);
				bool flag2 = text != null;
				if (flag2)
				{
					suits = JsonConvert.DeserializeObject<suits>(text);
				}
				result = suits;
			}
			return result;
		}

		public List<技能配置> 取技能配置列表()
		{
			string text = RC4.DecryptRC4wq(this.读取文件(数据处理.技能定义配置路径), 数据处理.存档密钥);
			List<技能配置> list = new List<技能配置>();
			bool flag = text != null;
			if (flag)
			{
				string[] array = text.Split(new string[]
				{
					"\r\n"
				}, StringSplitOptions.None);
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					string[] array3 = text2.Split(new char[]
					{
						'，'
					});
					bool flag2 = array3.Length >= 5;
					if (flag2)
					{
						技能配置 技能配置 = new 技能配置();
						技能配置.技能ID = array3[0];
						技能配置.技能名字 = array3[1];
						技能配置.技能百分比 = array3[2];
						技能配置.技能附带效果 = array3[3];
						技能配置.附带效果增量 = array3[4];
						技能配置.耗蓝量 = array3[5];
						技能配置.BUFF = ((技能配置.技能附带效果 != "null") ? "true" : "false");
						list.Add(技能配置);
					}
					else
					{
						Console.Write("配置出错,内容为:" + text2);
					}
				}
			}
			数据处理._技能列表 = list;
			return list;
		}

		public 技能配置 取指定技能配置(string 技能ID)
		{
			bool flag = 数据处理._技能列表 == null;
			if (flag)
			{
				this.取技能配置列表();
			}
			bool flag2 = 数据处理._技能列表.Count == 0;
			if (flag2)
			{
				this.取技能配置列表();
			}
			技能配置 result;
			foreach (技能配置 current in 数据处理._技能列表)
			{
				bool flag3 = current.技能ID.Equals(技能ID);
				if (flag3)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public bool 学习默认技能(string 宠物ID)
		{
			宠物信息 宠物信息 = this.读取指定宠物(宠物ID, null);
			宠物类型 宠物类型 = this.取指定宠物类型(宠物信息.形象);
			bool flag = 宠物信息.技能列表 == "0";
			if (flag)
			{
				宠物信息.技能列表 = "";
			}
			foreach (string current in 宠物类型.默认技能)
			{
				bool flag2 = true;
				bool flag3 = current.Length == 0;
				if (!flag3)
				{
					foreach (技能信息 current2 in 宠物信息.信息)
					{
						bool flag4 = current2.技能序号.Equals(current);
						if (flag4)
						{
							flag2 = false;
							break;
						}
					}
					bool flag5 = flag2;
					if (flag5)
					{
						宠物信息 expr_C4 = 宠物信息;
						expr_C4.技能列表 = expr_C4.技能列表 + ",|" + current + "|0";
					}
				}
			}
			this.更新指定宠物存档(宠物信息.宠物序号, 宠物信息);
			return true;
		}

		public bool 学习技能(string 宠物ID, string 技能ID)
		{
			宠物信息 宠物信息 = this.读取指定宠物(宠物ID, null);
			List<技能信息> 信息 = 宠物信息.信息;
			bool result;
			foreach (技能信息 current in 信息)
			{
				bool flag = current.信息 != null && current.信息.技能ID == 技能ID;
				if (flag)
				{
					result = false;
					return result;
				}
			}
			bool flag2 = this.取指定技能配置(技能ID) == null;
			if (flag2)
			{
				result = false;
			}
			else
			{
				宠物信息 expr_7E = 宠物信息;
				expr_7E.技能列表 = expr_7E.技能列表 + ",|" + 技能ID + "|0";
				this.更新指定宠物存档(宠物信息.宠物序号, 宠物信息);
				result = true;
			}
			return result;
		}

		public int 升级技能(string 宠物ID, string 技能ID)
		{
			宠物信息 宠物信息 = this.读取指定宠物(宠物ID, null);
			string 技能列表 = 宠物信息.技能列表;
			string[] array = 技能列表.Split(new char[]
			{
				','
			});
			string text = "";
			int num = -1;
			string[] array2 = array;
			int result;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				string[] array3 = text2.Split(new char[]
				{
					'|'
				});
				bool flag = array3.Length >= 2;
				if (flag)
				{
					bool flag2 = array3[1] == 技能ID;
					if (flag2)
					{
						array3[2] = (Convert.ToInt32(array3[2]) + 1).ToString();
						num = Convert.ToInt32(array3[2]);
						bool flag3 = num > 18;
						if (flag3)
						{
							result = -2;
							return result;
						}
					}
					text = string.Concat(new string[]
					{
						text,
						",|",
						array3[1],
						"|",
						array3[2]
					});
				}
			}
			bool flag4 = num != -1;
			if (flag4)
			{
				宠物信息.技能列表 = text;
				this.更新指定宠物存档(宠物ID, 宠物信息);
			}
			result = num;
			return result;
		}

		public int 技能升级(string 宠物ID, string 技能ID, string 技能类型)
		{
			bool flag = 技能类型.Equals("BUFF");
			道具信息 道具信息;
			if (flag)
			{
				道具信息 = this.取指定道具_按类型("2017021601");
			}
			else
			{
				道具信息 = this.取指定道具_按类型("2017021602");
			}
			bool flag2 = 道具信息 == null;
			int result;
			if (flag2)
			{
				result = -1;
			}
			else
			{
				int num = this.升级技能(宠物ID, 技能ID);
				bool flag3 = num < 0;
				if (flag3)
				{
					result = num;
				}
				else
				{
					bool flag4 = Convert.ToInt32(道具信息.道具数量) <= 1;
					if (flag4)
					{
						new 数据处理().删除道具(道具信息);
					}
					else
					{
						道具信息.道具数量 = (Convert.ToInt32(道具信息.道具数量) - 1).ToString();
						new 数据处理().修改道具(道具信息);
					}
					result = num;
				}
			}
			return result;
		}
	}
}
