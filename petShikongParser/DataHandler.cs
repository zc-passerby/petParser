using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace petShikongParser
{
    public class DataHandler
    {
        public static string securityKey = "qiqiwan.2016.2017.2018.2020.2021.2022";

        public static string dataHash = "1CEF18F79C700A0C8128B8599D0B9506";

        public static string pathBase = "\\PageMain\\main.dat";

        public static string mainDataPath = "";

        public ConvertJson convertJson = new ConvertJson();

        public static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public static Random 随机数产生器 = new Random();

        public static double 存档版本号 = 0.6;

        public static string 存档Hash;

        public void setPathBase(string newPath)
        {
            mainDataPath = newPath + pathBase;
        }

        public void setVersion(double version)
        {
            存档版本号 = version;
        }

        public string getVersion()
        {
            if (!File.Exists(mainDataPath))
            {
                return null;
            }
            string text = "";
            using (StreamReader stramReader = new StreamReader(mainDataPath))
            {
                string str;
                while ((str = stramReader.ReadLine()) != null)
                {
                    text += str;
                }
            }
            if (text == null)
            {
                return null;
            }
            string text2 = text;
            string str2 = "";
//             Console.WriteLine("text:" + text);
            if (text2.IndexOf("9527OA") != -1)
            {
                string[] array = text2.Split(new string[]
                {
                    "9527OA"
                }, StringSplitOptions.None);
                text2 = array[0];
                str2 = array[1];
//                 Console.WriteLine("text2:" + text2 + "\nstr2:" + str2);
            }
            string[] array2 = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
//             foreach (string s in array2)
//             {
//                 Console.WriteLine(s);
//             }
            if (array2.Length > 3)
            {
                str2 = array2[3].Split(new string[]
                {
                    "O19A87"
                }, StringSplitOptions.None)[1];
            }
            return RC4.DecryptRC4wq(array2[3], securityKey + str2);
        }

        public string getHash()
        {
            string text = readFile(mainDataPath);
            if (text == null)
            {
                return "";
            }
            if (text.IndexOf("9527OA") != -1)
            {
                string[] array = text.Split(new string[]
                {
                    "9527OA"
                }, StringSplitOptions.None);
//                 Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "array[0]:" + array[0] + "array[1]:" + array[1]);
                return array[1];
            }
            return "";
        }

        public string getStringHash(string str)
        {
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        public string getFileHash(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("getFileHash===>" + filePath + "is not exists!!!");
                return "-1";
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", "");
            }
        }

        public string readFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("readFile===>" + fileName + "is not exists !!!");
                return null;
            }

            string text = "";
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string str;
                while ((str = streamReader.ReadLine()) != null)
                {
                    text += str;
                }
            }
            return text;
        }

        public string getStr()
        {
//             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "just test getStr----");
            string fileHash = getFileHash(mainDataPath);
            string text = readFile(mainDataPath);
//             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "fileHash==>" + fileHash + ",text==>" + text);
            if (text == null)
            {
                return null;
            }

            if (text.IndexOf("9527OA") != -1)
            {
                string[] array = text.Split(new string[]
                {
                    "9527OA"
                }, StringSplitOptions.None);
//                 Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "array[0]=>" + array[0] + ",array[1]=>" + array[1]);
//                 Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "getHash=>" + getHash());
//                 if (!getHash().Equals(RC4.EncryptRC4wq(getStringHash(array[0]), securityKey + "MaskSB")))
//                 {
//                     Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), "check hash failed!!!");
//                     Environment.Exit(0);
//                     return null;
//                 }
                return array[0];
            }
            return text;
        }

        public string getKey(int position)
		{
			string text = this.readFile(mainDataPath);
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
				bool flag3 = array2.Length > position;
				if (flag3)
				{
					string[] array3 = array2[position].Split(new string[]
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

        public 用户信息 getUserInfo()
        {
            用户信息 userInfomation = new 用户信息();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getUserInfo==>text is null~~~");
                return userInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[0], securityKey + getKey(0));
//             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), text1);
            if (text1 != null && text != "")
            {
                Console.Write("用户信息：\n");
                Console.WriteLine(text1);
                userInfomation = JsonConvert.DeserializeObject<用户信息>(text1);
                if (userInfomation.金币.IndexOf("-") != -1)
                {
                    userInfomation.金币 = 2147483647.ToString();
                }
            }
            return userInfomation;
        }

        public JObject getUserInfo1()
        {
            JObject userInfomation = new JObject();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getUserInfo==>text is null~~~");
                return userInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[0], securityKey + getKey(0));
            //             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), text1);
            if (text1 != null && text != "")
            {
                Console.Write("用户信息：");
                Console.WriteLine(text1);
                userInfomation = JsonConvert.DeserializeObject<JObject>(text1);
                if (userInfomation["金币"].ToString().IndexOf("-") != -1)
                {
                    userInfomation["金币"] = 2147483647.ToString();
                }
            }
            return userInfomation;
        }

        public bool saveUserInfo(用户信息 userInfo)
        {
            bool result;
            try
            {
                userInfo.名字 = userInfo.名字.Replace("<", "");
                userInfo.名字 = userInfo.名字.Replace(">", "");
                userInfo.名字 = userInfo.名字.Replace("|", "");
                userInfo.名字 = userInfo.名字.Replace(",", "");
                userInfo.名字 = userInfo.名字.Replace(".", "");
                userInfo.名字 = userInfo.名字.Replace("?", "");
                bool flag = userInfo.名字.Length > 20;
                if (flag)
                {
                    userInfo.名字 = userInfo.名字.Substring(0, 20);
                }
                string text = convertJson.getUserJSON(userInfo);//convertJson.EntityToJSON(userInfo, true, "Null");
                string text2 = text;
                string str = this.getStr();
                string[] array = new string[]
				{
					"",
					"",
					"",
					"",
					""
				};
                bool flag2 = str != null;
                if (flag2)
                {
                    array = str.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
                }
                bool flag3 = text == null || text.Length == 0;
                if (flag3)
                {
                    bool flag4 = text2.Length != 0;
                    if (flag4)
                    {
                        result = false;
                        return result;
                    }
                }
                array[0] = text;
                text = this.拼接存档(array, true, null);
                Console.Write("拼接完存档：");
                Console.WriteLine(text);
                this.保存文件(text, mainDataPath);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool saveUserInfo1(JObject userInfo)
        {
            bool result;
            try
            {
                userInfo["名字"] = userInfo["名字"].ToString().Replace("<", "");
                userInfo["名字"] = userInfo["名字"].ToString().Replace(">", "");
                userInfo["名字"] = userInfo["名字"].ToString().Replace("|", "");
                userInfo["名字"] = userInfo["名字"].ToString().Replace(",", "");
                userInfo["名字"] = userInfo["名字"].ToString().Replace(".", "");
                userInfo["名字"] = userInfo["名字"].ToString().Replace("?", "");
                bool flag = userInfo["名字"].ToString().Length > 20;
                if (flag)
                {
                    userInfo["名字"] = userInfo["名字"].ToString().Substring(0, 20);
                }
                string text = userInfo.ToString();// JsonConvert.SerializeObject(userInfo);//convertJson.EntityToJSON(userInfo, true, "Null");
                string text2 = text;
                string str = this.getStr();
                string[] array = new string[]
				{
					"",
					"",
					"",
					"",
					""
				};
                bool flag2 = str != null;
                if (flag2)
                {
                    array = str.Split(new string[]
					{
						"O4F89"
					}, StringSplitOptions.None);
                }
                bool flag3 = text == null || text.Length == 0;
                if (flag3)
                {
                    bool flag4 = text2.Length != 0;
                    if (flag4)
                    {
                        result = false;
                        return result;
                    }
                }
                text = text.Replace("\r\n", "").Replace(" ", "").Replace("\t", "");
                array[0] = text;
                Console.Write("用户信息：");
                Console.WriteLine(text);
                text = this.拼接存档(array, true, null);
                Console.Write("拼接完存档：");
                Console.WriteLine(text);
                this.保存文件(text, mainDataPath);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public void savePropInfo(JArray propInfo)
        {
            string text = propInfo.ToString();
            text = this.压缩道具JSON(text).Replace("\r\n", "").Replace(" ", "").Replace("\t", "");
            //Console.Write("保存的道具：");
            //Console.WriteLine(text);
            string str = this.getStr();
            string[] array = str.Split(new string[]
			{
				"O4F89"
			}, StringSplitOptions.None);
            array[1] = text;
            text = this.拼接存档(array, true, null);
            Console.Write("拼接完存档：");
            Console.WriteLine(text);
            this.保存文件(text, mainDataPath);
        }

        public void savePetInfo(JArray petInfo)
        {
            string text = petInfo.ToString();
            //text = this.压缩道具JSON(text).Replace("\r\n", "").Replace(" ", "").Replace("\t", "");
            Console.Write("保存的宠物：");
            Console.WriteLine(text);
            string str = this.getStr();
            string[] array = str.Split(new string[]
			{
				"O4F89"
			}, StringSplitOptions.None);
            array[2] = text;
            text = this.拼接存档(array, true, null);
            Console.Write("拼接完存档：");
            Console.WriteLine(text);
            this.保存文件(text, mainDataPath);
        }

        public void saveEquipInfo(JArray equipInfo)
        {
            string text = equipInfo.ToString();
            text = this.压缩道具JSON(text).Replace("\r\n", "").Replace(" ", "").Replace("\t", "");
            Console.Write("保存的装备：");
            Console.WriteLine(text);
            string str = this.getStr();
            string[] array = str.Split(new string[]
			{
				"O4F89"
			}, StringSplitOptions.None);
            array[4] = text;
            text = this.拼接存档(array, true, null);
            Console.Write("拼接完存档：");
            Console.WriteLine(text);
            this.保存文件(text, mainDataPath);
        }

        public void saveRunnigTaskInfo(JArray taskInfo)
        {
            string text = taskInfo.ToString();
            text = text.Replace("\r\n", "").Replace(" ", "").Replace("\t", "");
            Console.Write("保存的宠物：");
            Console.WriteLine(text);
            string str = this.getStr();
            string[] array = str.Split(new string[]
			{
				"O4F89"
			}, StringSplitOptions.None);
            while (array.Length < 7)
            {
                array = (str + "O4F89").Split(new string[]
				{
					"O4F89"
				}, StringSplitOptions.None);
            }
            array[6] = text;
            text = this.拼接存档(array, true, null);
            Console.Write("拼接完存档：");
            Console.WriteLine(text);
            this.保存文件(text, mainDataPath);
        }

        public string 拼接存档(string[] 存档组, bool 密钥, string 存档版本)
        {
            string text = "";
            string text2 = "";
            string text3 = "";
            string text4 = "";
            if (密钥)
            {
                text4 = 随机数产生器.Next(10000000, 99000000).ToString();
                text4 = RC4.EncryptRC4wq(text4, securityKey);
            }
            for (int i = 0; i < 存档组.Length; i++)
            {
                bool flag = 存档组[i].IndexOf("{") != -1 || 存档组[i].IndexOf("[") != -1;
                if (flag)
                {
                    存档组[i] = RC4.EncryptRC4wq(存档组[i], securityKey + text4) + "O19A87" + text4;
                }
            }
            bool flag2 = 存档版本 == null;
            if (flag2)
            {
                存档版本 = RC4.EncryptRC4wq(存档版本号.ToString(), securityKey + text4) + "O19A87" + text4;
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
            string stringHash = this.getStringHash(text5);
            if (存档版本号 >= 0.8)
            {
                stringHash = stringHash.ToLower();
            }
            return text5 + "9527OA" + RC4.EncryptRC4wq(stringHash, securityKey + "MaskSB");
        }

        public void 保存文件(string text, string name)
        {
            bool flag = name.IndexOf("Main.dat") != -1;
            if (flag)
            {
                bool flag2 = !File.Exists(mainDataPath);
                if (flag2)
                {
                    File.WriteAllText(name, text, Encoding.UTF8);
                }
                //File.Copy(name, "PageMain\\backups\\_Main.back", true);
                //File.WriteAllText(name + "_bank", text, Encoding.UTF8);
                //File.Delete(name);
                //File.Move(name + "_bank", name);
                //存档Hash = this.GetFileHash(name);
            }
            else
            {
                File.WriteAllText(name, text, Encoding.UTF8);
            }
        }

        public string getPetDefineData()
        {
            //string text = this.readFile(pathBase + "PageMain\\petInfoTable.dat");
            string text = this.readFile("D:\\Data\\766887280\\FileRecv\\时空单机V6.70\\PageMain\\petInfoTable.pph");
            text = RC4.DecryptRC4wq(text, securityKey);
            string[] array = text.Split(new string[]
			{
				"\r\n"
			}, StringSplitOptions.None);
            string[] array2 = array;
            Console.WriteLine("insert int petDefine (petId,petName,petDept,petClass,petSkills) values ");
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
//                     for (int j = 0; j < array3.Length; j++)
//                     {
//                         Console.Write(array3[j] + ",");
//                     }
                    Console.Write("\n");
                    if (array3.Length == 3)
                    {
                        Console.Write("(" + array3[0] + ",'" + array3[1] + "','" + array3[2] + "','未知',''),");
                    }
                    if (array3.Length == 4)
                    {
                        Console.Write("(" + array3[0] + ",'" + array3[1] + "','" + array3[2] + "','" + array3[3] + "',''),");
                    }
                    if (array3.Length == 5)
                    {
                        Console.Write("(" + array3[0] + ",'" + array3[1] + "','" + array3[2] + "','" + array3[3] + "','" + array3[4] + "'),");
                    }
                }
            }
            return text;
        }

        public string getPropDefineData()
        {
            //string text = this.readFile(pathBase + "PageMain\\propTable.dat");
            string text = this.readFile("D:\\Data\\450343225\\FileRecv\\口袋单机\\口袋单机V5.2.6\\PageMain\\propTable.dat");
            text = RC4.DecryptRC4wq(text, securityKey);
            Console.WriteLine(text);
            return text;
        }

        public string getEvolDefineData()
        {
            //string text = this.readFile(pathBase + "PageMain\\petInfoTable_a.dat");
            string text = this.readFile("D:\\Data\\766887280\\FileRecv\\时空单机V6.70\\PageMain\\petInfoTable_a.qingshan");
            text = RC4.DecryptRC4wq(text, securityKey);
            Console.WriteLine(text);
            return text;
        }

        public string getCompDefineData()
        {
            string text = this.readFile(pathBase + "PageMain\\petInfoTable_b.dat");
            text = RC4.DecryptRC4wq(text, securityKey);
            Console.WriteLine(text);
            return text;
        }

        public string getDefinedData(string filePath, string fileName)
        {
            //string filePathBase = pathBase + filePath;
            string filePathBase = filePath;
            string text = this.readFile(filePathBase + fileName);
            text = RC4.DecryptRC4wq(text, securityKey);
            Console.WriteLine(text);
            return text;
        }

        /*
        public void getPropDetail(string filePath)
        {
            DirectoryInfo theFolder = new DirectoryInfo(filePath);
            string insertStr = "insert into propDetail (propId,propScript,propIntroduce,fileName) values ('-1','-1','-1','-1')";
            foreach (FileInfo nextFile in theFolder.GetFiles())
            {
                string fileName = nextFile.FullName;
                string text = this.readFile(fileName);
                text = RC4.DecryptRC4wq(text, securityKey);
                //Console.WriteLine(text);
                JObject propData = JsonConvert.DeserializeObject<JObject>(text);
                insertStr = insertStr + ",('" + propData["道具序号"] + "','" + propData["道具脚本"] + "','" + propData["道具说明"] + "','" + nextFile.Name + "')";
            }
            insertStr += ";";
            Console.WriteLine(insertStr);
            string connStr = "server=47.89.246.80;User Id=root;password=Passerby;Database=pocketPet";
            MySqlConnection mysqlConn = new MySqlConnection(connStr);
            MySqlCommand mysqlCmd = new MySqlCommand(insertStr, mysqlConn);
            mysqlConn.Open();
            if (mysqlCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("数据插入成功！");
            }
            mysqlConn.Close();
        }

        public void getEquipDefine(string filePath)
        {
            DirectoryInfo theFolder = new DirectoryInfo(filePath);
            string insertStr = "insert into equipDefine (equipId,equipName,equipGJ,equipMZ,equipFY,equipSD,equipSB,equipSM,equipMF,equipJS,equipDX,equipXX,equipXM,equipType,equipIntroduce,equipIcon,equipMajorProp,TZID,suitId,fileName) values ('-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1','-1')";
            foreach (FileInfo nextFile in theFolder.GetFiles())
            {
                string fileName = nextFile.FullName;
                string text = this.readFile(fileName);
                text = RC4.DecryptRC4wq(text, securityKey);
                //Console.WriteLine(text);
                JObject propData = JsonConvert.DeserializeObject<JObject>(text);
                insertStr = insertStr + ",(\"" + propData["ID"] + "\",\"" + propData["名字"] + "\",\"" + propData["攻击"] + "\",\"" + propData["命中"] + "\",\"" + propData["防御"] + "\",\"" + propData["速度"] + "\",\"" + propData["闪避"] + "\",\"" + propData["生命"] + "\",\"" + propData["魔法"] + "\",\"" + propData["加深"] + "\",\"" + propData["抵消"] + "\",\"" + propData["吸血"] + "\",\"" + propData["吸魔"] + "\",\"" + propData["类型"] + "\",\"" + propData["说明"] + "\",\"" + propData["ICO"] + "\",\"" + propData["主属性"] + "\",\"" + propData["套装ID"] + "\",\"" + propData["suitID"] + "\",\"" + nextFile.Name + "\")";
            }
            insertStr += ";";
            Console.WriteLine(insertStr);
            string connStr = "server=47.89.246.80;User Id=root;password=Passerby;Database=pocketPet";
            MySqlConnection mysqlConn = new MySqlConnection(connStr);
            MySqlCommand mysqlCmd = new MySqlCommand(insertStr, mysqlConn);
            mysqlConn.Open();
            if (mysqlCmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("数据插入成功！");
            }
            mysqlConn.Close();
        }
        */
        public string testDecrupt(string text)
        {
            return RC4.DecryptRC4wq(text, securityKey);
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

        public JArray getPropInfo()
        {
            JArray propInfomation = new JArray();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getPropInfo==>text is null~~~");
                return propInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[1], securityKey + getKey(1));
            //             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), text1);
            if (text1 != null && text != "")
            {
                text1 = this.解压道具JSON(text1);
                Console.Write("道具信息：\n");
                Console.WriteLine(text1);
                propInfomation = JsonConvert.DeserializeObject<JArray>(text1);
            }
            return propInfomation;
        }

        public JArray getEquipInfo()
        {
            JArray equipInfomation = new JArray();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getEquipInfo==>text is null~~~");
                return equipInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[4], securityKey + getKey(4));
            //             Console.WriteLine(consoleFormat, new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber(), text1);
            if (text1 != null && text != "")
            {
                text1 = this.解压道具JSON(text1);
                Console.Write("装备信息：\n");
                Console.WriteLine(text1);
                equipInfomation = JsonConvert.DeserializeObject<JArray>(text1);
            }
            return equipInfomation;
        }

        public JArray getPetInfo()
        {
            JArray petInfomation = new JArray();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getPetInfo==>text is null~~~");
                return petInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[2], securityKey + getKey(2));
            if (text1 != null && text != "")
            {
                text1 = this.解压宠物JSON(text1);
                text1 = text1.Replace("\"\"", "\"0\"");
                Console.WriteLine("宠物信息：");
                Console.WriteLine(text1);
                petInfomation = JsonConvert.DeserializeObject<JArray>(text1);
            }
            return petInfomation;
        }

        public JArray getRunningTaskInfo()
        {
            JArray taskInfomation = new JArray();
            string text = getStr();
            if (text == null)
            {
                Console.WriteLine("getRunningInfo==>text is null~~~");
                return taskInfomation;
            }

            string[] array = text.Split(new string[]
            {
                "O4F89"
            }, StringSplitOptions.None);
            string text1 = RC4.DecryptRC4wq(array[6], securityKey + getKey(6));
            //text1 = this.解压宠物JSON(text1);
            //text1 = text1.Replace("\"\"", "\"0\"");
            if (text1 != null && text != "")
            {
                Console.WriteLine("任务信息：");
                Console.WriteLine(text1);
                taskInfomation = JsonConvert.DeserializeObject<JArray>(text1);
            }
            return taskInfomation;
        }
        /*
        public List<propInfo> getPropDefineFromDataBase()
        {
            string connStr = "server=47.89.246.80;User Id=root;password=Passerby;Database=pocketPet";
            string selectStr = "SELECT propId,propName,propPrice,propIcon FROM propDefine;";
            MySqlConnection mysqlConn = new MySqlConnection(connStr);
            MySqlCommand mysqlCmd = new MySqlCommand(selectStr, mysqlConn);
            mysqlConn.Open();
            MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();
            List<propInfo> propInfoList = new List<propInfo>();
            while (mysqlReader.Read())
            {
                propInfo prop = new propInfo();
                prop.propId = mysqlReader.GetInt64("propId").ToString();
                prop.propName = mysqlReader.GetString("propName");
                prop.propIcon = mysqlReader.GetInt64("propIcon").ToString();
                prop.propPrice = mysqlReader.GetString("propPrice");
                //Console.WriteLine(prop);
                propInfoList.Add(prop);
            }
            return propInfoList;
        }

        public List<petInfo> getPetDefineFromDataBase()
        {
            string connStr = "server=47.89.246.80;User Id=root;password=Passerby;Database=pocketPet";
            string selectStr = "SELECT petId,petName,petDept,petClass,petSkills FROM petDefine;";
            MySqlConnection mysqlConn = new MySqlConnection(connStr);
            MySqlCommand mysqlCmd = new MySqlCommand(selectStr, mysqlConn);
            mysqlConn.Open();
            MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();
            List<petInfo> petInfoList = new List<petInfo>();
            while (mysqlReader.Read())
            {
                petInfo pet = new petInfo();
                pet.petId = mysqlReader.GetInt64("petId").ToString();
                pet.petName = mysqlReader.GetString("petName");
                pet.petDept = mysqlReader.GetString("petDept");
                pet.petClass = mysqlReader.GetString("petClass");
                pet.petSkills = mysqlReader.GetString("petSkills");
                //Console.WriteLine(prop);
                petInfoList.Add(pet);
            }
            return petInfoList;
        }

        public List<equipInfo> getEquipDefineFromDataBase()
        {
            string connStr = "server=47.89.246.80;User Id=root;password=Passerby;Database=pocketPet";
            string selectStr = "SELECT equipId,equipName,equipType,equipIcon FROM equipDefine;";
            MySqlConnection mysqlConn = new MySqlConnection(connStr);
            MySqlCommand mysqlCmd = new MySqlCommand(selectStr, mysqlConn);
            mysqlConn.Open();
            MySqlDataReader mysqlReader = mysqlCmd.ExecuteReader();
            List<equipInfo> equipInfoList = new List<equipInfo>();
            while (mysqlReader.Read())
            {
                equipInfo equip = new equipInfo();
                equip.equipId = mysqlReader.GetInt64("equipId").ToString();
                equip.equipName = mysqlReader.GetString("equipName");
                equip.equipType = mysqlReader.GetString("equipType");
                equip.equipIcon = mysqlReader.GetInt64("equipIcon").ToString();
                //Console.WriteLine(prop);
                equipInfoList.Add(equip);
            }
            return equipInfoList;
        }
        */
    }
}
