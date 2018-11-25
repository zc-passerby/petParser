using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petShikongParser
{
    public class dataProcessor
    {
        private static readonly string securityKey = "qiqiwan.2016.2017.2018.2020.2021.2022";   // 密钥

        private static readonly string dataHash = "1CEF18F79C700A0C8128B8599D0B9506";   // 加密哈希值

        private static readonly string archivedFile = @"\PageMain\Main.dat";    // 时空单机存档文件

        private static readonly string petStateFile = @"\PageMain\PetState.wad"; // 境界配置文件

        private static readonly string skillIntroFile = @"\PageMain\SkillsIntroduction.ini"; // 技能获取途径介绍文件

        private static readonly string petDefineFile_r = @"\PageMain\pet_01.canku";  // 宠物定义文件？

        private static readonly string petEvoleTreeFile = @"\PageMain\petInfoTable_a.qingshan";  // 宠物进化路径配置文件

        private static readonly string g2PetIdFile_r = @"\PageMain\synthetsis.ini";  // 聖宠id？

        private static readonly string skillInfoFile = @"\PageMain\propTable\e\s\2.petshikong";  // 技能说明文件

        private static readonly string taskDefineFile = @"\PageMain\task\_0.task";    // 任务定义文件

        private static readonly string propDefineFile = @"\PageMain\Content\resources\Thumbs.db"; // 道具定义文件

        private static readonly string propDetailPath = @"\PageMain\propTable";  // 道具详细介绍路径（.data文件）

        private static readonly string equipDetailPath = @"\PageMain\propTable\e";   // 装备详细介绍路径（.dat文件）

        private static readonly string equipSuitInfoPath = @"\PageMain\propTable\e\s\";  // 装备套装介绍路径（.dat文件）

        private static readonly string taskDetailPath = @"\PageMain\task";   // 任务详细介绍路径（.dat文件）

        private static string dbConnectionString = @"Data Source=../../../Library/petShikongData.db;Version=3;password=";

        private static string petShikongPath = "";

        private static string archivedFileFull = "";

        private ConvertJson convertJson = new ConvertJson();

        private static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        private static Random randomCreator = new Random();

        private static double archivedFileVersion = 0.6;

        private static string archivedFileHash;

        #region 私有方法
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string readFile(string fileName)
        {
            if (!File.Exists(fileName))
                return null;
            string text = "";
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string str = "";
                while ((str = streamReader.ReadLine()) != null)
                {
                    text += str;
                }
            }
            return text;
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 设置时空单机的路径
        /// </summary>
        /// <param name="newPath"></param>
        public void setPetShikongPath(string newPath)
        {
            petShikongPath = newPath;
            archivedFileFull = petShikongPath + archivedFile;
        }

        /// <summary>
        /// 设置存档的版本号
        /// </summary>
        /// <param name="version"></param>
        public void setVersion(double version)
        {
            archivedFileVersion = version;
        }

        /// <summary>
        /// 获取存档的版本号
        /// </summary>
        /// <returns></returns>
        public string getVersion()
        {
            string text = readFile(archivedFileFull);
            if (text == null || text == "")
                return null;
            string text2 = text;
            string str2 = "";
            if (text2.IndexOf("9527OA") != -1)
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
            if (array2.Length > 3)
            {
                str2 = array2[3].Split(new string[]
                {
                    "O19A87"
                }, StringSplitOptions.None)[1];
            }
            return RC4.DecryptRC4wq(array2[3], securityKey + str2);
        }

        /// <summary>
        /// 解析文件，将文件中内容解密后返回
        /// </summary>
        /// <param name="fileName">文件名全路径</param>
        /// <returns></returns>
        public string parseTargetFile(string fileName)
        {
            string text = readFile(fileName);
            return RC4.DecryptRC4wq(text, securityKey);
        }

        /// <summary>
        /// 解析道具定义的数据
        /// </summary>
        /// <returns></returns>
        public JArray parsePropDefineData()
        {
            string propDefineFilePath = petShikongPath + propDefineFile;
            string text = parseTargetFile(propDefineFilePath);
            JArray propDefineData = JsonConvert.DeserializeObject<JArray>(text);
            string propDataStr = "";
            foreach(JObject singleProp in propDefineData)
            {
                string propInfo = string.Format("{0},{1},{2},{3}\r\n",
                    singleProp["道具序号"], singleProp["道具名字"],
                    singleProp["道具图标"], singleProp["道具价格"]);
                propDataStr += propInfo;
            }
            showDataFormParam param = new showDataFormParam();
            param.formText = "道具定义数据";
            param.tbShowDataText = propDataStr;
            fmShowData showData = new fmShowData(param);
            showData.ShowDialog();
            return propDefineData;
        }

        public JArray parsePropDetailData()
        {
            string filePath = petShikongPath + propDetailPath;
            DirectoryInfo theFolder = new DirectoryInfo(filePath);
            string propDetailStr = "";
            JArray result = new JArray();
            foreach (FileInfo singleFile in theFolder.GetFiles())
            {
                string FileName = singleFile.FullName;
                string text = parseTargetFile(FileName);
                JObject targetInfo = JsonConvert.DeserializeObject<JObject>(text);
                string propInfo = string.Format("{0},{1},{2}\r\n",
                    targetInfo["道具序号"], targetInfo["道具脚本"], targetInfo["道具说明"]);
                propDetailStr += propInfo;
                result.Add(targetInfo);
            }
            showDataFormParam param = new showDataFormParam();
            param.formText = "道具说明数据";
            param.tbShowDataText = propDetailStr;
            fmShowData showData = new fmShowData(param);
            showData.ShowDialog();
            return result;
        }
        #endregion

        #region 数据库操作
        /// <summary>
        /// 根据数据库表类型获取表名称
        /// </summary>
        /// <param name="enTable"></param>
        /// <returns></returns>
        private string getTableNameByType(dbTableOptions enTable)
        {
            string tableName = "";
            switch (enTable)
            {
                case dbTableOptions.propDefineTable:
                    tableName = "propDefine";
                    break;
                case dbTableOptions.propDetailTable:
                    tableName = "propDetail";
                    break;
                case dbTableOptions.propDataView:
                    tableName = "v_propData";
                    break;
                default:
                    break;
            }
            return tableName;
        }

        /// <summary>
        /// 获取表中数据的条数
        /// </summary>
        /// <param name="enTable"></param>
        /// <returns></returns>
        public int getTableCountFromDb(dbTableOptions enTable)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return -1;
            string selectSql = string.Format("select count(0) from {0};", tableName);
            object[] ob = { };
            object result = SQLiteHelper.ExecuteScalar(dbConnectionString, selectSql, ob);
            return int.Parse(result.ToString());
        }

        /// <summary>
        /// 插入道具定义数据到数据库中
        /// </summary>
        /// <param name="tableData"></param>
        /// <param name="enTable"></param>
        /// <returns></returns>
        public int insertPropDefineDataToDb(JArray tableData, dbTableOptions enTable)
        {
            int insertCount = 0;
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return -1;

            string insertSql = string.Format("insert into {0} values(@propSeq, @propName, @propIcon, @propPrice);", tableName);
            List<object[]> paramList = new List<object[]>();
            foreach(JObject propData in tableData)
            {
                object[] objects = new object[4];
                objects[0] = int.Parse(propData["道具序号"].ToString());
                objects[1] = propData["道具名字"].ToString();
                objects[2] = int.Parse(propData["道具图标"].ToString());
                objects[3] = int.Parse(propData["道具价格"].ToString());
                paramList.Add(objects);
            }
            insertCount = SQLiteHelper.ExecuteNonQueryWithTransaction(dbConnectionString, insertSql, paramList);
            return insertCount;
        }

        /// <summary>
        /// 插入道具说明数据到数据库中
        /// </summary>
        /// <param name="tableData"></param>
        /// <param name="enTable"></param>
        /// <returns></returns>
        public int insertPropDetailDataToDB(JArray tableData, dbTableOptions enTable)
        {
            int insertCount = 0;
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return -1;

            string insertSql = string.Format("insert into {0} values(@propSeq, @propScript, @propIntro);", tableName);
            List<object[]> paramList = new List<object[]>();
            foreach (JObject propData in tableData)
            {
                object[] objects = new object[3];
                objects[0] = propData["道具序号"].ToString();
                objects[1] = propData["道具脚本"].ToString();
                objects[2] = propData["道具说明"].ToString();
                paramList.Add(objects);
            }
            insertCount = SQLiteHelper.ExecuteNonQueryWithTransaction(dbConnectionString, insertSql, paramList);
            return insertCount;
        }

        /// <summary>
        /// 清除某个表中的全部数据
        /// </summary>
        /// <param name="enTable"></param>
        /// <returns></returns>
        public int deleteDataFromDB(dbTableOptions enTable)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return -1;
            string deleteSql = string.Format("delete from {0};", tableName);
            object[] param = { };
            return SQLiteHelper.ExecuteNonQuery(dbConnectionString, deleteSql, param);
        }

        /// <summary>
        /// 获取某个表的全部字段的全部数据
        /// </summary>
        /// <param name="enTable"></param>
        /// <returns></returns>
        public DataSet getDataFromDB(dbTableOptions enTable)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return null;
            string selectSql = string.Format("select * from {0};", tableName);
            SQLiteParameter[] paramList = { };
            return SQLiteHelper.ExecuteDataSet(dbConnectionString, selectSql, paramList);
        }

        /// <summary>
        /// 获取某个表的指定字段的全部数据
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="tableField">需要获取的字段，以','分隔</param>
        /// <returns></returns>
        public DataSet getDataFromDB(dbTableOptions enTable, string tableField)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return null;
            string selectSql = string.Format("select {0} from {1};", tableField, tableName);
            SQLiteParameter[] paramList = { };
            return SQLiteHelper.ExecuteDataSet(dbConnectionString, selectSql, paramList);
        }

        /// <summary>
        /// 获取某个表的全部字段的部分数据
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="whereClause">查询条件，可使用"@param"格式</param>
        /// <param name="paramList">无"@param"时，此字段传入{}，使用"@param"格式时，传入参数列表</param>
        /// <returns></returns>
        public DataSet getDataFromDB(dbTableOptions enTable, string whereClause, SQLiteParameter[] paramList)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return null;
            string selectSql = string.Format("select * from {0} where {1};", tableName, whereClause);
            return SQLiteHelper.ExecuteDataSet(dbConnectionString, selectSql, paramList);
        }

        /// <summary>
        /// 获取某个表的指定字段的部分数据
        /// </summary>
        /// <param name="enTable"></param>
        /// <param name="tableField">需要获取的字段，以','分隔</param>
        /// <param name="whereClause">查询条件，可使用"@param"格式</param>
        /// <param name="paramList">无"@param"时，此字段传入{}，使用"@param"格式时，传入参数列表</param>
        /// <returns></returns>
        public DataSet getDataFromDB(dbTableOptions enTable, string tableField, string whereClause, SQLiteParameter[] paramList)
        {
            string tableName = getTableNameByType(enTable);
            if (tableName == "")
                return null;
            string selectSql = string.Format("select {0} from {1} where {2};", tableField, tableName, whereClause);
            return SQLiteHelper.ExecuteDataSet(dbConnectionString, selectSql, paramList);
        }
        #endregion
    }
}
